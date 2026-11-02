using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Threading;
using System.Windows;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace WpfLocalization
{
    public partial class App : Application
    {
        internal static bool Qa;
        internal static string CultureName = "en-US";
        private void OnStartup(object sender, StartupEventArgs e)
        {
            string smoke = null;
            string view = "print";
            for (int i = 0; i < e.Args.Length; i++)
            {
                if (e.Args[i] == "--culture" && i + 1 < e.Args.Length) CultureName = e.Args[++i];
                else if (e.Args[i] == "--smoke" && i + 1 < e.Args.Length) smoke = Path.GetFullPath(e.Args[++i]);
                else if (e.Args[i] == "--view" && i + 1 < e.Args.Length) view = e.Args[++i];
                else if (e.Args[i] == "--qa") Qa = true;
                else throw new ArgumentException("Unknown or incomplete sample argument: " + e.Args[i]);
            }
            CultureName = SampleLanguages.Resolve(CultureName);
            var culture = CultureInfo.GetCultureInfo(CultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            var window = new MainWindow();
            MainWindow = window;
            window.Show();
            window.SelectView(view);
            if (smoke != null) Dispatcher.BeginInvoke(DispatcherPriority.ApplicationIdle, new Action(() => Smoke(window, smoke)));
        }
        internal static void Restart(string culture)
        {
            culture = SampleLanguages.Resolve(culture);
            if (culture == CultureName) return;
            // Locate the sample apphost even when initially launched with dotnet <DLL>.
            var assembly = typeof(App).Assembly.Location;
            var file = Path.ChangeExtension(assembly, ".exe");
            var arguments = "--culture " + culture;
            if (!File.Exists(file)) { file = Process.GetCurrentProcess().MainModule.FileName; arguments = "\"" + assembly + "\" " + arguments; }
            Process.Start(new ProcessStartInfo(file, arguments) { UseShellExecute = true });
            Current.Shutdown();
        }
        private void Smoke(MainWindow window, string path)
        {
            try
            {
                Directory.CreateDirectory(path);
                string[] views = { "print", "profiles", "resources" };
                foreach (string view in views)
                {
                    window.SelectView(view);
                    window.UpdateLayout();
                    Capture(window, Path.Combine(path, view + ".png"));
                }
                window.CheckResources();
                if (!System.Linq.Enumerable.SequenceEqual(window.LanguageChoices(), System.Linq.Enumerable.Select(SampleLanguages.Available(), culture => culture.Name))) throw new InvalidOperationException("Language menu differs from usable translations.");
                var dialog = new ExportOptionsDialog { Owner = window };
                dialog.Show();
                dialog.UpdateLayout();
                Capture(dialog, Path.Combine(path, "export.png"));
                string summary = "PASS\nlanguages=" + string.Join(",", window.LanguageChoices()) + "\nculture=" + CultureName + "\nversion=" + Texts.Get("SampleVersion") + "\nwindows=" + Current.Windows.Count + "\ntitle=" + window.Title + "\npresets=" + window.PresetNames() + "\nformat=" + Texts.ExportSummary() + "\nhtml=" + Texts.Guide() + "\nxml=" + Texts.PresetDescription() + "\n";
                if (Current.Windows.Count != 2) throw new InvalidOperationException("Expected exactly two sample windows.");
                File.WriteAllText(Path.Combine(path, "result.txt"), summary);
                Click(window, "SaveProfileTool");
                if (window.ResourceMessage.Text != string.Format(Texts.Get("ExportProfileSavedFormat"), Texts.Get("StandardProfile"))) throw new InvalidOperationException("Save profile action failed.");
                Click(window, "PreviewTool");
                if (window.ResourceMessage.Text != Texts.ExportSummary()) throw new InvalidOperationException("Preview message action failed.");
                Click(dialog, "ExportButton");
                if (dialog.ResultText.Text != Texts.ExportSummary()) throw new InvalidOperationException("Export dialog message action failed.");
                Click(dialog, "PageSetupButton");
                if (Current.Windows.Count != 1) throw new InvalidOperationException("Page setup must close the export dialog.");
                File.AppendAllText(Path.Combine(path, "result.txt"), "actions=save,preview,export,page-setup\n");
                Shutdown(0);
            }
            catch (Exception error)
            {
                File.WriteAllText(Path.Combine(path, "result.txt"), error.ToString());
                Shutdown(1);
            }
        }
        private static void Click(DependencyObject root, string uid)
        {
            var button = root as System.Windows.Controls.Button;
            if (button != null && button.Uid == uid) { button.RaiseEvent(new RoutedEventArgs(System.Windows.Controls.Button.ClickEvent)); return; }
            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(root); index++)
            {
                var child = VisualTreeHelper.GetChild(root, index);
                if (ContainsUid(child, uid)) { Click(child, uid); return; }
            }
            throw new InvalidOperationException("Missing action: " + uid);
        }
        private static bool ContainsUid(DependencyObject root, string uid)
        {
            var element = root as FrameworkElement;
            if (element != null && element.Uid == uid) return true;
            for (int index = 0; index < VisualTreeHelper.GetChildrenCount(root); index++)
                if (ContainsUid(VisualTreeHelper.GetChild(root, index), uid)) return true;
            return false;
        }
        private static void Capture(Window window, string path)
        {
            var visual = (FrameworkElement)window.Content;
            visual.UpdateLayout();
            var image = new RenderTargetBitmap((int)Math.Ceiling(visual.ActualWidth), (int)Math.Ceiling(visual.ActualHeight), 96, 96, PixelFormats.Pbgra32);
            var drawing = new DrawingVisual();
            using (var context = drawing.RenderOpen()) context.DrawRectangle(new VisualBrush(visual), null, new Rect(0, 0, visual.ActualWidth, visual.ActualHeight));
            image.Render(drawing);
            var encoder = new PngBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (var stream = File.Create(path)) encoder.Save(stream);
        }
    }
}