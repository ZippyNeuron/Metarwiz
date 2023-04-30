using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser
{
    internal sealed class MetarParser : IMetarParser
    {
        private readonly List<MetarParserItem> _items = new();
        private readonly MetarInfo _metarInfo;

        internal MetarParser(string metar, string tag = null)
        {
            _metarInfo = new MetarInfo(metar, tag);

            Regex.CacheSize = 128;
        }

        public MetarInfo MetarInfo => _metarInfo;

        public IEnumerable<MetarParserItem> Items => _items;

        public IEnumerable<IMetarItem> Parse()
        {
            _items.Clear();
            
            ParseTypes(_metarInfo.Metar, MetarParserItemTypes.MetarTypesToParse);
            
            ParseTypes(_metarInfo.Remarks, MetarParserItemTypes.RemarkTypesToParse);
            
            return _items
                .OrderBy(i => i.Index)
                .Select((value) => value.Item)
                .Cast<IMetarItem>()
                .ToList();
        }

        private void ParseTypes(string metar, IEnumerable<Type> types)
        {
            var metarCopy = metar;

            foreach (var type in types)
            {
                var pattern = GetMatchPattern(type);

                var matchCollection = Regex.Matches(metarCopy, pattern, RegexOptions.None);

                if (matchCollection.Count <= 0) continue;
                
                foreach (Match match in matchCollection)
                {
                    MetarItem metarItem = MetarParserFactory.Create(type, match);

                    MetarParserItem mpi = new()
                    {
                        Index = _metarInfo.Original.IndexOf(metarItem.ToString(), StringComparison.Ordinal),
                        Item = metarItem
                    };

                    _items.Add(mpi);

                    var startIndex = metarCopy.IndexOf(metarItem.ToString(), StringComparison.Ordinal);

                    if (startIndex > 0)
                    {
                        metarCopy = metarCopy.Remove(metarCopy.IndexOf(metarItem.ToString(), StringComparison.Ordinal), mpi.Item.ToString().Length);
                    }
                }
            }
        }

        private string GetMatchPattern(Type type)
        {
            return type.GetProperty("Pattern", BindingFlags.Static | BindingFlags.NonPublic)
                ?.GetValue(null, null) as string;
        }
    }
}
