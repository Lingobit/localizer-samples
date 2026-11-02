using System.Globalization;

namespace WinFormsBinary.Net10;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();
        // Keep runtime handlers outside InitializeComponent, which Full preview replays.
        previewToolButton.Click += toolStripButton1_Click;
        ResetSettings();
        sectionsTree.ExpandAll();
        notificationsList.SetItemChecked(0, true);
        previewToolStripMenuItem.Click += (_, _) => ShowPreview();
        exportToolStripMenuItem.Click += (_, _) => OpenExport();
        exportOptionsButton.Click += (_, _) => OpenExport();
        exportPdfItem.Click += (_, _) => OpenExport(0);
        exportImageItem.Click += (_, _) => OpenExport(1);
        saveProfileButton.Click += (_, _) => SaveProfile();
        saveProfileToolButton.Click += (_, _) => SaveProfile();
        saveprofileToolStripMenuItem.Click += (_, _) => SaveProfile();
        exitToolStripMenuItem.Click += (_, _) => Close();
        exportguideToolStripMenuItem.Click += (_, _) => ShowGuide();
        exportGuideLink.LinkClicked += (_, _) => ShowGuide();
        showGuideButton.Click += (_, _) => ShowGuide();
        showMessageButton.Click += (_, _) => ShowPreview();
        applyPresetButton.Click += (_, _) => ApplyPreset();
        applyPresetContextItem.Click += (_, _) => ApplyPreset();
        presetsList.DoubleClick += (_, _) => ApplyPreset();
        resetPresetButton.Click += (_, _) => ResetSettings();
        copyDescriptionContextItem.Click += (_, _) =>
        {
            if (presetsList.SelectedItems.Count > 0)
                Clipboard.SetText(presetsList.SelectedItems[0].SubItems[2].Text);
        };
        languageToolStripMenuItem.DropDownOpening += (_, _) => RefreshLanguages();
        languageToolStripMenuItem.DropDownItemClicked += (_, e) => SwitchLanguage((string)e.ClickedItem.Tag);
        RefreshLanguages();
    }

    private void toolStripButton1_Click(object sender, EventArgs e) => ShowPreview();

    private void ResetSettings()
    {
        paperCombo.SelectedIndex = 0;
        qualityCombo.SelectedIndex = 1;
        formatCombo.SelectedIndex = 0;
        unitsCombo.SelectedIndex = 0;
        copiesNumeric.Value = 2;
        portraitRadio.Checked = true;
        duplexCheck.Checked = false;
        collateCheck.Checked = true;
        includePropertiesCheck.Checked = true;
    }

    private void ShowPreview() => ShowResult(SampleResources.Format("ExportSummaryFormat", 12, "sample.pdf", SampleResources.Text("DefaultProfileName")));

    private void SaveProfile()
    {
        var name = presetsList.SelectedItems.Count > 0 ? presetsList.SelectedItems[0].SubItems[2].Text
            : SampleResources.Text("DefaultProfileName");
        ShowResult(SampleResources.Format("ExportProfileSavedFormat", name));
    }

    private void ShowResult(string text)
    {
        messageResultLabel.Text = text;
        readyStatusLabel.Text = SampleResources.Text("Ready");
        mainTabs.SelectedTab = resourcesTab;
    }

    private void ShowGuide()
    {
        // Both documents are embedded in the PE; no browser or external files are needed.
        var html = SampleResources.Content("export-guide.html");
        var document = System.Xml.Linq.XDocument.Parse(html);
        ShowResult(document.Descendants("p").First().Value + "\n" + SampleResources.PresetDescription);
    }

    private void ApplyPreset()
    {
        if (presetsList.SelectedItems.Count == 0) return;
        var index = presetsList.SelectedItems[0].Index;
        formatCombo.SelectedIndex = index == 2 ? 1 : 0;
        qualityCombo.SelectedIndex = index == 0 ? 1 : 2;
        mainTabs.SelectedTab = printTab;
    }

    private void OpenExport(int? format = null)
    {
        using var dialog = new ExportOptionsDialog(format ?? formatCombo.SelectedIndex);
        if (dialog.ShowDialog(this) == DialogResult.Retry) mainTabs.SelectedTab = printTab;
    }

    private void RefreshLanguages()
    {
        foreach (var item in languageToolStripMenuItem.DropDownItems.OfType<ToolStripMenuItem>().ToArray())
            if (item != englishMenuItem && item != germanMenuItem) item.Dispose();
        languageToolStripMenuItem.DropDownItems.Clear();
        foreach (var culture in SampleLanguages.Available())
        {
            var item = culture.Name == "en-US" ? englishMenuItem : culture.Name == "de" ? germanMenuItem
                : new ToolStripMenuItem(culture.NativeName) { Name = "language_" + culture.Name };
            item.Tag = culture.Name;
            item.Checked = culture.Name == CultureInfo.CurrentUICulture.Name;
            languageToolStripMenuItem.DropDownItems.Add(item);
        }
    }
    private void SwitchLanguage(string culture)
    {
        culture = SampleLanguages.Resolve(culture);
        if (CultureInfo.CurrentUICulture.Name == culture) return;
        Program.RequestedCulture = culture;
        Close();
    }
}
