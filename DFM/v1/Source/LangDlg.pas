unit LangDlg;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, StdCtrls;

type
  TLangSelectionDlg = class(TForm)
    Button1: TButton;
    Button2: TButton;
    LangList: TListBox;
    procedure FormCreate(Sender: TObject);
    procedure FormDestroy(Sender: TObject);
  private
    fNames:TStringList;

    function GetResourceFileName : String;

  public
    function Execute : boolean;

    property ResourceFileName : String read GetResourceFileName;
  end;

var
  LangSelectionDlg: TLangSelectionDlg;

implementation
uses LangUtil;

{$R *.dfm}

function TLangSelectionDlg.Execute : boolean;
var i : integer;
    fileName : string;
    lng: Word;
    flag : boolean;
    ExeName : string;
begin
   result := false;

   ExeName := Application.ExeName;
   i := length( ExeName );
   while (i>0) and (ExeName[i] <> '.') do dec( i);
   if i > 0 then
      delete( ExeName, i, length( ExeName ) - i + 1 );
   ExeName := ExeName + '.';

   fNames.Clear;
   LangList.items.clear();
   LangList.Items.Add( '<Default>' );
   fNames.Add( '' );
    for lng := 0 to $3ff do begin
     flag := false;
     for i := 0 to Languages.Count - 1 do begin
       if lng = Languages.LocaleID[ i ] and $3ff then begin
         if not flag then begin
           fileName := ExeName + Copy( Languages.Ext[ i ], 1, 2 );
           if FileExists( fileName ) then begin
             fNames.Add( fileName );
             LangList.Items.Add( GetStrLocaleInfo( Languages.LocaleID[ i ], LOCALE_SENGLANGUAGE  ) );
           end;
           flag := true;
         end;
         if word( Languages.LocaleID[ i ] ) <> lng then begin
            fileName := ExeName + Languages.Ext[ i ];
            if FileExists( fileName ) then begin
               fNames.Add( fileName );
               LangList.Items.Add( GetStrLocaleInfo( Languages.LocaleID[ i ], LOCALE_SENGLANGUAGE  )
                 + ' - ' + GetStrLocaleInfo( Languages.LocaleID[ i ], LOCALE_SENGCOUNTRY ) );
            end;
         end;
       end;
     end;
   end;

   if LangList.Items.Count > 0 then begin
     LangList.ItemIndex := 0;

     result := ShowModal = MROK;
   end;
end;

function TLangSelectionDlg.GetResourceFileName : String;
begin
   result := FNames[ LangList.ItemIndex ];
end;

procedure TLangSelectionDlg.FormCreate(Sender: TObject);
begin
  fNames := TStringList.Create;
end;

procedure TLangSelectionDlg.FormDestroy(Sender: TObject);
begin
  fNames.Free;
end;

end.
