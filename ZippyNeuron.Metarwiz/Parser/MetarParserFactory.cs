using System;
using System.Globalization;
using System.Reflection;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser;

internal static class MetarParserFactory
{
    public static MetarItem Create(Type t, Match m)
    {
        return (MetarItem)Activator.CreateInstance(t, BindingFlags.Instance | BindingFlags.NonPublic, null, new[] { m }, CultureInfo.InvariantCulture);
    }
}
