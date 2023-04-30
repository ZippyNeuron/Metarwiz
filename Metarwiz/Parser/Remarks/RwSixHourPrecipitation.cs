﻿using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Remarks
{
    public class RwSixHourPrecipitation : MetarItem
    {
        private readonly string _prefix;
        private readonly decimal _units = 0.01m;
        private readonly int _amount;

        internal RwSixHourPrecipitation(Match match)
        {
            _prefix = match.Groups["6"].Value;
            _ = int.TryParse(match.Groups["AMOUNT"].Value, out _amount);
        }

        public bool IsTrace => _amount == 0;

        public decimal Inches => _amount * _units;

        internal static string Pattern => @"\ (?<6>6)(?<AMOUNT>\d{4})";

        public override string ToString()
        {
            return $"{_prefix}{_amount.ToString("D4")}";
        }
    }
}
