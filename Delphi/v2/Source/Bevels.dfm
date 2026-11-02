object frmBevels: TfrmBevels
  Left = 370
  Top = 324
  Width = 518
  Height = 367
  Caption = 'Bevels and Shapes'
  Color = clBtnFace
  Font.Charset = DEFAULT_CHARSET
  Font.Color = clWindowText
  Font.Height = -11
  Font.Name = 'MS Sans Serif'
  Font.Style = []
  OldCreateOrder = False
  PixelsPerInch = 96
  TextHeight = 13
  object Bevel1: TBevel
    Left = 56
    Top = 40
    Width = 81
    Height = 25
    Shape = bsTopLine
  end
  object Bevel2: TBevel
    Left = 40
    Top = 56
    Width = 25
    Height = 65
    Shape = bsLeftLine
  end
  object Bevel3: TBevel
    Left = 56
    Top = 112
    Width = 81
    Height = 26
    Shape = bsBottomLine
  end
  object Bevel4: TBevel
    Left = 128
    Top = 56
    Width = 26
    Height = 65
    Shape = bsRightLine
  end
  object Label1: TLabel
    Left = 8
    Top = 8
    Width = 67
    Height = 13
    Caption = 'Bevel Lines'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Label2: TLabel
    Left = 72
    Top = 80
    Width = 41
    Height = 13
    Caption = 'Lowered'
  end
  object Bevel5: TBevel
    Left = 208
    Top = 40
    Width = 81
    Height = 25
    Shape = bsTopLine
    Style = bsRaised
  end
  object Bevel6: TBevel
    Left = 192
    Top = 56
    Width = 25
    Height = 65
    Shape = bsLeftLine
    Style = bsRaised
  end
  object Bevel7: TBevel
    Left = 208
    Top = 112
    Width = 81
    Height = 26
    Shape = bsBottomLine
    Style = bsRaised
  end
  object Bevel8: TBevel
    Left = 280
    Top = 56
    Width = 26
    Height = 65
    Shape = bsRightLine
    Style = bsRaised
  end
  object Label3: TLabel
    Left = 232
    Top = 80
    Width = 33
    Height = 13
    Caption = 'Raised'
  end
  object Label4: TLabel
    Left = 8
    Top = 160
    Width = 70
    Height = 13
    Caption = 'Bevel Rects'
    Font.Charset = DEFAULT_CHARSET
    Font.Color = clWindowText
    Font.Height = -11
    Font.Name = 'MS Sans Serif'
    Font.Style = [fsBold]
    ParentFont = False
  end
  object Bevel9: TBevel
    Left = 40
    Top = 192
    Width = 73
    Height = 73
  end
  object Bevel10: TBevel
    Left = 128
    Top = 192
    Width = 81
    Height = 73
    Style = bsRaised
  end
  object Bevel11: TBevel
    Left = 224
    Top = 192
    Width = 81
    Height = 73
    Shape = bsFrame
  end
  object Bevel12: TBevel
    Left = 320
    Top = 192
    Width = 81
    Height = 73
    Shape = bsFrame
    Style = bsRaised
  end
  object Label5: TLabel
    Left = 56
    Top = 224
    Width = 41
    Height = 13
    Caption = 'Lowered'
  end
  object Label6: TLabel
    Left = 240
    Top = 224
    Width = 41
    Height = 13
    Caption = 'Lowered'
  end
  object Label7: TLabel
    Left = 152
    Top = 224
    Width = 33
    Height = 13
    Caption = 'Raised'
  end
  object Label8: TLabel
    Left = 344
    Top = 224
    Width = 33
    Height = 13
    Caption = 'Raised'
  end
  object Bevel13: TBevel
    Left = 416
    Top = 192
    Width = 73
    Height = 73
    Shape = bsSpacer
  end
  object Label9: TLabel
    Left = 432
    Top = 224
    Width = 34
    Height = 13
    Caption = 'Spacer'
  end
  object Bevel14: TBevel
    Left = 0
    Top = 296
    Width = 510
    Height = 37
    Align = alBottom
    Style = bsRaised
  end
  object Label10: TLabel
    Left = 224
    Top = 280
    Width = 68
    Height = 13
    Caption = 'Docked Bevel'
  end
end
