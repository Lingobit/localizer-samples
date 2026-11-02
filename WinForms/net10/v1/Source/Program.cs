using System.Globalization;

namespace WinFormsBinary.Net10;

internal static class Program
{
    internal static string RequestedCulture;
    [STAThread]
    private static int Main(string[] args)
    {
        ApplicationConfiguration.Initialize();
        try
        {
            var culture = SampleLanguages.Resolve(Option(args, "--culture") ?? SampleLanguages.NativeCulture);
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(culture);
            CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
            var smoke = Option(args, "--smoke");
            if (smoke != null) { SampleSmoke.Run(smoke); return 0; }
            do
            {
                RequestedCulture = null;
                using var form = new MainForm();
                Application.Run(form);
                if (RequestedCulture != null)
                {
                    CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo(SampleLanguages.Resolve(RequestedCulture));
                    CultureInfo.CurrentUICulture = CultureInfo.GetCultureInfo(SampleLanguages.Resolve(RequestedCulture));
                }
            } while (RequestedCulture != null);
            return 0;
        }
        catch (Exception error)
        {
            var smoke = Option(args, "--smoke");
            if (smoke != null)
            {
                Directory.CreateDirectory(smoke);
                File.WriteAllText(Path.Combine(smoke, "error.txt"), error.ToString());
                return 1;
            }
            throw;
        }
    }
    private static string Option(string[] args, string name)
    {
        var index = Array.IndexOf(args, name);
        return index >= 0 && index + 1 < args.Length ? args[index + 1] : null;
    }
}
