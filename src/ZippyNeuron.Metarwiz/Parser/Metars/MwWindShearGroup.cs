using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars;

public class MwWindShearGroup : MetarItem
{
    private readonly string _prefix;
    private readonly int _runway;
    private readonly string _designator;
    private readonly string _all;
    private readonly string _r;

    internal MwWindShearGroup(Match match)
    {
        _ = match ?? throw new ArgumentNullException(nameof(match));
        
        _prefix = match.Groups["PREFIX"].Value;
        _ = int.TryParse(match.Groups["RUNWAY"].Value, out _runway);
        _designator = match.Groups["DESIGNATOR"].Value;
        _all = match.Groups["WSALLRWY"].Value;
        _r = match.Groups["R"].Value;
    }

    public int Runway => _runway;
    public RunwayType Designator => _designator switch
        {
            "L" => RunwayType.L,
            "C" => RunwayType.C,
            "R" => RunwayType.R,
            _ => RunwayType.U
        };
    
    public string DesignatorDescription => Designator.GetDescription();
    public bool IsAllRunways => !string.IsNullOrEmpty(_all);

    internal static string Pattern => @"( )(?<PREFIX>WS) (?<R>R)(?<RUNWAY>\d{2})(?<DESIGNATOR>L|R|C)?|(?<WSALLRWY>WS ALL RWY)";

    public override string ToString()
    {
        return IsAllRunways ? _all : $"{_prefix} {_r}{_runway.ToString("D2")}{_designator}";
    }
}
