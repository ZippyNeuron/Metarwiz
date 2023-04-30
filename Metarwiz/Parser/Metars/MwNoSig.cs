using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Metars
{
    public class MwNoSig : MetarItem
    {
        private readonly string _nosig;

        internal MwNoSig(Match match)
        {
            _nosig = match.Groups["NOSIG"].Value;
        }

        internal static string Pattern => @"( )(?<NOSIG>NOSIG)";

        public override string ToString()
        {
            return _nosig;
        }
    }
}
