object frmControls: TfrmControls
  Left = 436
  Top = 232
  BorderStyle = bsDialog
  Caption = 'Form with controls'
  ClientHeight = 375
  ClientWidth = 460
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Label3: TLabel
    Left = 24
    Top = 304
    Width = 47
    Height = 13
    Caption = 'Track Bar'
  end
  object Label4: TLabel
    Left = 192
    Top = 304
    Width = 60
    Height = 13
    Caption = 'Progress Bar'
  end
  object GroupBox1: TGroupBox
    Left = 8
    Top = 8
    Width = 169
    Height = 193
    Caption = 'Select character'
    TabOrder = 0
    object Label1: TLabel
      Left = 8
      Top = 56
      Width = 26
      Height = 13
      Caption = 'Race'
    end
    object Label2: TLabel
      Left = 8
      Top = 16
      Width = 18
      Height = 13
      Caption = 'Sex'
    end
    object ComboBox1: TComboBox
      Left = 8
      Top = 32
      Width = 145
      Height = 21
      Style = csDropDownList
      ItemHeight = 13
      ItemIndex = 0
      TabOrder = 0
      Text = 'Male'
      Items.Strings = (
        'Male'
        'Female')
    end
    object ListBox1: TListBox
      Left = 8
      Top = 72
      Width = 145
      Height = 105
      ItemHeight = 13
      Items.Strings = (
        'Knight'
        'Paladdin'
        'Thief'
        'Wizard'
        'Barbarian'
        '')
      TabOrder = 1
    end
  end
  object GroupBox2: TGroupBox
    Left = 184
    Top = 8
    Width = 185
    Height = 193
    Caption = 'Select world'
    TabOrder = 1
    object TreeView1: TTreeView
      Left = 8
      Top = 16
      Width = 169
      Height = 169
      Indent = 19
      TabOrder = 0
      Items.Data = {
        010000001C0000000000000000000000FFFFFFFFFFFFFFFF0000000004000000
        03416C6C1E0000000000000000000000FFFFFFFFFFFFFFFF0000000000000000
        05536F7574681D0000000000000000000000FFFFFFFFFFFFFFFF000000000000
        000004576573741E0000000000000000000000FFFFFFFFFFFFFFFF0000000000
        000000054E6F7274681D0000000000000000000000FFFFFFFFFFFFFFFF000000
        00000000000445617374}
    end
  end
  object Button1: TButton
    Left = 376
    Top = 8
    Width = 75
    Height = 25
    Caption = 'Close'
    TabOrder = 2
    OnClick = Button1Click
  end
  object GroupBox3: TGroupBox
    Left = 8
    Top = 208
    Width = 169
    Height = 81
    Caption = 'Sample Radio Buttons'
    TabOrder = 3
    object RadioButton1: TRadioButton
      Left = 16
      Top = 24
      Width = 113
      Height = 17
      Caption = 'High'
      TabOrder = 0
    end
    object RadioButton2: TRadioButton
      Left = 16
      Top = 48
      Width = 113
      Height = 17
      Caption = 'Low'
      TabOrder = 1
    end
  end
  object GroupBox4: TGroupBox
    Left = 184
    Top = 208
    Width = 185
    Height = 81
    Caption = 'Sample CheckBoxes'
    TabOrder = 4
    object CheckBox3: TCheckBox
      Left = 16
      Top = 48
      Width = 49
      Height = 17
      Caption = 'Two'
      TabOrder = 0
    end
    object CheckBox4: TCheckBox
      Left = 16
      Top = 24
      Width = 49
      Height = 17
      Caption = 'One'
      TabOrder = 1
    end
  end
  object TrackBar1: TTrackBar
    Left = 16
    Top = 320
    Width = 161
    Height = 45
    TabOrder = 5
  end
  object ProgressBar1: TProgressBar
    Left = 192
    Top = 320
    Width = 177
    Height = 17
    TabOrder = 6
  end
end
