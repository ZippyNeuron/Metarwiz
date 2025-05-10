using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars;

public class MwRecentWeather : MetarItem
{
    private readonly string _recent;

    internal MwRecentWeather(Match match)
    {
        _recent = match.Groups["RECENTWEATHER"].Value;
    }

    public RecentWeatherType Kind => (!String.IsNullOrEmpty(_recent)) ? Enum.Parse<RecentWeatherType>(_recent) : RecentWeatherType.Unspecified;
    public string KindDescription => Kind.GetDescription();

    internal static string Pattern
    {
        get
        {
            string recents = String
                .Join("|", Enum.GetNames<RecentWeatherType>());

            return @$"( )(?<RECENTWEATHER>{recents})";
        }
    }

    public override string ToString()
    {
        return Enum.GetName<RecentWeatherType>(Kind);
    }
}
