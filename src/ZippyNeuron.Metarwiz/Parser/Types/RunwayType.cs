using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types;

public enum RunwayType
{
    [Description("Unspecified")]
    U,
    [Description("Left")]
    L,
    [Description("Centre")]
    C,
    [Description("Right")]
    R
}
