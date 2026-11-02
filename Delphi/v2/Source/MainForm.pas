unit MainForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, Menus, ExtCtrls, StdCtrls, Buttons, jpeg;

type
  TfrmMain = class(TForm)
    MainMenu: TMainMenu;
    Samples1: TMenuItem;
    Options1: TMenuItem;
    CangeLanguage1: TMenuItem;
    Exit1: TMenuItem;
    Panel1: TPanel;
    Panel2: TPanel;
    Splitter1: TSplitter;
    Image1: TImage;
    BitBtn1: TBitBtn;
    OpenDialog: TOpenDialog;
    Label1: TLabel;
    AlignmentForm1: TMenuItem;
    N1: TMenuItem;
    CommonControlsFrom1: TMenuItem;
    Label2: TLabel;
    Bevelsandshapes1: TMenuItem;
    procedure Exit1Click(Sender: TObject);
    procedure BitBtn1Click(Sender: TObject);
    procedure CangeLanguage1Click(Sender: TObject);
    procedure AlignmentForm1Click(Sender: TObject);
    procedure CommonControlsFrom1Click(Sender: TObject);
    procedure Bevelsandshapes1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmMain: TfrmMain;

implementation
uses LangDlg, LangUtil, AlignForm, ControlsForm, Bevels;

{$R *.dfm}

procedure TfrmMain.Exit1Click(Sender: TObject);
begin
   Close;
end;

procedure TfrmMain.BitBtn1Click(Sender: TObject);
begin
   if OpenDialog.Execute then
      Image1.Picture.LoadFromFile( OpenDialog.FileName );
end;

procedure TfrmMain.CangeLanguage1Click(Sender: TObject);
begin
   if LangSelectionDlg.Execute then
     if LoadNewResourceModule( LangSelectionDlg.ResourceFileName ) <> 0 then begin
         ReinitializeForms();
     end;
end;

procedure TfrmMain.AlignmentForm1Click(Sender: TObject);
begin
  frmAlign.Show;
end;

procedure TfrmMain.CommonControlsFrom1Click(Sender: TObject);
begin
  frmControls.Show;
end;

procedure TfrmMain.Bevelsandshapes1Click(Sender: TObject);
begin
    frmBevels.Show;
end;

end.
