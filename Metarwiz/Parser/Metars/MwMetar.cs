using System;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwMetar : MetarItem
    {
        private readonly string _metar;

        internal MwMetar(Match match)
        {
            _ = match ?? throw new ArgumentNullException(nameof(match));
            
            _metar = match.Groups["METAR"].Value;
        }

        internal static string Pattern => @"^(?<METAR>METAR)";

        public override string ToString()
        {
            return _metar;
        }
    }
}
