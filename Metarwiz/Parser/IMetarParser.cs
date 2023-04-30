using System.Collections.Generic;

namespace ZippyNeuron.Metarwiz.Parser
{
    internal interface IMetarParser
    {
        public IEnumerable<IMetarItem> Items { get; }

        public void Parse();

        public MetarInfo Info { get; }
    }
}