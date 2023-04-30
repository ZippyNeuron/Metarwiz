using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Remarks
{
    public class RwNeedsMaintenance : MetarItem
    {
        private readonly string _maintenance;

        internal RwNeedsMaintenance(Match match)
        {
            _maintenance = match.Groups["MAINTENANCE"].Value;
        }

        internal static string Pattern => @"( )(?<MAINTENANCE>\$)";

        public override string ToString()
        {
            return _maintenance;
        }
    }
}
