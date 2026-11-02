program DfmLocSample;

uses
  Forms,
  MainForm in 'MainForm.pas' {frmMain},
  LangUtil in 'LangUtil.pas',
  LangDlg in 'LangDlg.pas',
  AlignForm in 'AlignForm.pas' {frmAlign},
  ControlsForm in 'ControlsForm.pas' {frmControls},
  Bevels in 'Bevels.pas' {frmBevels};

{$R *.res}

begin
  Application.Initialize;
  Application.CreateForm(TfrmMain, frmMain);
  Application.CreateForm(TLangSelectionDlg, LangSelectionDlg);
  Application.CreateForm(TfrmAlign, frmAlign);
  Application.CreateForm(TfrmControls, frmControls);
  Application.CreateForm(TfrmBevels, frmBevels);
  Application.Run;
end.
