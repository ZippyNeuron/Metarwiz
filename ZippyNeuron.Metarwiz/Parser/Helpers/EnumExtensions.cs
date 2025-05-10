using System;
using System.ComponentModel;
using System.Reflection;

namespace ZippyNeuron.Metarwiz.Parser.Helpers;

internal static class EnumExtensions
{
    internal static string GetDescription(this Enum value)
    {
        var attribute = value
            .GetType()
            .GetField(value.ToString())
            ?.GetCustomAttribute<DescriptionAttribute>();

        return attribute is not null ? attribute.Description : string.Empty;
    }
}