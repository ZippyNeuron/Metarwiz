using System;
using System.Text.RegularExpressions;
using ZippyNeuron.Metarwiz.Parser.Types;
using ZippyNeuron.Metarwiz.Parser.Helpers;

namespace ZippyNeuron.Metarwiz.Parser.Metars;

public class MwWeather : MetarItem
{
    private readonly string _intensity;
    private readonly string _vacinity;
    private readonly string _weather1;
    private readonly string _weather2;

    internal MwWeather(Match match)
    {
        _intensity = match.Groups["INTENSITY"].Value;
        _vacinity = match.Groups["VACINITY"].Value;
        _weather1 = match.Groups["WEATHER1"].Value;
        _weather2 = match.Groups["WEATHER2"].Value;
    }

    public bool IsInVacinity => _vacinity == "VC";
    public WeatherType WeatherPrimary => (!String.IsNullOrEmpty(_weather1)) ? Enum.Parse<WeatherType>(_weather1) : WeatherType.Unspecified;
    public WeatherType WeatherSecondary => (!String.IsNullOrEmpty(_weather2)) ? Enum.Parse<WeatherType>(_weather2) : WeatherType.Unspecified;
    public WeatherIntensityIndicatorType Intensity => _intensity switch
    {
        "-" => WeatherIntensityIndicatorType.Light,
        "+" => WeatherIntensityIndicatorType.Heavy,
        _ => WeatherIntensityIndicatorType.Moderate
    };
    public string IntensityDescription => Intensity.GetDescription();
    internal static string Pattern
    {
        get
        {
            string weathers = String
                .Join("|", Enum.GetNames<WeatherType>());

            return @$"( )(?<INTENSITY>\-|\+|)(?<VACINITY>VC)?((?<WEATHER1>{weathers})(?<WEATHER2>{weathers})?)";
        }
    }

    public override string ToString()
    {
        return String.Concat(
            Intensity.GetDescription(),
            _vacinity,
            (WeatherPrimary != WeatherType.Unspecified) ? Enum.GetName<WeatherType>(WeatherPrimary) : String.Empty,
            (WeatherSecondary != WeatherType.Unspecified) ? Enum.GetName<WeatherType>(WeatherSecondary) : String.Empty
        );
    }
}
