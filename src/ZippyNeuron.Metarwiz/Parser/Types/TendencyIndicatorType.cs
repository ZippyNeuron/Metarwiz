using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types;

public enum TendencyIndicatorType
{
    [Description("Unspecified")]
    Unspecified,
    [Description("Upward")]
    U,
    [Description("None")]
    N,
    [Description("Downward")]
    D,
    [Description("Feet")]
    FT,
}
