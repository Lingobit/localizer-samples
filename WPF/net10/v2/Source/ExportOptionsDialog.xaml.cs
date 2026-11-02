using System.Windows;
namespace WpfLocalization
{
    public partial class ExportOptionsDialog : Window
    {
        public ExportOptionsDialog() { InitializeComponent(); }
        private void CloseDialog(object sender, RoutedEventArgs e) { Close(); }
        private void Export(object sender, RoutedEventArgs e) { ResultText.Text = Texts.ExportSummary(); }
        private void PageSetup(object sender, RoutedEventArgs e) { if (Owner is MainWindow main) main.SelectView("print"); Close(); }
    }
}