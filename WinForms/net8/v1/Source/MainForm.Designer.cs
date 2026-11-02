namespace WinFormsBinary.Net10
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            previewToolStripMenuItem = new ToolStripMenuItem();
            exportToolStripMenuItem = new ToolStripMenuItem();
            saveprofileToolStripMenuItem = new ToolStripMenuItem();
            toolStripSeparator1 = new ToolStripSeparator();
            exitToolStripMenuItem = new ToolStripMenuItem();
            languageToolStripMenuItem = new ToolStripMenuItem();
            englishMenuItem = new ToolStripMenuItem();
            germanMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            exportguideToolStripMenuItem = new ToolStripMenuItem();
            toolStrip1 = new ToolStrip();
            previewToolButton = new ToolStripButton();
            exportToolButton = new ToolStripDropDownButton();
            exportPdfItem = new ToolStripMenuItem();
            exportImageItem = new ToolStripMenuItem();
            toolStripSeparator2 = new ToolStripSeparator();
            saveProfileToolButton = new ToolStripButton();
            readyStatus = new ToolStripButton();
            sampleStatus = new ToolStripButton();
            statusStrip1 = new StatusStrip();
            readyStatusLabel = new ToolStripStatusLabel();
            sampleStatusLabel = new ToolStripStatusLabel();
            mainTabs = new TabControl();
            printTab = new TabPage();
            pageSetupGroup = new GroupBox();
            copiesNumeric = new NumericUpDown();
            copiesLabel = new Label();
            paperCombo = new ComboBox();
            label1 = new Label();
            orientationLabel = new Label();
            portraitRadio = new RadioButton();
            landscapeRadio = new RadioButton();
            duplexCheck = new CheckBox();
            completionSoundCheck = new CheckBox();
            outputGroup = new GroupBox();
            outputLayout = new TableLayoutPanel();
            qualityLabel = new Label();
            qualityCombo = new ComboBox();
            formatLabel = new Label();
            formatCombo = new ComboBox();
            unitsLabel = new Label();
            unitsCombo = new ComboBox();
            includePropertiesCheck = new CheckBox();
            exportGuideLink = new LinkLabel();
            saveProfileButton = new Button();
            exportOptionsButton = new Button();
            profilesTab = new TabPage();
            sectionsTree = new TreeView();
            presetsLabel = new Label();
            presetsList = new ListView();
            formatColumn = new ColumnHeader();
            qualityColumn = new ColumnHeader();
            descriptionColumn = new ColumnHeader();
            presetContextMenu = new ContextMenuStrip(components);
            applyPresetContextItem = new ToolStripMenuItem();
            presetContextSeparator = new ToolStripSeparator();
            copyDescriptionContextItem = new ToolStripMenuItem();
            notificationsLabel = new Label();
            notificationsList = new CheckedListBox();
            profileActions = new FlowLayoutPanel();
            applyPresetButton = new Button();
            resetPresetButton = new Button();
            resourcesTab = new TabPage();
            sampleIntroLabel = new Label();
            messageResultLabel = new Label();
            showMessageButton = new Button();
            showGuideButton = new Button();
            mainToolTip = new ToolTip(components);
            sectionImages = new ImageList(components);
            menuStrip1.SuspendLayout();
            toolStrip1.SuspendLayout();
            statusStrip1.SuspendLayout();
            mainTabs.SuspendLayout();
            printTab.SuspendLayout();
            pageSetupGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)copiesNumeric).BeginInit();
            outputGroup.SuspendLayout();
            outputLayout.SuspendLayout();
            profilesTab.SuspendLayout();
            presetContextMenu.SuspendLayout();
            profileActions.SuspendLayout();
            resourcesTab.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, languageToolStripMenuItem, helpToolStripMenuItem });
            resources.ApplyResources(menuStrip1, "menuStrip1");
            menuStrip1.Name = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { previewToolStripMenuItem, exportToolStripMenuItem, saveprofileToolStripMenuItem, toolStripSeparator1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            resources.ApplyResources(fileToolStripMenuItem, "fileToolStripMenuItem");
            // 
            // previewToolStripMenuItem
            // 
            previewToolStripMenuItem.Name = "previewToolStripMenuItem";
            resources.ApplyResources(previewToolStripMenuItem, "previewToolStripMenuItem");
            // 
            // exportToolStripMenuItem
            // 
            exportToolStripMenuItem.Name = "exportToolStripMenuItem";
            resources.ApplyResources(exportToolStripMenuItem, "exportToolStripMenuItem");
            // 
            // saveprofileToolStripMenuItem
            // 
            saveprofileToolStripMenuItem.Name = "saveprofileToolStripMenuItem";
            resources.ApplyResources(saveprofileToolStripMenuItem, "saveprofileToolStripMenuItem");
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(toolStripSeparator1, "toolStripSeparator1");
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            resources.ApplyResources(exitToolStripMenuItem, "exitToolStripMenuItem");
            // 
            // languageToolStripMenuItem
            // 
            languageToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { englishMenuItem, germanMenuItem });
            languageToolStripMenuItem.Name = "languageToolStripMenuItem";
            resources.ApplyResources(languageToolStripMenuItem, "languageToolStripMenuItem");
            // 
            // englishMenuItem
            // 
            englishMenuItem.Checked = true;
            englishMenuItem.CheckState = CheckState.Checked;
            englishMenuItem.Name = "englishMenuItem";
            resources.ApplyResources(englishMenuItem, "englishMenuItem");
            // 
            // germanMenuItem
            // 
            germanMenuItem.Name = "germanMenuItem";
            resources.ApplyResources(germanMenuItem, "germanMenuItem");
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exportguideToolStripMenuItem });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            resources.ApplyResources(helpToolStripMenuItem, "helpToolStripMenuItem");
            // 
            // exportguideToolStripMenuItem
            // 
            exportguideToolStripMenuItem.Name = "exportguideToolStripMenuItem";
            resources.ApplyResources(exportguideToolStripMenuItem, "exportguideToolStripMenuItem");
            // 
            // toolStrip1
            // 
            toolStrip1.GripStyle = ToolStripGripStyle.Hidden;
            toolStrip1.ImageScalingSize = new Size(20, 20);
            toolStrip1.Items.AddRange(new ToolStripItem[] { previewToolButton, exportToolButton, toolStripSeparator2, saveProfileToolButton, readyStatus, sampleStatus });
            resources.ApplyResources(toolStrip1, "toolStrip1");
            toolStrip1.Name = "toolStrip1";
            // 
            // previewToolButton
            // 
            previewToolButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(previewToolButton, "previewToolButton");
            previewToolButton.Name = "previewToolButton";
            // 
            // exportToolButton
            // 
            exportToolButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            exportToolButton.DropDownItems.AddRange(new ToolStripItem[] { exportPdfItem, exportImageItem });
            resources.ApplyResources(exportToolButton, "exportToolButton");
            exportToolButton.Name = "exportToolButton";
            // 
            // exportPdfItem
            // 
            exportPdfItem.Name = "exportPdfItem";
            resources.ApplyResources(exportPdfItem, "exportPdfItem");
            // 
            // exportImageItem
            // 
            exportImageItem.Name = "exportImageItem";
            resources.ApplyResources(exportImageItem, "exportImageItem");
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(toolStripSeparator2, "toolStripSeparator2");
            // 
            // saveProfileToolButton
            // 
            saveProfileToolButton.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(saveProfileToolButton, "saveProfileToolButton");
            saveProfileToolButton.Name = "saveProfileToolButton";
            // 
            // readyStatus
            // 
            readyStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(readyStatus, "readyStatus");
            readyStatus.Name = "readyStatus";
            // 
            // sampleStatus
            // 
            sampleStatus.DisplayStyle = ToolStripItemDisplayStyle.Text;
            resources.ApplyResources(sampleStatus, "sampleStatus");
            sampleStatus.Name = "sampleStatus";
            // 
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new Size(20, 20);
            statusStrip1.Items.AddRange(new ToolStripItem[] { readyStatusLabel, sampleStatusLabel });
            resources.ApplyResources(statusStrip1, "statusStrip1");
            statusStrip1.Name = "statusStrip1";
            // 
            // readyStatusLabel
            // 
            readyStatusLabel.Name = "readyStatusLabel";
            resources.ApplyResources(readyStatusLabel, "readyStatusLabel");
            readyStatusLabel.Spring = true;
            // 
            // sampleStatusLabel
            // 
            sampleStatusLabel.Name = "sampleStatusLabel";
            resources.ApplyResources(sampleStatusLabel, "sampleStatusLabel");
            // 
            // mainTabs
            // 
            mainTabs.Controls.Add(printTab);
            mainTabs.Controls.Add(profilesTab);
            mainTabs.Controls.Add(resourcesTab);
            resources.ApplyResources(mainTabs, "mainTabs");
            mainTabs.Name = "mainTabs";
            mainTabs.SelectedIndex = 0;
            // 
            // printTab
            // 
            printTab.Controls.Add(pageSetupGroup);
            printTab.Controls.Add(outputGroup);
            printTab.Controls.Add(exportGuideLink);
            printTab.Controls.Add(saveProfileButton);
            printTab.Controls.Add(exportOptionsButton);
            resources.ApplyResources(printTab, "printTab");
            printTab.Name = "printTab";
            printTab.UseVisualStyleBackColor = true;
            // 
            // pageSetupGroup
            // 
            pageSetupGroup.Controls.Add(copiesNumeric);
            pageSetupGroup.Controls.Add(copiesLabel);
            pageSetupGroup.Controls.Add(paperCombo);
            pageSetupGroup.Controls.Add(label1);
            pageSetupGroup.Controls.Add(orientationLabel);
            pageSetupGroup.Controls.Add(portraitRadio);
            pageSetupGroup.Controls.Add(landscapeRadio);
            pageSetupGroup.Controls.Add(duplexCheck);
            pageSetupGroup.Controls.Add(completionSoundCheck);
            resources.ApplyResources(pageSetupGroup, "pageSetupGroup");
            pageSetupGroup.Name = "pageSetupGroup";
            pageSetupGroup.TabStop = false;
            // 
            // copiesNumeric
            // 
            resources.ApplyResources(copiesNumeric, "copiesNumeric");
            copiesNumeric.Maximum = new decimal(new int[] { 99, 0, 0, 0 });
            copiesNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            copiesNumeric.Name = "copiesNumeric";
            mainToolTip.SetToolTip(copiesNumeric, resources.GetString("copiesNumeric.ToolTip"));
            copiesNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // copiesLabel
            // 
            resources.ApplyResources(copiesLabel, "copiesLabel");
            copiesLabel.Name = "copiesLabel";
            // 
            // paperCombo
            // 
            paperCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            paperCombo.FormattingEnabled = true;
            paperCombo.Items.AddRange(new object[] { resources.GetString("paperCombo.Items"), resources.GetString("paperCombo.Items1"), resources.GetString("paperCombo.Items2"), resources.GetString("paperCombo.Items3") });
            resources.ApplyResources(paperCombo, "paperCombo");
            paperCombo.Name = "paperCombo";
            // 
            // label1
            // 
            resources.ApplyResources(label1, "label1");
            label1.Name = "label1";
            // 
            // orientationLabel
            // 
            resources.ApplyResources(orientationLabel, "orientationLabel");
            orientationLabel.Name = "orientationLabel";
            // 
            // portraitRadio
            // 
            portraitRadio.Checked = true;
            resources.ApplyResources(portraitRadio, "portraitRadio");
            portraitRadio.Name = "portraitRadio";
            portraitRadio.TabStop = true;
            // 
            // landscapeRadio
            // 
            resources.ApplyResources(landscapeRadio, "landscapeRadio");
            landscapeRadio.Name = "landscapeRadio";
            // 
            // duplexCheck
            // 
            resources.ApplyResources(duplexCheck, "duplexCheck");
            duplexCheck.Name = "duplexCheck";
            // 
            // completionSoundCheck
            // 
            resources.ApplyResources(completionSoundCheck, "completionSoundCheck");
            completionSoundCheck.Name = "completionSoundCheck";
            // 
            // outputGroup
            // 
            outputGroup.Controls.Add(outputLayout);
            outputGroup.Controls.Add(includePropertiesCheck);
            resources.ApplyResources(outputGroup, "outputGroup");
            outputGroup.Name = "outputGroup";
            outputGroup.TabStop = false;
            // 
            // outputLayout
            // 
            resources.ApplyResources(outputLayout, "outputLayout");
            outputLayout.Controls.Add(qualityLabel, 0, 0);
            outputLayout.Controls.Add(qualityCombo, 1, 0);
            outputLayout.Controls.Add(formatLabel, 0, 1);
            outputLayout.Controls.Add(formatCombo, 1, 1);
            outputLayout.Controls.Add(unitsLabel, 0, 2);
            outputLayout.Controls.Add(unitsCombo, 1, 2);
            outputLayout.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            outputLayout.Name = "outputLayout";
            // 
            // qualityLabel
            // 
            resources.ApplyResources(qualityLabel, "qualityLabel");
            qualityLabel.Name = "qualityLabel";
            // 
            // qualityCombo
            // 
            resources.ApplyResources(qualityCombo, "qualityCombo");
            qualityCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            qualityCombo.Items.AddRange(new object[] { resources.GetString("qualityCombo.Items"), resources.GetString("qualityCombo.Items1"), resources.GetString("qualityCombo.Items2") });
            qualityCombo.Name = "qualityCombo";
            // 
            // formatLabel
            // 
            resources.ApplyResources(formatLabel, "formatLabel");
            formatLabel.Name = "formatLabel";
            // 
            // formatCombo
            // 
            resources.ApplyResources(formatCombo, "formatCombo");
            formatCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            formatCombo.Items.AddRange(new object[] { resources.GetString("formatCombo.Items"), resources.GetString("formatCombo.Items1"), resources.GetString("formatCombo.Items2") });
            formatCombo.Name = "formatCombo";
            // 
            // unitsLabel
            // 
            resources.ApplyResources(unitsLabel, "unitsLabel");
            unitsLabel.Name = "unitsLabel";
            // 
            // unitsCombo
            // 
            resources.ApplyResources(unitsCombo, "unitsCombo");
            unitsCombo.DropDownStyle = ComboBoxStyle.DropDownList;
            unitsCombo.Items.AddRange(new object[] { resources.GetString("unitsCombo.Items"), resources.GetString("unitsCombo.Items1"), resources.GetString("unitsCombo.Items2") });
            unitsCombo.Name = "unitsCombo";
            // 
            // includePropertiesCheck
            // 
            resources.ApplyResources(includePropertiesCheck, "includePropertiesCheck");
            includePropertiesCheck.Name = "includePropertiesCheck";
            mainToolTip.SetToolTip(includePropertiesCheck, resources.GetString("includePropertiesCheck.ToolTip"));
            // 
            // exportGuideLink
            // 
            resources.ApplyResources(exportGuideLink, "exportGuideLink");
            exportGuideLink.Name = "exportGuideLink";
            exportGuideLink.TabStop = true;
            exportGuideLink.UseCompatibleTextRendering = true;
            // 
            // saveProfileButton
            // 
            resources.ApplyResources(saveProfileButton, "saveProfileButton");
            saveProfileButton.Name = "saveProfileButton";
            // 
            // exportOptionsButton
            // 
            resources.ApplyResources(exportOptionsButton, "exportOptionsButton");
            exportOptionsButton.Name = "exportOptionsButton";
            // 
            // profilesTab
            // 
            profilesTab.Controls.Add(sectionsTree);
            profilesTab.Controls.Add(presetsLabel);
            profilesTab.Controls.Add(presetsList);
            profilesTab.Controls.Add(notificationsLabel);
            profilesTab.Controls.Add(notificationsList);
            profilesTab.Controls.Add(profileActions);
            resources.ApplyResources(profilesTab, "profilesTab");
            profilesTab.Name = "profilesTab";
            profilesTab.UseVisualStyleBackColor = true;
            // 
            // sectionsTree
            // 
            sectionsTree.HideSelection = false;
            resources.ApplyResources(sectionsTree, "sectionsTree");
            sectionsTree.Name = "sectionsTree";
            sectionsTree.Nodes.AddRange(new TreeNode[] { (TreeNode)resources.GetObject("sectionsTree.Nodes"), (TreeNode)resources.GetObject("sectionsTree.Nodes1"), (TreeNode)resources.GetObject("sectionsTree.Nodes2") });
            // 
            // presetsLabel
            // 
            resources.ApplyResources(presetsLabel, "presetsLabel");
            presetsLabel.Name = "presetsLabel";
            // 
            // presetsList
            // 
            presetsList.Columns.AddRange(new ColumnHeader[] { formatColumn, qualityColumn, descriptionColumn });
            presetsList.ContextMenuStrip = presetContextMenu;
            presetsList.FullRowSelect = true;
            presetsList.GridLines = true;
            presetsList.Groups.AddRange(new ListViewGroup[] { (ListViewGroup)resources.GetObject("presetsList.Groups"), (ListViewGroup)resources.GetObject("presetsList.Groups1") });
            presetsList.Items.AddRange(new ListViewItem[] { (ListViewItem)resources.GetObject("presetsList.Items"), (ListViewItem)resources.GetObject("presetsList.Items1"), (ListViewItem)resources.GetObject("presetsList.Items2") });
            resources.ApplyResources(presetsList, "presetsList");
            presetsList.Name = "presetsList";
            presetsList.UseCompatibleStateImageBehavior = false;
            presetsList.View = View.Details;
            // 
            // formatColumn
            // 
            resources.ApplyResources(formatColumn, "formatColumn");
            // 
            // qualityColumn
            // 
            resources.ApplyResources(qualityColumn, "qualityColumn");
            // 
            // descriptionColumn
            // 
            resources.ApplyResources(descriptionColumn, "descriptionColumn");
            // 
            // presetContextMenu
            // 
            presetContextMenu.ImageScalingSize = new Size(20, 20);
            presetContextMenu.Items.AddRange(new ToolStripItem[] { applyPresetContextItem, presetContextSeparator, copyDescriptionContextItem });
            presetContextMenu.Name = "presetContextMenu";
            resources.ApplyResources(presetContextMenu, "presetContextMenu");
            // 
            // applyPresetContextItem
            // 
            applyPresetContextItem.Name = "applyPresetContextItem";
            resources.ApplyResources(applyPresetContextItem, "applyPresetContextItem");
            // 
            // presetContextSeparator
            // 
            presetContextSeparator.Name = "presetContextSeparator";
            resources.ApplyResources(presetContextSeparator, "presetContextSeparator");
            // 
            // copyDescriptionContextItem
            // 
            copyDescriptionContextItem.Name = "copyDescriptionContextItem";
            resources.ApplyResources(copyDescriptionContextItem, "copyDescriptionContextItem");
            // 
            // notificationsLabel
            // 
            resources.ApplyResources(notificationsLabel, "notificationsLabel");
            notificationsLabel.Name = "notificationsLabel";
            // 
            // notificationsList
            // 
            notificationsList.CheckOnClick = true;
            notificationsList.Items.AddRange(new object[] { resources.GetString("notificationsList.Items"), resources.GetString("notificationsList.Items1"), resources.GetString("notificationsList.Items2") });
            resources.ApplyResources(notificationsList, "notificationsList");
            notificationsList.Name = "notificationsList";
            // 
            // profileActions
            // 
            profileActions.Controls.Add(applyPresetButton);
            profileActions.Controls.Add(resetPresetButton);
            resources.ApplyResources(profileActions, "profileActions");
            profileActions.Name = "profileActions";
            // 
            // applyPresetButton
            // 
            resources.ApplyResources(applyPresetButton, "applyPresetButton");
            applyPresetButton.Name = "applyPresetButton";
            // 
            // resetPresetButton
            // 
            resources.ApplyResources(resetPresetButton, "resetPresetButton");
            resetPresetButton.Name = "resetPresetButton";
            // 
            // resourcesTab
            // 
            resourcesTab.Controls.Add(sampleIntroLabel);
            resourcesTab.Controls.Add(messageResultLabel);
            resourcesTab.Controls.Add(showMessageButton);
            resourcesTab.Controls.Add(showGuideButton);
            resources.ApplyResources(resourcesTab, "resourcesTab");
            resourcesTab.Name = "resourcesTab";
            resourcesTab.UseVisualStyleBackColor = true;
            // 
            // sampleIntroLabel
            // 
            resources.ApplyResources(sampleIntroLabel, "sampleIntroLabel");
            sampleIntroLabel.Name = "sampleIntroLabel";
            // 
            // messageResultLabel
            // 
            resources.ApplyResources(messageResultLabel, "messageResultLabel");
            messageResultLabel.Name = "messageResultLabel";
            // 
            // showMessageButton
            // 
            resources.ApplyResources(showMessageButton, "showMessageButton");
            showMessageButton.Name = "showMessageButton";
            // 
            // showGuideButton
            // 
            resources.ApplyResources(showGuideButton, "showGuideButton");
            showGuideButton.Name = "showGuideButton";
            // 
            // sectionImages
            // 
            sectionImages.ColorDepth = ColorDepth.Depth32Bit;
            resources.ApplyResources(sectionImages, "sectionImages");
            sectionImages.TransparentColor = Color.Transparent;
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Dpi;
            Controls.Add(mainTabs);
            Controls.Add(statusStrip1);
            Controls.Add(toolStrip1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            Name = "MainForm";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            mainTabs.ResumeLayout(false);
            printTab.ResumeLayout(false);
            pageSetupGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)copiesNumeric).EndInit();
            outputGroup.ResumeLayout(false);
            outputLayout.ResumeLayout(false);
            profilesTab.ResumeLayout(false);
            presetContextMenu.ResumeLayout(false);
            profileActions.ResumeLayout(false);
            resourcesTab.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStrip toolStrip1;
        private StatusStrip statusStrip1;
        private TabControl mainTabs;
        private TabPage printTab;
        private TabPage profilesTab;
        private TabPage resourcesTab;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem previewToolStripMenuItem;
        private ToolStripMenuItem exportToolStripMenuItem;
        private ToolStripMenuItem saveprofileToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem languageToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem exportguideToolStripMenuItem;
        private ToolStripDropDownButton exportToolButton;
        private ToolStripMenuItem exportPdfItem;
        private ToolStripMenuItem exportImageItem;
        private ToolStripButton previewToolButton;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton saveProfileToolButton;
        private ToolStripButton readyStatus;
        private ToolStripButton sampleStatus;
        private GroupBox pageSetupGroup;
        private Label copiesLabel;
        private ComboBox paperCombo;
        private Label label1;
        private NumericUpDown copiesNumeric;
        private Label orientationLabel;
        private RadioButton portraitRadio;
        private RadioButton landscapeRadio;
        private CheckBox duplexCheck;
        private CheckBox completionSoundCheck;
        private GroupBox outputGroup;
        private TableLayoutPanel outputLayout;
        private Label qualityLabel;
        private ComboBox qualityCombo;
        private Label formatLabel;
        private ComboBox formatCombo;
        private Label unitsLabel;
        private ComboBox unitsCombo;
        private CheckBox includePropertiesCheck;
        private LinkLabel exportGuideLink;
        private Button saveProfileButton;
        private Button exportOptionsButton;
        private TreeView sectionsTree;
        private Label presetsLabel;
        private ListView presetsList;
        private ContextMenuStrip presetContextMenu;
        private Label notificationsLabel;
        private CheckedListBox notificationsList;
        private FlowLayoutPanel profileActions;
        private Button applyPresetButton;
        private Button resetPresetButton;
        private Label sampleIntroLabel;
        private Label messageResultLabel;
        private Button showMessageButton;
        private Button showGuideButton;
        private ToolTip mainToolTip;
        private ImageList sectionImages;
        private ToolStripMenuItem englishMenuItem;
        private ToolStripMenuItem germanMenuItem;
        private ToolStripStatusLabel readyStatusLabel;
        private ToolStripStatusLabel sampleStatusLabel;
        private ToolStripMenuItem applyPresetContextItem;
        private ToolStripSeparator presetContextSeparator;
        private ToolStripMenuItem copyDescriptionContextItem;
        private ColumnHeader formatColumn;
        private ColumnHeader qualityColumn;
        private ColumnHeader descriptionColumn;
    }
}
