using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types
{
    public enum DepositType
    {
        [Description("Clear and Dry")]
        ClearAndDry,
        [Description("Damp")]
        Damp,
        [Description("Wet or Water Patches")]
        WetOrWaterPatches,
        [Description("Rime or Frost")]
        RimeOrFrost,
        [Description("Dry Snow")]
        DrySnow,
        [Description("Wet Snow")]
        WetSnow,
        [Description("Slush")]
        Slush,
        [Description("Ice")]
        Ice,
        [Description("Compacted or Rolled Snow")]
        CompactedOrRolledSnow,
        [Description("Frozen Ruts or Ridges")]
        FrozenRutsOrRidges
    }
}
