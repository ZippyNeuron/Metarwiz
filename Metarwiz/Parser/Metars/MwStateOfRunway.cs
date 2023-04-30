using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwStateOfRunway : MetarItem
    {
        private readonly string _prefix;
        private readonly int _runway;
        private readonly string _designator;
        private readonly string _separator;
        private readonly string _code;
        private readonly int? _deposit;
        private readonly int? _extent;
        private readonly int? _depth;
        private readonly int? _friction;

        internal MwStateOfRunway(Match match)
        {
            _prefix = match.Groups["PREFIX"].Value;
            _ = int.TryParse(match.Groups["RUNWAY"].Value, out _runway);
            _designator = match.Groups["DESIGNATOR"].Value;
            _separator = match.Groups["SEPARATOR"].Value;
            _code = match.Groups["CODE"].Value;

            Func<string, int?> parseCode = (s) =>
            {
                return (string.IsNullOrEmpty(s) || s == @"/" || s == @"//") ? null : Convert.ToInt32(s);
            };

            _deposit = parseCode(_code.Substring(0, 1));
            _extent = parseCode(_code.Substring(1, 1));
            _depth = parseCode(_code.Substring(2, 2));
            _friction = parseCode(_code.Substring(4, 2));
        }

        public int? Deposit => _deposit;
        public string DepositDescription => _deposit switch
            {
                0 => DepositType.ClearAndDry.GetDescription(),
                1 => DepositType.Damp.GetDescription(),
                2 => DepositType.WetOrWaterPatches.GetDescription(),
                3 => DepositType.RimeOrFrost.GetDescription(),
                4 => DepositType.DrySnow.GetDescription(),
                5 => DepositType.WetSnow.GetDescription(),
                6 => DepositType.Slush.GetDescription(),
                7 => DepositType.Ice.GetDescription(),
                8 => DepositType.CompactedOrRolledSnow.GetDescription(),
                9 => DepositType.FrozenRutsOrRidges.GetDescription(),
                _ => "Not Reported"
            };

        public int? Extent => _extent;
        public string ExtentDescription => _extent switch
            {
                1 => StateOfRunwayExtentType.TenOrLessPercent.GetDescription(),
                2 => StateOfRunwayExtentType.ElevenToTwentyFivePercent.GetDescription(),
                5 => StateOfRunwayExtentType.TwentySixToFiftyPercent.GetDescription(),
                9 => StateOfRunwayExtentType.FiftyOneToOneHundredPercent.GetDescription(),
                _ => "Not Reported"
            };

        public int? Depth => _depth;
        public int? DepthValue
        {
            get {
                if (_depth is not null)
                {
                    return _depth switch
                    {
                        <= 90 => _depth,
                        91 => 0,
                        >= 92 => ((_depth ?? 0) - 90) * 50
                    };
                } else {
                    return 0;
                }
            }
        }
        public int? Friction => _friction;
        public bool ClosedDueToSnow => _code == "SNOCLO";
        public bool Cleared => _code.Substring(0, 4) == "CLRD";
        public bool Operational => !(_depth == 99);
        public bool IsNoNewInformation => _runway == 99;
        public bool IsAllRunways => _runway == 88;
        public bool IsNoSpecificRunway => (IsNoNewInformation || IsAllRunways);
        public bool IsLeft => (!IsNoSpecificRunway) && (_runway < 50);
        public bool IsRight => (!IsNoSpecificRunway) && (_runway > 50);
        public string Orientation => (!IsNoSpecificRunway) ? (IsLeft) ? string.Empty : "R" : string.Empty;
        public int Bearing => (!IsNoSpecificRunway) ? (IsLeft) ? _runway : (_runway - 50) : 0;
        public string Runway => (!IsNoSpecificRunway) ? $"{Bearing}{Orientation}" : string.Empty;

        internal static string Pattern => @"( )(?<PREFIX>R)(?<RUNWAY>\d{2})?(?<DESIGNATOR>L|C|R)?(?<SEPARATOR>\/)(?<CODE>\d{6})";

        public override string ToString()
        {
            return String.Concat(
                _prefix,
                (_runway > 0) ? _runway.ToString("D2") : String.Empty,
                _designator,
                _separator,
                _deposit,
                _extent,
                _depth,
                _friction
            );
        }
    }
}
