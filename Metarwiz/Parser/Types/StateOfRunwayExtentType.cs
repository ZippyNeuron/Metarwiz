using System.ComponentModel;

namespace ZippyNeuron.Metarwiz.Parser.Types
{
    public enum StateOfRunwayExtentType
    {
        [Description("10% or less")]
        TenOrLessPercent = 1,
        [Description("11% to 25%")]
        ElevenToTwentyFivePercent = 2,
        [Description("26% to 50%")]
        TwentySixToFiftyPercent = 5,
        [Description("51% to 100%")]
        FiftyOneToOneHundredPercent = 9,
    }
}
