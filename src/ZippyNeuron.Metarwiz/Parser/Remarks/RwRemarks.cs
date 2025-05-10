using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Remarks;

public class RwRemarks : MetarItem
{
    private readonly string _rmk;

    internal RwRemarks(Match match)
    {
        _rmk = match.Groups["RMK"].Value;
    }

    internal static string Pattern => @"(?<RMK>RMK)";

    public override string ToString()
    {
        return _rmk;
    }
}
