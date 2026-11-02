namespace WinFormsBinary.Net10;

public partial class ExportOptionsDialog : Form
{
    public ExportOptionsDialog() : this(0) { }
    public ExportOptionsDialog(int format)
    {
        InitializeComponent();
        exportFormatCombo.SelectedIndex = Math.Clamp(format, 0, exportFormatCombo.Items.Count - 1);
        exportButton.Click += (_, _) => TryExport();
        folderTextBox.TextChanged += (_, _) => exportErrorProvider.SetError(folderTextBox, string.Empty);
        pageSetupButton.Click += (_, _) => { DialogResult = DialogResult.Retry; Close(); };
    }

    private bool TryExport()
    {
        if (string.IsNullOrWhiteSpace(folderTextBox.Text))
        {
            exportErrorProvider.SetError(folderTextBox, SampleResources.Text("FolderRequired"));
            folderTextBox.Focus();
            return false;
        }
        exportErrorProvider.SetError(folderTextBox, string.Empty);
        var extension = exportFormatCombo.SelectedIndex switch { 1 => "png", 2 => "txt", _ => "pdf" };
        exportNoteLabel.Text = openFolderCheck.Checked ? SampleResources.Text("PostExportHint")
            : SampleResources.Format("ExportSummaryFormat", 12, "sample." + extension, SampleResources.Text("DefaultProfileName"));
        return true;
    }
}
