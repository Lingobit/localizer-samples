using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Xml.Linq;

namespace WinFormsBinary.Net10;

internal static class SampleResources
{
    private static readonly ResourceManager Manager = new("WinFormsBinary.Net10.Resources", typeof(SampleResources).Assembly);
    public static string Text(string key) => Manager.GetString(key, CultureInfo.CurrentUICulture)
        ?? throw new MissingManifestResourceException(key);
    public static string Format(string key, params object[] arguments) =>
        string.Format(CultureInfo.CurrentCulture, Text(key), arguments);
    public static object Object(string key) => Manager.GetObject(key, CultureInfo.CurrentUICulture);
    public static string Content(string name)
    {
        using var stream = ContentStream(name);
        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
    private static Stream ContentStream(string name)
    {
        var assembly = Assembly.GetExecutingAssembly();
        for (var culture = CultureInfo.CurrentUICulture; culture.Name.Length > 0; culture = culture.Parent)
        {
            try
            {
                var stream = assembly.GetSatelliteAssembly(culture).GetManifestResourceStream("Content." + name);
                if (stream != null) return stream;
            }
            catch (FileNotFoundException) { }
        }
        return assembly.GetManifestResourceStream("Content." + name)
            ?? throw new MissingManifestResourceException(name);
    }
    public static string PresetDescription => XDocument.Parse(Content("export-presets.xml"))
        .Root.Element("preset").Element("description").Value;
}
