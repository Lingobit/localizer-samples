#include <afxwin.h>
#include <afxcmn.h>
#include <afxdialogex.h>
#include <gdiplus.h>
#include <shellapi.h>
#include <filesystem>
#include <fstream>
#include <vector>
#include <algorithm>
#include "resource.h"
#pragma comment(lib,"shell32.lib")
#pragma comment(lib,"version.lib")
namespace fs = std::filesystem;
static HINSTANCE NativeModule = GetModuleHandleW(nullptr);
static std::wstring CurrentCulture;
static std::wstring RequestedCulture;
static CString Text(UINT id) {
    CString value;
    if(!value.LoadString(id)) {
        wchar_t text[1024]{};
        if(LoadStringW(NativeModule,id,text,_countof(text))) value=text;
    }
    return value;
}
static UINT SampleVersion(HINSTANCE module=AfxGetResourceHandle()) {
    auto resource=FindResourceW(module,MAKEINTRESOURCEW(1),RT_VERSION);
    if(!resource)throw std::runtime_error("Missing version resource");
    auto data=LockResource(LoadResource(module,resource));
    VS_FIXEDFILEINFO* version=nullptr;UINT size=0;
    if(!VerQueryValueW(data,L"\\",reinterpret_cast<void**>(&version),&size) || size<sizeof(*version) || version->dwSignature!=0xFEEF04BD)throw std::runtime_error("Invalid version resource");
    if(HIWORD(version->dwFileVersionMS)!=1 || LOWORD(version->dwFileVersionMS)>1)throw std::runtime_error("Unsupported sample version");
    return LOWORD(version->dwFileVersionMS)+1u;
}
struct LanguageChoice { std::wstring culture; fs::path file; };
static std::wstring NativeCulture() {
    WORD language=0;
    EnumResourceLanguagesW(NativeModule,RT_DIALOG,MAKEINTRESOURCEW(IDD_MAIN),
        [](HMODULE,LPCWSTR,LPCWSTR,WORD value,LONG_PTR data)->BOOL {
            auto current=reinterpret_cast<WORD*>(data);
            if(!*current || value==MAKELANGID(LANG_ENGLISH,SUBLANG_ENGLISH_US))*current=value;
            return TRUE;
        },reinterpret_cast<LONG_PTR>(&language));
    wchar_t name[LOCALE_NAME_MAX_LENGTH]{};
    if(language && LCIDToLocaleName(MAKELCID(language,SORT_DEFAULT),name,_countof(name),LOCALE_ALLOW_NEUTRAL_NAMES))return name;
    return L"en-US";
}
static fs::path ModulePath() {
    std::vector<wchar_t> path(32768);
    auto length=GetModuleFileNameW(NativeModule,path.data(),static_cast<DWORD>(path.size()));
    if(!length || length>=path.size())throw std::runtime_error("Cannot locate the sample");
    return fs::path(std::wstring(path.data(),length));
}
static bool UsableTranslation(HINSTANCE module,const std::wstring& culture) {
    try {
        if(SampleVersion(module)!=SampleVersion(NativeModule))return false;
        for(int id:{IDD_MAIN,IDD_EXPORT})
            if(!FindResourceW(module,MAKEINTRESOURCEW(id),RT_DIALOG) || !FindResourceW(module,MAKEINTRESOURCEW(id),MAKEINTRESOURCEW(240)))return false;
        if(!FindResourceW(module,MAKEINTRESOURCEW(IDR_MAIN_MENU),RT_MENU) ||
           !FindResourceW(module,MAKEINTRESOURCEW(IDR_MENU),RT_MENU) ||
           !FindResourceW(module,MAKEINTRESOURCEW(IDR_EXPORT_GUIDE),RT_HTML) ||
           !FindResourceW(module,MAKEINTRESOURCEW(IDR_EXPORT_PRESETS),L"XML"))return false;
        wchar_t target[1024]{};
        if(!LoadStringW(module,IDS_EXPORT_SUMMARY,target,_countof(target)))return false;
        auto language=LANGIDFROMLCID(LocaleNameToLCID(culture.c_str(),LOCALE_ALLOW_NEUTRAL_NAMES));
        struct LanguageProbe { WORD expected;bool found; } probe{language,false};
        EnumResourceLanguagesW(module,RT_DIALOG,MAKEINTRESOURCEW(IDD_MAIN),
            [](HMODULE,LPCWSTR,LPCWSTR,WORD actual,LONG_PTR data)->BOOL {
                auto state=reinterpret_cast<LanguageProbe*>(data);if(actual==state->expected)state->found=true;return TRUE;
            },reinterpret_cast<LONG_PTR>(&probe));
        return probe.found;
    }catch(const std::exception&){return false;}
}
static std::vector<LanguageChoice> AvailableLanguages() {
    std::vector<LanguageChoice> result{{NativeCulture(),{}}};
    std::vector<WORD> embeddedLanguages;
    EnumResourceLanguagesW(NativeModule,RT_DIALOG,MAKEINTRESOURCEW(IDD_MAIN),
        [](HMODULE,LPCWSTR,LPCWSTR,WORD language,LONG_PTR data)->BOOL {
            reinterpret_cast<std::vector<WORD>*>(data)->push_back(language);return TRUE;
        },reinterpret_cast<LONG_PTR>(&embeddedLanguages));
    for(auto language:embeddedLanguages) {
        wchar_t culture[LOCALE_NAME_MAX_LENGTH]{};
        if(LCIDToLocaleName(MAKELCID(language,SORT_DEFAULT),culture,_countof(culture),LOCALE_ALLOW_NEUTRAL_NAMES) &&
           culture!=NativeCulture() && UsableTranslation(NativeModule,culture)) result.push_back({culture,{}});
    }
    auto source=ModulePath().parent_path();
    if(NativeCulture()!=L"en-US") {
        for(const auto& file:std::vector<fs::path>{source.parent_path()/ModulePath().filename(),source.parent_path()/L"Release"/ModulePath().filename()}) {
            auto module=LoadLibraryExW(file.c_str(),nullptr,LOAD_LIBRARY_AS_DATAFILE|LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if(!module)continue;
            bool usable=UsableTranslation(module,L"en-US");FreeLibrary(module);
            if(usable){result.push_back({L"en-US",file});break;}
        }
    }
    // MFC resource-only satellites use the three-letter Windows language abbreviation:
    // MfcAppDEU.dll for German, including a neutral German project target.
    // Read candidate resources as data; never execute translation DLL entry points.
    const auto base=ModulePath().stem().wstring();
    for(const auto& root:std::vector<fs::path>{source,source.parent_path()}) {
        std::error_code error;
        fs::directory_iterator end;
        for(fs::directory_iterator item(root,error);!error && item!=end;item.increment(error)) {
            if(!item->is_regular_file(error))continue;
            const auto file=item->path();const auto stem=file.stem().wstring();
            if(_wcsicmp(file.extension().c_str(),L".dll")!=0 || stem.size()!=base.size()+3 || _wcsnicmp(stem.c_str(),base.c_str(),base.size())!=0)continue;
            auto module=LoadLibraryExW(file.c_str(),nullptr,LOAD_LIBRARY_AS_DATAFILE|LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if(!module)continue;
            std::vector<WORD> resourceLanguages;
            EnumResourceLanguagesW(module,RT_DIALOG,MAKEINTRESOURCEW(IDD_MAIN),
                [](HMODULE,LPCWSTR,LPCWSTR,WORD value,LONG_PTR data)->BOOL {
                    reinterpret_cast<std::vector<WORD>*>(data)->push_back(value);return TRUE;
                },reinterpret_cast<LONG_PTR>(&resourceLanguages));
            for(WORD language:resourceLanguages) {
                wchar_t cultureName[LOCALE_NAME_MAX_LENGTH]{},abbreviation[16]{};
                if(!LCIDToLocaleName(MAKELCID(language,SORT_DEFAULT),cultureName,_countof(cultureName),LOCALE_ALLOW_NEUTRAL_NAMES) ||
                   !GetLocaleInfoW(MAKELCID(language,SORT_DEFAULT),LOCALE_SABBREVLANGNAME,abbreviation,_countof(abbreviation)) ||
                   _wcsicmp(stem.c_str()+base.size(),abbreviation)!=0)continue;
                std::wstring culture=cultureName;
                if(std::any_of(result.begin(),result.end(),[&](const LanguageChoice& entry){return entry.culture==culture;}))continue;
                if(UsableTranslation(module,culture))result.push_back({culture,file});
            }
            FreeLibrary(module);
        }
    }
    // Both app-local de-DE/MfcApp.exe and restore's sibling de-DE folder are supported.
    for(const auto& root:std::vector<fs::path>{source,source.parent_path()}) {
        std::error_code error;
        fs::directory_iterator end;
        for(fs::directory_iterator item(root,error);!error && item!=end;item.increment(error)) {
            if(!item->is_directory(error))continue;
            auto culture=item->path().filename().wstring();
            wchar_t locale[LOCALE_NAME_MAX_LENGTH]{};
            if(!LCIDToLocaleName(LocaleNameToLCID(culture.c_str(),LOCALE_ALLOW_NEUTRAL_NAMES),locale,_countof(locale),LOCALE_ALLOW_NEUTRAL_NAMES))continue;
            culture=locale;
            if(std::any_of(result.begin(),result.end(),[&](const LanguageChoice& entry){return entry.culture==culture;}))continue;
            auto file=item->path()/ModulePath().filename();
            auto module=LoadLibraryExW(file.c_str(),nullptr,LOAD_LIBRARY_AS_DATAFILE|LOAD_LIBRARY_AS_IMAGE_RESOURCE);
            if(!module)continue;
            bool usable=UsableTranslation(module,culture);FreeLibrary(module);
            if(usable)result.push_back({culture,file});
        }
    }
    std::sort(result.begin()+1,result.end(),[](const LanguageChoice& a,const LanguageChoice& b){return a.culture<b.culture;});
    return result;
}
static CString LanguageLabel(const std::wstring& culture) {
    if(culture==L"en-US")return L"English";
    if(culture==L"de" || culture==L"de-DE")return L"Deutsch";
    wchar_t label[128]{};
    if(GetLocaleInfoEx(culture.c_str(),LOCALE_SNATIVELANGUAGENAME,label,_countof(label)))return label;
    return culture.c_str();
}
static bool GermanResources() { return FindResourceExW(AfxGetResourceHandle(),RT_STRING,MAKEINTRESOURCEW(IDS_EXPORT_SUMMARY/16+1),MAKELANGID(LANG_GERMAN,SUBLANG_GERMAN))!=nullptr; }
static fs::path OutputFolder;
static HACCEL Accelerators;
static std::wstring ReadTextResource(UINT id,LPCWSTR type) {
    auto module=AfxGetResourceHandle();
    auto resource=FindResourceW(module,MAKEINTRESOURCEW(id),type);
    if(!resource) throw std::runtime_error("Missing embedded sample content");
    auto loaded=LoadResource(module,resource);
    auto bytes=static_cast<const BYTE*>(LockResource(loaded));
    auto size=SizeofResource(module,resource);
    if(!bytes || !size) throw std::runtime_error("Empty embedded sample content");
    if(size>=2 && ((bytes[0]==0xFF && bytes[1]==0xFE) || (bytes[0]==0xFE && bytes[1]==0xFF))) {
        if(size%2) throw std::runtime_error("Invalid UTF-16 embedded sample content");
        bool little=bytes[0]==0xFF; std::wstring value;
        for(DWORD index=2;index<size;index+=2) value.push_back(static_cast<wchar_t>(little?(bytes[index]|(bytes[index+1]<<8)):((bytes[index]<<8)|bytes[index+1])));
        return value;
    }
    DWORD offset=(size>=3 && bytes[0]==0xEF && bytes[1]==0xBB && bytes[2]==0xBF)?3:0;
    auto utf8=reinterpret_cast<const char*>(bytes+offset);
    int length=static_cast<int>(size-offset);
    int count=MultiByteToWideChar(CP_UTF8,MB_ERR_INVALID_CHARS,utf8,length,nullptr,0);
    if(!count) throw std::runtime_error("Invalid UTF-8 embedded sample content");
    std::wstring value(count,L' ');
    MultiByteToWideChar(CP_UTF8,MB_ERR_INVALID_CHARS,utf8,length,value.data(),count);
    return value;
}
static void WriteUtf8(const fs::path& path,const CString& value) {
    int count=WideCharToMultiByte(CP_UTF8,0,value,value.GetLength(),nullptr,0,nullptr,nullptr);
    std::string bytes(count,' '); WideCharToMultiByte(CP_UTF8,0,value,value.GetLength(),bytes.data(),count,nullptr,nullptr);
    std::ofstream file(path,std::ios::binary); file.write(bytes.data(),bytes.size());
}
static CString Guide() {
    auto content=ReadTextResource(IDR_EXPORT_GUIDE,RT_HTML);
    auto start=content.find(L"<p>"); auto end=content.find(L"</p>",start);
    if(start==std::wstring::npos || end==std::wstring::npos) throw std::runtime_error("Invalid guide content");
    return CString(content.substr(start+3,end-start-3).c_str());
}
static CString PresetDescription() {
    auto content=ReadTextResource(IDR_EXPORT_PRESETS,L"XML");
    auto start=content.find(L"description=\""); if(start==std::wstring::npos) throw std::runtime_error("Invalid presets content");
    start+=13; auto end=content.find(L'"',start); return CString(content.substr(start,end-start).c_str());
}
static CString Summary() {
    CString format=Text(IDS_EXPORT_SUMMARY),value;
    // Malformed demonstration translations never reach the native variadic formatter.
    int argument=0;
    for(int index=0;index<format.GetLength();++index) {
        if(format[index]!=L'%') continue;
        if(++index==format.GetLength()) return Text(IDS_PREVIEW_HINT);
        if(format[index]==L'%') continue;
        if((argument==0 && format[index]==L'u') || (argument==1 && format[index]==L's')) ++argument;
        else return Text(IDS_PREVIEW_HINT);
    }
    if(argument!=2) return Text(IDS_PREVIEW_HINT);
    value.Format(format,12u,L"sample.pdf"); return value;
}
static void Capture(CWnd& window,const fs::path& path) {
    window.ShowWindow(SW_SHOWNOACTIVATE);
    window.RedrawWindow(nullptr,nullptr,RDW_INVALIDATE|RDW_ERASE|RDW_ALLCHILDREN|RDW_FRAME|RDW_UPDATENOW);
    CRect rect; window.GetWindowRect(&rect);
    HDC screen=GetDC(nullptr),memory=CreateCompatibleDC(screen);
    HBITMAP bitmap=CreateCompatibleBitmap(screen,rect.Width(),rect.Height()); HGDIOBJ previous=SelectObject(memory,bitmap);
    if(!PrintWindow(window.GetSafeHwnd(),memory,0)) { SelectObject(memory,previous);DeleteObject(bitmap);DeleteDC(memory);ReleaseDC(nullptr,screen);throw std::runtime_error("PrintWindow failed"); }
    SelectObject(memory,previous);
    UINT count=0,size=0; Gdiplus::GetImageEncodersSize(&count,&size); std::vector<BYTE> buffer(size);
    auto encoders=reinterpret_cast<Gdiplus::ImageCodecInfo*>(buffer.data()); Gdiplus::GetImageEncoders(count,size,encoders);
    CLSID png{}; bool found=false;for(UINT i=0;i<count;i++) if(wcscmp(encoders[i].MimeType,L"image/png")==0){png=encoders[i].Clsid;found=true;break;}
    { Gdiplus::Bitmap image(bitmap,nullptr); if(!found || image.Save(path.c_str(),&png,nullptr)!=Gdiplus::Ok) throw std::runtime_error("PNG capture failed"); }
    DeleteObject(bitmap);DeleteDC(memory);ReleaseDC(nullptr,screen);
}
class ExportDialog final : public CDialogEx {
public:
    ExportDialog():CDialogEx(IDD_EXPORT){}
    BOOL OnInitDialog() override {
        CDialogEx::OnInitDialog();
        SendDlgItemMessage(IDC_PAGES,CB_SETCURSEL,0);
        SendDlgItemMessage(IDC_FOLDER,CB_SETCURSEL,0);return TRUE;
    }
    void OnOK() override {
        CString folder;GetDlgItemText(IDC_FOLDER,folder);folder.Trim();
        SetDlgItemText(IDC_EXPORT_NOTE,folder.IsEmpty()?Text(IDS_FOLDER_REQUIRED):Summary());
    }
    afx_msg void OnExport(){OnOK();}
    afx_msg void OnPageSetup(){EndDialog(IDC_PAGE_SETUP);}
    DECLARE_MESSAGE_MAP()
};
BEGIN_MESSAGE_MAP(ExportDialog,CDialogEx)
 ON_BN_CLICKED(IDC_EXPORT_RUN,&ExportDialog::OnExport)
 ON_BN_CLICKED(IDC_PAGE_SETUP,&ExportDialog::OnPageSetup)
END_MESSAGE_MAP()
class MainDialog final : public CDialogEx {
    std::vector<LanguageChoice> languages;
public:
    MainDialog():CDialogEx(IDD_MAIN){}
    BOOL OnInitDialog() override {
        CDialogEx::OnInitDialog(); SetIcon(AfxGetApp()->LoadIcon(IDI_SAMPLE),TRUE);SetIcon(AfxGetApp()->LoadIcon(IDI_SAMPLE),FALSE);
        RefreshLanguageMenu(*GetMenu()->GetSubMenu(1));
        DrawMenuBar();
        RestoreOptions();
        SetDlgItemText(IDC_RESOURCE_MESSAGE,Summary());SetDlgItemText(IDC_STATUS,Text(IDS_READY));
        if(!OutputFolder.empty())PostMessage(WM_APP+1); return TRUE;
    }
    afx_msg void OnExport(){ExportDialog dialog; if(dialog.DoModal()==IDC_PAGE_SETUP)GetDlgItem(IDC_PORTRAIT)->SetFocus();}
    afx_msg void OnSave(){SetDlgItemText(IDC_STATUS,Text(IDS_SAVED_PROFILE));}
    afx_msg void OnGuide(){SetDlgItemText(IDC_STATUS,Guide());}
    void RestoreOptions(){
        CheckRadioButton(IDC_PORTRAIT,IDC_LANDSCAPE,IDC_PORTRAIT);
        for(int id:{IDC_COLOR,IDC_MARGINS,IDC_SCALE,IDC_FORMAT,IDC_QUALITY})
            SendDlgItemMessage(id,CB_SETCURSEL,0);
        SendDlgItemMessage(IDC_PROFILES,LB_SETCURSEL,0);
        for(int id:{IDC_DUPLEX,IDC_SOUND,IDC_FIT_WIDTH,IDC_PROPERTIES,IDC_OPEN_FILE,IDC_DESKTOP_NOTICE,IDC_OPEN_FOLDER})
            if(GetDlgItem(id))CheckDlgButton(id,BST_UNCHECKED);
    }
    afx_msg void OnRestore(){RestoreOptions();SetDlgItemText(IDC_STATUS,Text(IDS_DEFAULTS_RESTORED));}
    afx_msg void OnOpenFolder(){SetDlgItemText(IDC_STATUS,Text(IDS_FOLDER_OPENS));}
    void RefreshLanguageMenu(CMenu& menu) {
        languages=AvailableLanguages();
        while(menu.GetMenuItemCount()>0)menu.DeleteMenu(0,MF_BYPOSITION);
        for(size_t index=0;index<languages.size() && index<=ID_LANGUAGE_LAST-ID_LANGUAGE_FIRST;++index)
            menu.AppendMenu(MF_STRING|(languages[index].culture==CurrentCulture?MF_CHECKED:0),ID_LANGUAGE_FIRST+index,LanguageLabel(languages[index].culture));
    }
    afx_msg void OnInitMenuPopup(CMenu* menu,UINT index,BOOL system) {
        CDialogEx::OnInitMenuPopup(menu,index,system);
        auto bar=GetMenu();
        if(!system && bar && menu->GetSafeHmenu()==bar->GetSubMenu(1)->GetSafeHmenu())RefreshLanguageMenu(*menu);
    }
    void BuildContextMenu(CMenu& menu) {
        if(!menu.LoadMenu(IDR_MENU))throw std::runtime_error("Missing context menu");
        auto popup=menu.GetSubMenu(0);
        if(!popup)throw std::runtime_error("Missing context actions");
        CMenu choices;choices.CreatePopupMenu();
        RefreshLanguageMenu(choices);
        popup->AppendMenu(MF_SEPARATOR);
        popup->AppendMenu(MF_POPUP,reinterpret_cast<UINT_PTR>(choices.GetSafeHmenu()),Text(IDS_LANGUAGE_MENU));
        choices.Detach();
    }
    afx_msg void OnLanguage(UINT command) {
        auto index=command-ID_LANGUAGE_FIRST;
        if(index<languages.size() && languages[index].culture!=CurrentCulture) {
            RequestedCulture=languages[index].culture;EndDialog(IDOK);
        }
    }    afx_msg void OnContextMenu(CWnd*,CPoint point){
        CMenu menu;BuildContextMenu(menu);
        CMenu* popup=menu.GetSubMenu(0);if(!popup)return;
        if(point.x==-1 && point.y==-1){
            CWnd* focus=GetFocus();CRect bounds;
            (focus && (focus==this || IsChild(focus))?focus:this)->GetWindowRect(&bounds);
            point=bounds.CenterPoint();
        }
        const UINT command=popup->TrackPopupMenu(TPM_RETURNCMD|TPM_RIGHTBUTTON,point.x,point.y,this);
        if(command)SendMessage(WM_COMMAND,MAKEWPARAM(command,0));
    }
    afx_msg void OnExit(){EndDialog(IDOK);}
    afx_msg LRESULT OnSmoke(WPARAM,LPARAM){
        try{
            fs::create_directories(OutputFolder);
            CMenu menu;BuildContextMenu(menu);
            auto bar=GetMenu();
            if(!bar || bar->GetMenuItemCount()!=3 || GetDlgItem(IDC_IMAGE) || !menu.GetSubMenu(0) || menu.GetSubMenu(0)->GetMenuItemCount()!=9)throw std::runtime_error("Invalid main/context menu or unexpected picture");
            auto file=bar->GetSubMenu(0);auto choices=bar->GetSubMenu(1);
            if(file->GetMenuItemCount()!=5 || file->GetMenuItemID(0)!=ID_FILE_PREVIEW || file->GetMenuItemID(1)!=ID_FILE_EXPORT || file->GetMenuItemID(2)!=ID_SAMPLE_SAVE || file->GetMenuItemID(4)!=ID_FILE_EXIT || bar->GetSubMenu(2)->GetMenuItemID(0)!=ID_HELP_GUIDE || choices->GetMenuItemCount()!=static_cast<int>(languages.size()))throw std::runtime_error("Incorrect menu commands");
            unsigned checked=0;
            for(size_t index=0;index<languages.size();++index){
                bool selected=(choices->GetMenuState(static_cast<UINT>(index),MF_BYPOSITION)&MF_CHECKED)!=0;
                if(selected)++checked;
                if(selected!=(languages[index].culture==CurrentCulture))throw std::runtime_error("Incorrect language selection");
            }
            if(checked!=1)throw std::runtime_error("Missing selected language");
            if(!FindResourceW(AfxGetResourceHandle(),MAKEINTRESOURCEW(IDR_SAMPLE_INIT),MAKEINTRESOURCEW(240)) || !FindResourceW(AfxGetResourceHandle(),MAKEINTRESOURCEW(IDD_MAIN),MAKEINTRESOURCEW(240)) || !FindResourceW(AfxGetResourceHandle(),MAKEINTRESOURCEW(IDD_EXPORT),MAKEINTRESOURCEW(240)))throw std::runtime_error("Missing dialog DLGINIT");
            for(int id:{IDC_COLOR,IDC_MARGINS,IDC_SCALE,IDC_FORMAT,IDC_QUALITY})
                if(SendDlgItemMessage(id,CB_GETCOUNT)<2 || SendDlgItemMessage(id,CB_GETCURSEL)!=0)throw std::runtime_error("Empty combo or incorrect initial selection");
            if(SendDlgItemMessage(IDC_PROFILES,LB_GETCOUNT)!=4 || SendDlgItemMessage(IDC_PROFILES,LB_GETCURSEL)!=0)throw std::runtime_error("Invalid saved profiles list");
            SendMessage(WM_COMMAND,ID_SAMPLE_SAVE);CString status;GetDlgItemText(IDC_STATUS,status);
            if(status!=Text(IDS_SAVED_PROFILE))throw std::runtime_error("Context command failed");
            SetDlgItemText(IDC_STATUS,Text(IDS_READY));
            Capture(*this,OutputFolder/L"main.png");
            CRect mainBounds;GetWindowRect(&mainBounds);UINT dpi=GetDpiForWindow(m_hWnd);
            if(MulDiv(mainBounds.Width(),96,dpi)>780 || MulDiv(mainBounds.Height(),96,dpi)>560)throw std::runtime_error("Main dialog exceeds the capture budget at 100 percent");
            ExportDialog dialog;dialog.Create(IDD_EXPORT,this);dialog.ShowWindow(SW_SHOW);dialog.UpdateWindow();if(dialog.SendDlgItemMessage(IDC_FOLDER,CB_GETCOUNT)!=3 || dialog.SendDlgItemMessage(IDC_PAGES,CB_GETCOUNT)!=3)throw std::runtime_error("Empty export combo");Capture(dialog,OutputFolder/L"export.png");
            dialog.SendDlgItemMessage(IDC_FOLDER,CB_SETCURSEL,static_cast<WPARAM>(-1));
            dialog.SendMessage(WM_COMMAND,IDC_EXPORT_RUN);CString note;dialog.GetDlgItemText(IDC_EXPORT_NOTE,note);
            if(note!=Text(IDS_FOLDER_REQUIRED))throw std::runtime_error("Missing folder validation");
            dialog.SendDlgItemMessage(IDC_FOLDER,CB_SETCURSEL,0);dialog.SendMessage(WM_COMMAND,IDC_EXPORT_RUN);dialog.GetDlgItemText(IDC_EXPORT_NOTE,note);
            if(note!=Summary())throw std::runtime_error("Export action failed");
            dialog.DestroyWindow();
            CString summary;summary.Format(L"PASS\nversion=%u\nreference=%s\nsummary=%s\nhtml=%s\nxml=%s\n",SampleVersion(),GermanResources()?L"de-DE":L"en-US",Summary().GetString(),Guide().GetString(),PresetDescription().GetString());
            CString geometry;geometry.Format(L"dpi=%u\nmain100=%dx%d\n",dpi,MulDiv(mainBounds.Width(),96,dpi),MulDiv(mainBounds.Height(),96,dpi));summary+=geometry;
            summary+=L"mainMenu=File,Language,Help\nculture=";summary+=CurrentCulture.c_str();summary+=L"\nlanguages=";
            for(size_t index=0;index<languages.size();++index){if(index)summary+=L",";summary+=languages[index].culture.c_str();}summary+=L"\n";
            if(Summary().IsEmpty() || Guide().IsEmpty() || PresetDescription().IsEmpty())throw std::runtime_error("Invalid sample resources");
            WriteUtf8(OutputFolder/L"result.txt",summary);EndDialog(IDOK);
        }catch(const std::exception&){WriteUtf8(OutputFolder/L"result.txt",L"FAIL: sample smoke or capture failed\n");EndDialog(IDCANCEL);}
        return 0;
    }
    DECLARE_MESSAGE_MAP()
};
BEGIN_MESSAGE_MAP(MainDialog,CDialogEx)
 ON_WM_CONTEXTMENU()
 ON_WM_INITMENUPOPUP()
 ON_COMMAND_RANGE(ID_LANGUAGE_FIRST,ID_LANGUAGE_LAST,&MainDialog::OnLanguage)
 ON_BN_CLICKED(IDC_OPEN_FOLDER,&MainDialog::OnOpenFolder)
 ON_BN_CLICKED(IDC_RESTORE_DEFAULTS,&MainDialog::OnRestore)
 ON_BN_CLICKED(IDC_EXPORT_OPTIONS,&MainDialog::OnExport)
 ON_BN_CLICKED(IDC_SAVE_PROFILE,&MainDialog::OnSave)
 ON_COMMAND(ID_FILE_PREVIEW,&MainDialog::OnGuide)
 ON_COMMAND(ID_FILE_EXPORT,&MainDialog::OnExport)
 ON_COMMAND(ID_SAMPLE_SAVE,&MainDialog::OnSave)
 ON_COMMAND(ID_FILE_EXIT,&MainDialog::OnExit)
 ON_COMMAND(ID_HELP_GUIDE,&MainDialog::OnGuide)
 ON_MESSAGE(WM_APP+1,&MainDialog::OnSmoke)
END_MESSAGE_MAP()
class ShowcaseApp final : public CWinApp {
    ULONG_PTR imageToken=0;
    int exitCode=0;
public:
    BOOL InitInstance() override {
        INITCOMMONCONTROLSEX controls{sizeof(controls),ICC_WIN95_CLASSES};InitCommonControlsEx(&controls);CWinApp::InitInstance();
        Gdiplus::GdiplusStartupInput images;Gdiplus::GdiplusStartup(&imageToken,&images,nullptr);
        int count=0;auto arguments=CommandLineToArgvW(GetCommandLineW(),&count);
        std::wstring culture=NativeCulture();
        for(int i=1;i<count;i++) {
            if(wcscmp(arguments[i],L"--smoke")==0 && i+1<count)OutputFolder=arguments[++i];
            else if(wcscmp(arguments[i],L"--culture")==0 && i+1<count)culture=arguments[++i];
        }
        LocalFree(arguments);
        try {
            do {
                RequestedCulture.clear();
                auto languages=AvailableLanguages();
                auto choice=std::find_if(languages.begin(),languages.end(),[&](const LanguageChoice& entry){return _wcsicmp(entry.culture.c_str(),culture.c_str())==0;});
                if(choice==languages.end())choice=languages.begin();
                CurrentCulture=choice->culture;
                HINSTANCE translation=choice->file.empty()?nullptr:LoadLibraryExW(choice->file.c_str(),nullptr,LOAD_LIBRARY_AS_DATAFILE|LOAD_LIBRARY_AS_IMAGE_RESOURCE);
                if(!choice->file.empty() && !translation){CurrentCulture=NativeCulture();}
                SetThreadUILanguage(LANGIDFROMLCID(LocaleNameToLCID(CurrentCulture.c_str(),LOCALE_ALLOW_NEUTRAL_NAMES)));
                AfxSetResourceHandle(translation?translation:NativeModule);
                Accelerators=LoadAcceleratorsW(AfxGetResourceHandle(),MAKEINTRESOURCEW(IDR_ACCELERATORS));
                {
                    MainDialog dialog;m_pMainWnd=&dialog;exitCode=dialog.DoModal()==IDCANCEL?1:0;
                }
                m_pMainWnd=nullptr;Accelerators=nullptr;AfxSetResourceHandle(NativeModule);
                if(translation)FreeLibrary(translation);
                culture=RequestedCulture;
            }while(!RequestedCulture.empty());
        }
        catch(const std::exception&){exitCode=1;if(!OutputFolder.empty()){fs::create_directories(OutputFolder);WriteUtf8(OutputFolder/L"result.txt",L"FAIL: missing sample content\n");}}
        return FALSE;
    }
    int ExitInstance() override {if(imageToken)Gdiplus::GdiplusShutdown(imageToken);CWinApp::ExitInstance();return exitCode;}
    BOOL ProcessMessageFilter(int code,LPMSG message) override {if(m_pMainWnd && Accelerators && ::TranslateAcceleratorW(m_pMainWnd->GetSafeHwnd(),Accelerators,message))return TRUE;return CWinApp::ProcessMessageFilter(code,message);}
} Showcase;
