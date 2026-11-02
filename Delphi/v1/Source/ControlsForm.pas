unit ControlsForm;

interface

uses
  Windows, Messages, SysUtils, Variants, Classes, Graphics, Controls, Forms,
  Dialogs, ComCtrls, StdCtrls;

type
  TfrmControls = class(TForm)
    ListBox1: TListBox;
    ComboBox1: TComboBox;
    Label1: TLabel;
    Label2: TLabel;
    GroupBox1: TGroupBox;
    GroupBox2: TGroupBox;
    TreeView1: TTreeView;
    Button1: TButton;
    GroupBox3: TGroupBox;
    RadioButton1: TRadioButton;
    RadioButton2: TRadioButton;
    GroupBox4: TGroupBox;
    CheckBox3: TCheckBox;
    CheckBox4: TCheckBox;
    TrackBar1: TTrackBar;
    Label3: TLabel;
    ProgressBar1: TProgressBar;
    Label4: TLabel;
    procedure Button1Click(Sender: TObject);
  private
    { Private declarations }
  public
    { Public declarations }
  end;

var
  frmControls: TfrmControls;

implementation

{$R *.dfm}

procedure TfrmControls.Button1Click(Sender: TObject);
begin
 close;
end;

end.
