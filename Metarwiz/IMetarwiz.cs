using System.Collections.Generic;
using ZippyNeuron.Metarwiz.Parser;

namespace ZippyNeuron.Metarwiz
{
    public interface IMetarwiz
    {
        public MetarInfo Metar { get; }

        public T Get<T>() where T : IMetarItem;

        public IEnumerable<T> GetMany<T>() where T : IMetarItem;

        public void Parse(string metar, string tag);

        public string ToString();
    }
}