using System;
using System.Linq;
using System.IO;
using System.Diagnostics;
using System.Xml.Linq;
using System.Windows;
using System.Windows.Controls;
namespace WpfLocalization
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RefreshLanguages();
            ResourceMessage.Text = Texts.ExportSummary();
            GuideText.Text = Texts.Guide();
            PresetDescription.Text = Texts.PresetDescription();
        }
        internal void SelectView(string view)
        {
            MainTabs.SelectedIndex = view == "profiles" ? 1 : view == "resources" ? 2 : 0;
        }
        internal string PresetNames() { return string.Join(" | ", PresetsList.Items.Cast<Preset>().Select(p => p.DisplayName)); }
        internal void CheckResources()
        {
            if (string.IsNullOrEmpty(Texts.Guide()) || string.IsNullOrEmpty(Texts.PresetDescription())) throw new InvalidOperationException("Missing embedded HTML/XML content.");
            if (PresetsList.Items.Count != (Texts.Get("SampleVersion") == "2" ? 4 : 3)) throw new InvalidOperationException("Missing preset rows.");
            if (System.Globalization.CultureInfo.GetCultureInfo(App.CultureName).TwoLetterISOLanguageName == "de" && PresetNames().Contains("Everyday sharing")) throw new InvalidOperationException("Untranslated preset data.");
            if (TryFindResource("AccentBrush") == null) throw new InvalidOperationException("Missing dictionary resource.");
            string directory = Path.Combine(Path.GetTempPath(), "Lingobit-WpfSample-check-" + Guid.NewGuid().ToString("N"));
            try
            {
                var html = XDocument.Load(Texts.SaveContent("export-guide.html", directory));
                var xml = XDocument.Load(Texts.SaveContent("export-presets.xml", directory));
                if (!Texts.Guide().Contains(html.Descendants("h1").Single().Value) ||
                    xml.Root.Element("preset").Attribute("description").Value != Texts.PresetDescription())
                    throw new InvalidOperationException("Exported documents differ from displayed embedded resources.");
            }
            finally { if (Directory.Exists(directory)) Directory.Delete(directory, true); }
            if (!App.Qa && Texts.ExportSummary() == Texts.Get("InvalidFormatMessage")) throw new InvalidOperationException("Invalid reference format.");
        }
        private void OpenDocument(string file)
        {
            try
            {
                string directory = Path.Combine(Path.GetTempPath(), "Lingobit-WpfSample", Guid.NewGuid().ToString("N"));
                string path = Texts.SaveContent(file, directory);
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            catch (Exception error)
            {
                MessageBox.Show(this, error.Message, Title, MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void OpenHtml(object sender, RoutedEventArgs e) { OpenDocument("export-guide.html"); }
        private void OpenXml(object sender, RoutedEventArgs e) { OpenDocument("export-presets.xml"); }
        private void Export(object sender, RoutedEventArgs e) { new ExportOptionsDialog { Owner = this }.ShowDialog(); }
        private void SaveProfile(object sender, RoutedEventArgs e) { ResourceMessage.Text = string.Format(Texts.Get("ProfileSavedFormat"), Texts.Get("StandardProfile")); SelectView("resources"); }
        private void ShowMessage(object sender, RoutedEventArgs e) { ResourceMessage.Text = Texts.ExportSummary(); }
        private void ShowGuide(object sender, RoutedEventArgs e) { SelectView("resources"); }
        private void CloseSample(object sender, RoutedEventArgs e) { Close(); }
        internal void RefreshLanguages()
        {
            LanguageMenu.Items.Clear();
            foreach (var culture in SampleLanguages.Available())
            {
                var item = new MenuItem { Header = culture.Name == "en-US" ? "English" : culture.TwoLetterISOLanguageName == "de" ? "Deutsch" : culture.NativeName,
                    Tag = culture.Name, IsCheckable = true, IsChecked = culture.Name == App.CultureName };
                item.Click += (sender, e) => App.Restart((string)((MenuItem)sender).Tag);
                LanguageMenu.Items.Add(item);
            }
        }
        private void RefreshLanguages(object sender, RoutedEventArgs e)
        {
            if (e.OriginalSource == LanguageMenu) RefreshLanguages();
        }
        internal string[] LanguageChoices() => LanguageMenu.Items.Cast<MenuItem>().Select(item => (string)item.Tag).ToArray();
        private void English(object sender, RoutedEventArgs e) { App.Restart("en-US"); }
        private void German(object sender, RoutedEventArgs e) { App.Restart("de"); }
        private void Preview(object sender, RoutedEventArgs e) { ResourceMessage.Text = Texts.ExportSummary(); SelectView("resources"); }
    }
}