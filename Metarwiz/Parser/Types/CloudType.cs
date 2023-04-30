using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types
{
    public enum CloudType
    {
        [Description("Unspecified")]
        Unspecified,
        [Description("Broken")]
        BKN,
        [Description("Scattered")]
        SCT,
        [Description("Few")]
        FEW,
        [Description("Overcast")]
        OVC,
        [Description("No Cloud Detected")]
        NCD,
        [Description("No Cloud Below 12,000 (AGL)")]
        CLR,
        [Description("Sky Clear")]
        SKC,
        [Description("No Significant Cloud")]
        NSC,
        [Description("Vertical Visibility")]
        VV,
    }
}
