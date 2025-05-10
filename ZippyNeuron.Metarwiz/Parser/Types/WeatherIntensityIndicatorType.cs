using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types;

public enum WeatherIntensityIndicatorType
{
    [Description("-")]
    Light,
    [Description("")]
    Moderate,
    [Description("+")]
    Heavy
}
