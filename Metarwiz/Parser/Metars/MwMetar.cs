using System;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwMetar : BaseMetarItem
    {
        private readonly string _metar;

        public MwMetar(Match match)
        {
            _ = match ?? throw new ArgumentNullException(nameof(match));
            
            _metar = match.Groups["METAR"].Value;
        }

        public static string Pattern => @"^(?<METAR>METAR)";

        public override string ToString()
        {
            return _metar;
        }
    }
}
