using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Resources;

namespace WpfLocalization
{
    internal static class SampleLanguages
    {
        internal static string NativeCulture => typeof(SampleLanguages).Assembly.GetCustomAttributes<AssemblyMetadataAttribute>()
            .First(attribute => attribute.Key == "SampleSourceCulture").Value;

        internal static CultureInfo[] Available()
        {
            var source = typeof(SampleLanguages).Assembly;
            var result = new List<CultureInfo> { CultureInfo.GetCultureInfo(NativeCulture) };
            foreach (var directory in Directory.EnumerateDirectories(AppDomain.CurrentDomain.BaseDirectory))
            {
                try
                {
                    var culture = CultureInfo.GetCultureInfo(Path.GetFileName(directory));
                    if (culture.Name.Length == 0 || culture.Name == NativeCulture) continue;
                    if (!File.Exists(Path.Combine(directory, "WpfLocalization.resources.dll"))) continue;
                    var satellite = source.GetSatelliteAssembly(culture);
                    var identity = satellite.GetName();
                    if (identity.CultureName != culture.Name || identity.Version != source.GetName().Version) continue;
                    using (var strings = satellite.GetManifestResourceStream("WpfLocalization.Properties.Resources." + culture.Name + ".resources"))
                    {
                        if (strings == null) continue;
                        using (var reader = new ResourceReader(strings))
                        {
                            bool hasMessage = false;
                            var entries = reader.GetEnumerator();
                            while (entries.MoveNext()) if ((string)entries.Key == "ExportSummaryFormat") hasMessage = true;
                            if (!hasMessage) continue;
                        }
                    }
                    using (var stream = satellite.GetManifestResourceStream("WpfLocalization.g." + culture.Name + ".resources"))
                    {
                        if (stream == null) continue;
                        using (var reader = new ResourceReader(stream))
                        {
                            var keys = new List<string>();
                            var entries = reader.GetEnumerator();
                            while (entries.MoveNext()) keys.Add((string)entries.Key);
                            if (!keys.Contains("mainwindow.baml") || !keys.Contains("exportoptionsdialog.baml")) continue;
                        }
                    }
                    result.Add(culture);
                }
                catch (CultureNotFoundException) { }
                catch (IOException) { }
                catch (BadImageFormatException) { }
                catch (ArgumentException) { }
            }
            return result.OrderBy(culture => culture.Name == NativeCulture ? "" : culture.Name, StringComparer.Ordinal).ToArray();
        }

        internal static string Resolve(string requested) => Available()
            .FirstOrDefault(culture => string.Equals(culture.Name, requested, StringComparison.OrdinalIgnoreCase))?.Name ?? NativeCulture;
    }
}