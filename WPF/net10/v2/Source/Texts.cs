using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Xml.Linq;
namespace WpfLocalization
{
    internal static class Texts
    {
        private static readonly ResourceManager Resources = new ResourceManager("WpfLocalization.Properties.Resources", typeof(Texts).Assembly);
        internal static string Get(string key)
        {
            return Resources.GetString(key, CultureInfo.CurrentUICulture) ?? throw new InvalidOperationException("Missing string resource: " + key);
        }
        internal static string ExportSummary()
        {
            try { return string.Format(CultureInfo.CurrentCulture, Get("ExportSummaryFormat"), 12, "sample.pdf"); }
            catch (FormatException) { return Get("InvalidFormatMessage"); }
        }
        private static XDocument ContentDocument(string file)
        {
            var resource = System.Windows.Application.GetResourceStream(new Uri("Content/" + file, UriKind.Relative));
            if (resource == null) throw new InvalidOperationException("Missing embedded sample content: " + file);
            using (var stream = resource.Stream) return XDocument.Load(stream);
        }
        internal static string SaveContent(string file, string directory)
        {
            if (file != "export-guide.html" && file != "export-presets.xml") throw new ArgumentException("Unknown sample document.", nameof(file));
            var resource = System.Windows.Application.GetResourceStream(new Uri("Content/" + file, UriKind.Relative));
            if (resource == null) throw new InvalidOperationException("Missing embedded sample content: " + file);
            Directory.CreateDirectory(directory);
            string path = Path.Combine(directory, file);
            using (var source = resource.Stream)
            using (var destination = File.Create(path)) source.CopyTo(destination);
            return path;
        }
        internal static string Guide()
        {
            var document = ContentDocument("export-guide.html");
            return string.Join(Environment.NewLine, document.Descendants().Where(n => n.Name.LocalName == "h1" || n.Name.LocalName == "p").Select(n => n.Value));
        }
        internal static string PresetDescription()
        {
            return ContentDocument("export-presets.xml").Root.Element("preset").Attribute("description").Value;
        }
    }
}