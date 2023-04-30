using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwRunwayVisualRange : MetarItem
    {
        private readonly int _runway;
        private readonly string _designator;
        private readonly string _observation;
        private readonly int _from;
        private readonly string _tendency;
        private readonly string _v;
        private readonly int _to;
        private readonly string _r;
        private readonly string _divider;

        internal MwRunwayVisualRange(Match match)
        {
            _designator = match.Groups["DESIGNATOR"].Value;
            _observation = match.Groups["OBSERVATION"].Value;
            _tendency = match.Groups["TENDENCY"].Value;
            _ = int.TryParse(match.Groups["RUNWAY"].Value, out _runway);
            _ = int.TryParse(match.Groups["FROM"].Value, out _from);
            _v = match.Groups["V"].Value;
            _ = int.TryParse(match.Groups["TO"].Value, out _to);
            _r = match.Groups["R"].Value;
            _divider = match.Groups["DIVIDER"].Value;
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
        public int From => _from;
        public int To => _to;
        public ObservationType Observation => _observation switch
            {
                "P" => ObservationType.P,
                "M" => ObservationType.M,
                _ => ObservationType.U
            };
        public string ObservationDescription => Observation.GetDescription();
        public TendencyIndicatorType Tendency => _tendency switch
            {
                "U" => TendencyIndicatorType.U,
                "N" => TendencyIndicatorType.N,
                "D" => TendencyIndicatorType.D,
                "FT" => TendencyIndicatorType.FT,
                _ => TendencyIndicatorType.Unspecified
            };
        public string TendencyDescription => Tendency.GetDescription();

        internal static string Pattern => @"( )(?<R>R)(?<RUNWAY>\d{2})(?<DESIGNATOR>L|R|C)?(?<DIVIDER>\/)((?<OBSERVATION>P|M)(?<FROM>\d{4}(?=V|U|D|N|FT|\b))?((?<V>V)(?<TO>\d{4}))?)(?<TENDENCY>U|D|N|FT)?";
        
        public override string ToString()
        {
            return String.Concat(
                _r,
                Runway.ToString("D2"),
                (Designator != RunwayType.U) ? Enum.GetName<RunwayType>(Designator) : String.Empty,
                _divider,
                (Observation != ObservationType.U) ? Enum.GetName<ObservationType>(Observation) : String.Empty,
                String.IsNullOrEmpty(_v) ? $"{_from.ToString("D4")}" : $"{_from.ToString("D4")}{_v}{_to.ToString("D4")}",              
                (Tendency != TendencyIndicatorType.Unspecified) ? Enum.GetName(Tendency) : String.Empty
            );
        }
    }
}
