object LangSelectionDlg: TLangSelectionDlg
  Left = 344
  Top = 253
  BorderStyle = bsSingle
  Caption = 'Available Languages'
  ClientHeight = 261
  ClientWidth = 290
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  OnCreate = FormCreate
  OnDestroy = FormDestroy
  PixelsPerInch = 96
  TextHeight = 13
  object Button1: TButton
    Left = 208
    Top = 8
    Width = 75
    Height = 25
    Caption = 'OK'
    ModalResult = 1
    TabOrder = 0
  end
  object Button2: TButton
    Left = 208
    Top = 40
    Width = 75
    Height = 25
    Caption = 'Cancel'
    ModalResult = 2
    TabOrder = 1
  end
  object LangList: TListBox
    Left = 8
    Top = 8
    Width = 193
    Height = 241
    ItemHeight = 13
    TabOrder = 2
  end
end
