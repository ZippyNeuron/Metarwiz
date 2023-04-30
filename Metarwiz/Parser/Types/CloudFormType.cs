using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types
{
    public enum CloudFormType
    {
        [Description("Unspecified")]
        Unspecified,
        [Description("Cumulonimbus")]
        CB,
        [Description("Towering Cumulus")]
        TCU,
    }
}
