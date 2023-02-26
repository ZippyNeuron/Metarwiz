using System;
using System.ComponentModel;
using System.Reflection;

namespace ZippyNeuron.Metarwiz.Extensions
{
    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var attribute = value
                .GetType()
                .GetField(value.ToString())
                ?.GetCustomAttribute<DescriptionAttribute>();

            return attribute is not null ? attribute.Description : string.Empty;
        }
    }
}