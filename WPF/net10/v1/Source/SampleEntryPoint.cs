using System;
using System.Globalization;
using System.Threading;

namespace WpfLocalization
{
    internal static class SampleEntryPoint
    {
        [STAThread]
        public static void Main(string[] args)
        {
            // Choose a usable culture before WPF loads App/Styles BAML.
            // A missing or malformed satellite must not break InitializeComponent on a German OS.
            string requested = SampleLanguages.NativeCulture;
            for (int index = 0; index + 1 < args.Length; index++)
                if (args[index] == "--culture") requested = args[index + 1];
            App.CultureName = SampleLanguages.Resolve(requested);
            var culture = CultureInfo.GetCultureInfo(App.CultureName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            CultureInfo.DefaultThreadCurrentCulture = culture;
            CultureInfo.DefaultThreadCurrentUICulture = culture;
            var application = new App();
            application.InitializeComponent();
            application.Run();
        }
    }
}