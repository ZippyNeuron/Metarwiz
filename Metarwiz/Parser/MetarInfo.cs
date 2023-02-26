using System;

namespace ZippyNeuron.Metarwiz.Parser
{
    public sealed class MetarInfo
    {
        private const string RemarksTag = "RMK";
        private const string TerminatorSymbol = "=";

        internal MetarInfo(string metar, string tag)
        {
            Original = metar;
            HasTerminator = metar.EndsWith(TerminatorSymbol);
            Metar = RemoveRemarks(RemoveTerminator(metar));
            Remarks = GetRemarks(metar);
            Tag = tag;
        }

        public string Tag { get; }

        public string Original { get; }

        public string Metar { get; }

        public string Remarks { get; }

        public string Terminator => (HasTerminator) ? TerminatorSymbol : string.Empty;

        public bool HasTerminator { get; }

        public bool HasRemarks => !string.IsNullOrEmpty(Remarks);

        public override string ToString()
        {
            return $"{Metar}{((HasRemarks) ? String.Concat(" ", Remarks) : String.Empty)}{Terminator}";
        }

        private string RemoveTerminator(string metar)
        {
            return metar
                .Trim()
                .TrimEnd(TerminatorSymbol.ToCharArray())
                .Trim();
        }

        private string GetRemarks(string metar)
        {
            int start = metar.IndexOf(RemarksTag, StringComparison.Ordinal);

            if (start < 0)
                return String.Empty;

            return metar
                .Substring(start)
                .TrimEnd(TerminatorSymbol.ToCharArray());
        }

        private string RemoveRemarks(string metar)
        {
            var start = metar.IndexOf(RemarksTag, StringComparison.Ordinal);

            if (start < 0)
                return metar;

            return metar.Substring(0, start - 1)
                .Trim();
        }
    }
}
