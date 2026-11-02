namespace WinFormsBinary.Net10
{
    partial class ExportOptionsDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ExportOptionsDialog));
            exportHeadingLabel = new Label();
            exportSettingsGroup = new GroupBox();
            exportFormatLabel = new Label();
            exportFormatCombo = new ComboBox();
            folderLabel = new Label();
            folderTextBox = new TextBox();
            embedFontsCheck = new CheckBox();
            preserveLinksCheck = new CheckBox();
            exportNoteLabel = new Label();
            closeButton = new Button();
            pageSetupButton = new Button();
            exportButton = new Button();
            exportToolTip = new ToolTip(components);
            exportErrorProvider = new ErrorProvider(components);
            openFolderCheck = new CheckBox();
            exportSettingsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)exportErrorProvider).BeginInit();
            SuspendLayout();
            // 
            // exportHeadingLabel
            // 
            resources.ApplyResources(exportHeadingLabel, "exportHeadingLabel");
            exportHeadingLabel.Name = "exportHeadingLabel";
            // 
            // exportSettingsGroup
            // 
            exportSettingsGroup.Controls.Add(exportFormatLabel);
            exportSettingsGroup.Controls.Add(exportFormatCombo);
            exportSettingsGroup.Controls.Add(folderLabel);
            exportSettingsGroup.Controls.Add(folderTextBox);
            exportSettingsGroup.Controls.Add(embedFontsCheck);
            exportSettingsGroup.Controls.Add(preserveLinksCheck);
            exportSettingsGroup.Controls.Add(openFolderCheck);
            resources.ApplyResources(exportSettingsGroup, "exportSettingsGroup");
            exportSettingsGroup.Name = "exportSettingsGroup";
            exportSettingsGroup.TabStop = false;
            // 
            // exportFormatLabel
            // 
            resources.ApplyResources(exportFormatLabel, "exportFormatLabel");
            exportFormatLabel.Name = "exportFormatLabel";
            // 
            // exportFormatCombo
            // 
            exportFormatCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            exportFormatCombo.Items.AddRange(new object[] { resources.GetString("exportFormatCombo.Items"), resources.GetString("exportFormatCombo.Items1"), resources.GetString("exportFormatCombo.Items2") });
            resources.ApplyResources(exportFormatCombo, "exportFormatCombo");
            exportFormatCombo.Name = "exportFormatCombo";
            // 
            // folderLabel
            // 
            resources.ApplyResources(folderLabel, "folderLabel");
            folderLabel.Name = "folderLabel";
            // 
            // folderTextBox
            // 
            resources.ApplyResources(folderTextBox, "folderTextBox");
            folderTextBox.Name = "folderTextBox";
            exportToolTip.SetToolTip(folderTextBox, resources.GetString("folderTextBox.ToolTip"));
            // 
            // embedFontsCheck
            // 
            resources.ApplyResources(embedFontsCheck, "embedFontsCheck");
            embedFontsCheck.Name = "embedFontsCheck";
            exportToolTip.SetToolTip(embedFontsCheck, resources.GetString("embedFontsCheck.ToolTip"));
            // 
            // preserveLinksCheck
            // 
            resources.ApplyResources(preserveLinksCheck, "preserveLinksCheck");
            preserveLinksCheck.Name = "preserveLinksCheck";
            // 
            // exportNoteLabel
            // 
            resources.ApplyResources(exportNoteLabel, "exportNoteLabel");
            exportNoteLabel.Name = "exportNoteLabel";
            // 
            // closeButton
            // 
            closeButton.DialogResult = DialogResult.Cancel;
            resources.ApplyResources(closeButton, "closeButton");
            closeButton.Name = "closeButton";
            // 
            // pageSetupButton
            // 
            resources.ApplyResources(pageSetupButton, "pageSetupButton");
            pageSetupButton.Name = "pageSetupButton";
            // 
            // exportButton
            // 
            resources.ApplyResources(exportButton, "exportButton");
            exportButton.Name = "exportButton";
            // 
            // exportErrorProvider
            // 
            exportErrorProvider.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            exportErrorProvider.ContainerControl = this;
            // 
            // openFolderCheck
            // 
            resources.ApplyResources(openFolderCheck, "openFolderCheck");
            openFolderCheck.Name = "openFolderCheck";
            exportToolTip.SetToolTip(openFolderCheck, resources.GetString("openFolderCheck.ToolTip"));
            // 
            // ExportOptionsDialog
            // 
            AcceptButton = exportButton;
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            CancelButton = closeButton;
            Controls.Add(exportHeadingLabel);
            Controls.Add(exportSettingsGroup);
            Controls.Add(exportNoteLabel);
            Controls.Add(closeButton);
            Controls.Add(pageSetupButton);
            Controls.Add(exportButton);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "ExportOptionsDialog";
            ShowInTaskbar = false;
            exportSettingsGroup.ResumeLayout(false);
            exportSettingsGroup.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)exportErrorProvider).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Label exportHeadingLabel;
        private GroupBox exportSettingsGroup;
        private Label exportFormatLabel;
        private ComboBox exportFormatCombo;
        private Label folderLabel;
        private TextBox folderTextBox;
        private CheckBox embedFontsCheck;
        private CheckBox preserveLinksCheck;
        private Label exportNoteLabel;
        private Button closeButton;
        private Button pageSetupButton;
        private Button exportButton;
        private ToolTip exportToolTip;
        private ErrorProvider exportErrorProvider;
        private CheckBox openFolderCheck;
    }
}