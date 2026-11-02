using System.Globalization;
using System.Reflection;
using System.Resources;

namespace WinFormsBinary.Net10;

internal static class SampleLanguages
{
    internal const string NativeCulture = "en-US";

    internal static CultureInfo[] Available()
    {
        var source = typeof(SampleLanguages).Assembly;
        var result = new List<CultureInfo> { CultureInfo.GetCultureInfo(NativeCulture) };
        foreach (var directory in Directory.EnumerateDirectories(AppContext.BaseDirectory))
        {
            try
            {
                var culture = CultureInfo.GetCultureInfo(Path.GetFileName(directory));
                if (culture.Name.Length == 0 || culture.Name == NativeCulture) continue;
                var file = Path.Combine(directory, source.GetName().Name + ".resources.dll");
                if (!File.Exists(file)) continue;
                var satellite = source.GetSatelliteAssembly(culture);
                var identity = satellite.GetName();
                if (identity.CultureName != culture.Name || identity.Version != source.GetName().Version) continue;
                var suffix = "." + culture.Name + ".resources";
                if (new[] { "MainForm", "ExportOptionsDialog", "Resources" }
                    .All(name => HasResource(satellite, "WinFormsBinary.Net10." + name + suffix,
                        name == "Resources" ? "ExportSummaryFormat" : "$this.Text"))) result.Add(culture);
            }
            catch (CultureNotFoundException) { }
            catch (IOException) { }
            catch (BadImageFormatException) { }
            catch (NotSupportedException) { }
            catch (ArgumentException) { }
        }
        return result.OrderBy(culture => culture.Name == NativeCulture ? "" : culture.Name, StringComparer.Ordinal).ToArray();
    }

    private static bool HasResource(Assembly satellite, string name, string key)
    {
        using var stream = satellite.GetManifestResourceStream(name);
        if (stream == null) return false;
        using var reader = new System.Resources.Extensions.DeserializingResourceReader(stream);
        var entries = reader.GetEnumerator();
        while (entries.MoveNext()) if ((string)entries.Key == key) return true;
        return false;
    }

    internal static string Resolve(string requested) => Available()
        .FirstOrDefault(culture => string.Equals(culture.Name, requested, StringComparison.OrdinalIgnoreCase))?.Name ?? NativeCulture;
}