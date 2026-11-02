using System.Windows;
namespace WpfLocalization
{
    public sealed class Preset
    {
        [Localizability(LocalizationCategory.Text)] public string DisplayName { get; set; }
        [Localizability(LocalizationCategory.Text)] public string Quality { get; set; }
        [Localizability(LocalizationCategory.Text)] public string Format { get; set; }
    }
}