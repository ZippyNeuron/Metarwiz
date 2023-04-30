using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Remarks
{
    public class RwSeaLevelPressure : MetarItem
    {
        private readonly string _slp;
        private readonly int _pressure;

        internal RwSeaLevelPressure(Match match)
        {
            _slp = match.Groups["SLP"].Value;
            _ = int.TryParse(match.Groups["PRESSURE"].Value, out _pressure);
        }

        public decimal HPa => Math.Round((_pressure / 10) + ((_pressure < 500) ? 1000m : 900m), 0);

        public decimal InHg => Math.Round(HPa * MetarConversion.HPaToinHg, 2);

        internal static string Pattern => @"( )(?<SLP>SLP)(?<PRESSURE>\d{3})";

        public override string ToString()
        {
            return $"{_slp}{_pressure.ToString("D3")}";
        }
    }
}
