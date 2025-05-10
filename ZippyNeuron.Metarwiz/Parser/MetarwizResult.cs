using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

namespace ZippyNeuron.Metarwiz.Parser;

public class MetarwizResult
{
    internal MetarwizResult(IEnumerable<IMetarItem> metarItrems, MetarInfo metarInfo)
    {
        MetarItems = metarItrems;
        MetarInfo = metarInfo;
    }

    public MetarInfo MetarInfo { get; }

    public IEnumerable<IMetarItem> MetarItems { get; }

    public T Get<T>() where T : IMetarItem => MetarItems
            .Where(i => i.GetType() == typeof(T))
            .Cast<T>()
            .FirstOrDefault();

    public IEnumerable<T> GetMany<T>() where T : IMetarItem => MetarItems
            .Where(i => i.GetType() == typeof(T))
            .Cast<T>()
            .ToList();

    public override string ToString()
    {
        StringBuilder builder = new();

        foreach (IMetarItem item in MetarItems)
            builder.Append($"{((item.ToString() != "METAR") ? " " : String.Empty)}{item}");

        return $"{builder.ToString().Trim()}{MetarInfo.Terminator}";
    }
}