using System.Reflection;
using System.Text.Json;

namespace WinFormsBinary.Net10;

internal static class SampleSmoke
{
    internal static void Run(string output)
    {
        Directory.CreateDirectory(output);
        using var main = new MainForm();
        using var dialog = new ExportOptionsDialog();
        T Field<T>(object owner, string name) => (T)owner.GetType().GetField(name, BindingFlags.Instance | BindingFlags.NonPublic).GetValue(owner);
        void Check(bool condition, string message) { if (!condition) throw new InvalidOperationException(message); }
        var languages = Field<ToolStripMenuItem>(main, "languageToolStripMenuItem");
        var availableCultures = SampleLanguages.Available().Select(culture => culture.Name).ToArray();
        Check(languages.DropDownItems.Cast<ToolStripMenuItem>().Select(item => (string)item.Tag).SequenceEqual(availableCultures), "Language menu must match usable translations.");
        Check(languages.DropDownItems.Cast<ToolStripMenuItem>().Count(item => item.Checked) == 1, "Exactly one active language is required.");
        var paper = Field<ComboBox>(main, "paperCombo");
        Check(paper.Items.Count == 4, "Paper collection must deserialize.");
        Check(Field<ComboBox>(main, "qualityCombo").Items.Count == 3, "Quality collection missing.");
        Check(Field<ComboBox>(main, "formatCombo").Items.Count == 3, "Format collection missing.");
        Check(Field<ComboBox>(main, "unitsCombo").Items.Count == 3, "Units collection missing.");
        Check(Field<CheckedListBox>(main, "notificationsList").Items.Count == 3, "Notifications missing.");
        var tree = Field<TreeView>(main, "sectionsTree");
        Check(tree.GetNodeCount(true) == 7, "Tree nodes must deserialize.");
        var list = Field<ListView>(main, "presetsList");
        Check(list.Groups.Count == 2 && list.Items.Count == 3 && list.Columns.Count == 3, "Grouped list must deserialize.");
        Check(list.Items.Cast<ListViewItem>().All(item => item.SubItems.Count == 3 && item.Group != null), "List subitems/groups missing.");
        Check(Field<ComboBox>(dialog, "exportFormatCombo").Items.Count == 3, "Dialog formats missing.");
        var combos = new Dictionary<string, ComboBox>
        {
            ["paper"] = paper,
            ["quality"] = Field<ComboBox>(main, "qualityCombo"),
            ["format"] = Field<ComboBox>(main, "formatCombo"),
            ["units"] = Field<ComboBox>(main, "unitsCombo"),
            ["exportFormat"] = Field<ComboBox>(dialog, "exportFormatCombo")
        };
        foreach (var entry in combos)
            Check(entry.Value.Items.Cast<object>().All(item => !string.IsNullOrWhiteSpace(item?.ToString())), $"Empty {entry.Key} combo item.");
        Check(list.Items.Cast<ListViewItem>().All(item => item.SubItems.Cast<ListViewItem.ListViewSubItem>().All(subitem => !string.IsNullOrWhiteSpace(subitem.Text))), "Empty profile list text.");
        Check(SampleResources.Object("SampleBanner") is Bitmap, "Bitmap resource missing.");
        Check(SampleResources.Content("export-guide.html").Contains("<html"), "Embedded HTML missing.");
        Check(SampleResources.PresetDescription.Length > 10, "Embedded XML missing.");
        main.Show();
        Check(paper.Text.Length > 0, "Paper selection must have visible text.");
        Check(Field<ComboBox>(main, "qualityCombo").Text.Length > 0, "Quality selection must have visible text.");
        var tabs = Field<TabControl>(main, "mainTabs");
        for (var i = 0; i < tabs.TabCount; i++)
        {
            tabs.SelectedIndex = i;
            Application.DoEvents();
            Capture(main, Path.Combine(output, "main-" + i + ".png"));
        }
        Field<Button>(main, "showMessageButton").PerformClick();
        Check(Field<Label>(main, "messageResultLabel").Text == SampleResources.Format("ExportSummaryFormat", 12, "sample.pdf"), "Formatted message failed.");
        Field<Button>(main, "showGuideButton").PerformClick();
        Check(Field<Label>(main, "messageResultLabel").Text.Contains(SampleResources.PresetDescription), "Guide action failed.");
        tabs.SelectedIndex = 0;
        Field<Button>(main, "saveProfileButton").PerformClick();
        Check(Field<Label>(main, "messageResultLabel").Text.Contains(SampleResources.Text("DefaultProfileName")), "Save profile action failed.");
        tabs.SelectedIndex = 1;
        list.Items[2].Selected = true;
        list.Select();
        Field<Button>(main, "applyPresetButton").PerformClick();
        Check(Field<ComboBox>(main, "formatCombo").SelectedIndex == 1 && Field<ComboBox>(main, "qualityCombo").SelectedIndex == 2, "Apply preset failed.");
        dialog.Show(main);
        Application.DoEvents();
        Capture(dialog, Path.Combine(output, "export.png"));
        var folder = Field<TextBox>(dialog, "folderTextBox");
        var export = Field<Button>(dialog, "exportButton");
        folder.Text = "";
        export.PerformClick();
        Check(Field<ErrorProvider>(dialog, "exportErrorProvider").GetError(folder) == SampleResources.Text("FolderRequired"), "Folder validation failed.");
        Capture(dialog, Path.Combine(output, "export-validation.png"));
        folder.Text = "Sample output";
        export.PerformClick();
        Check(Field<ErrorProvider>(dialog, "exportErrorProvider").GetError(folder) == "", "Validation should clear after correction.");
        Check(Field<Label>(dialog, "exportNoteLabel").Text == SampleResources.Format("ExportSummaryFormat", 12, "sample.pdf"), "Export action failed.");
        Field<Button>(dialog, "pageSetupButton").PerformClick();
        Check(dialog.DialogResult == DialogResult.Retry, "Page setup action failed.");
        File.WriteAllText(Path.Combine(output, "result.json"), JsonSerializer.Serialize(new
        {
            availableCultures,
            success = true,
            culture = System.Globalization.CultureInfo.CurrentUICulture.Name,
            paperText = paper.Text,
            guideText = SampleResources.PresetDescription,
            framework = System.Runtime.InteropServices.RuntimeInformation.FrameworkDescription,
            mainSize = main.ClientSize.ToString(), dialogSize = dialog.ClientSize.ToString(),
            resourceNames = typeof(MainForm).Assembly.GetManifestResourceNames(),
            trees = tree.GetNodeCount(true), listItems = list.Items.Count, listGroups = list.Groups.Count,
            comboItems = combos.ToDictionary(entry => entry.Key, entry => entry.Value.Items.Cast<object>().Select(item => item.ToString()).ToArray()),
            profileRows = list.Items.Cast<ListViewItem>().Select(item => item.SubItems.Cast<ListViewItem.ListViewSubItem>().Select(subitem => subitem.Text).ToArray()).ToArray()
        }, new JsonSerializerOptions { WriteIndented = true }));
        tabs.SelectedIndex = 0;
        Application.DoEvents();
        Capture(main, Path.Combine(output, "main-selected.png"));
        main.Close();
    }
    private static void Capture(Form form, string path)
    {
        using var bitmap = new Bitmap(form.Width, form.Height);
        form.DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
        bitmap.Save(path, System.Drawing.Imaging.ImageFormat.Png);
    }
}
