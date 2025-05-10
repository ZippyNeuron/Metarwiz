using System.Linq;
using System.Text;
using ZippyNeuron.Metarwiz.Parser;
using ZippyNeuron.Metarwiz.Parser.Metars;
using ZippyNeuron.Metarwiz.Parser.Remarks;

namespace ZippyNeuron.Metarwiz.Console;

class Program
{
    static void Main(string[] args)
    {
        string metar = "METAR EGLC 221630Z AUTO 24008KT 9999 R32L/M0400V1200D +VCFG -RA BKN025 SCT040 M01/M10 Q1022 REFZRA WS R18C W15/S2 R27L/421594 NOSIG RMK AO2 P1234 T00640036 $ PK WND 20032/25 58033 SLP125 10066 21012 60009 TWR VIS 1 70090 CIG 013V017 WSHFT 1715";

        IMetarwiz metarwiz = new Metarwiz();

        var metarwizResult = metarwiz.Parse(metar, null);

        Out("MwMetar",              GetProperties(metarwizResult.Get<MwMetar>()));
        Out("MwLocation",           GetProperties(metarwizResult.Get<MwLocation>()));
        Out("MwTimeOfObservation",  GetProperties(metarwizResult.Get<MwTimeOfObservation>()));
        Out("MwAutoOrNil",          GetProperties(metarwizResult.Get<MwAutoOrNil>()));
        Out("MwSurfaceWindGroup",   GetProperties(metarwizResult.Get<MwSurfaceWindGroup>()));
        Out("MwVisibilityGroup",    GetProperties(metarwizResult.Get<MwVisibilityGroup>()));
        Out("MwRunwayVisualRange",  GetProperties(metarwizResult.Get<MwRunwayVisualRange>()));
        Out("MwWeather",            GetProperties(metarwizResult.Get<MwWeather>()));
        foreach (MwCloud cloud in metarwizResult.GetMany<MwCloud>())
            Out($"MwCloud",         GetProperties(cloud));
        Out("MwTemperature",        GetProperties(metarwizResult.Get<MwTemperature>()));
        Out("MwPressure",           GetProperties(metarwizResult.Get<MwPressure>()));
        foreach (MwRecentWeather cloud in metarwizResult.GetMany<MwRecentWeather>())
            Out($"MwRecentWeather", GetProperties(cloud));
        Out("MwWindShearGroup",     GetProperties(metarwizResult.Get<MwWindShearGroup>()));
        Out("MwStateOfSeaSurface",  GetProperties(metarwizResult.Get<MwStateOfSeaSurface>()));
        Out("MwStateOfRunway",      GetProperties(metarwizResult.Get<MwStateOfRunway>()));
        Out("MwNoSig",              GetProperties(metarwizResult.Get<MwNoSig>()));

        Out("RwRemarks", GetProperties(metarwizResult.Get<RwRemarks>()));
        Out("RwAutomatedStation", GetProperties(metarwizResult.Get<RwAutomatedStation>()));
        Out("RwHourlyPrecipitation", GetProperties(metarwizResult.Get<RwHourlyPrecipitation>()));
        Out("RwHourlyTemperature", GetProperties(metarwizResult.Get<RwHourlyTemperature>()));
        Out("RwNeedsMaintenance", GetProperties(metarwizResult.Get<RwNeedsMaintenance>()));
        Out("RwPeakWindGroup", GetProperties(metarwizResult.Get<RwPeakWindGroup>()));
        Out("RwPressureTendency", GetProperties(metarwizResult.Get<RwPressureTendency>()));
        Out("RwSeaLevelPressure", GetProperties(metarwizResult.Get<RwSeaLevelPressure>()));
        Out("RwSixHourMaxTemperature", GetProperties(metarwizResult.Get<RwSixHourMaxTemperature>()));
        Out("RwSixHourMinTemperature", GetProperties(metarwizResult.Get<RwSixHourMinTemperature>()));
        Out("RwSixHourPrecipitation", GetProperties(metarwizResult.Get<RwSixHourPrecipitation>()));
        Out("RwSurfaceTowerVisibilityGroup", GetProperties(metarwizResult.Get<RwSurfaceTowerVisibilityGroup>()));
        Out("RwTwentyFourHourPrecipitation", GetProperties(metarwizResult.Get<RwTwentyFourHourPrecipitation>()));
        Out("RwVariableCeilingGroup", GetProperties(metarwizResult.Get<RwVariableCeilingGroup>()));
        Out("RwWindShiftGroup", GetProperties(metarwizResult.Get<RwWindShiftGroup>()));

        Out("Metar (Original)", $" | {metar}");
        Out("Metar (Processed)", $" | {metarwizResult}");
        Out("Metar (Checksum)", $" | Passed: {metarwizResult.ToString() == metar}");
    }

    private static void Out(string label, string value)
    {
        System.Console.WriteLine($"{label.PadRight(32)}{value}");
    }

    private static string GetProperties(MetarItem baseMetarItem)
    {
        var properties = baseMetarItem.GetType()
            .GetProperties()
            .Where(p => p.Name != "Pattern");

        if (!properties.Any())
        {
            return " | (No Properties)";
        }

        var builder = new StringBuilder();

        foreach(var property in properties)
        {
            builder.Append($" | {property.Name}: {property.GetValue(baseMetarItem, null)}");
        }

        return builder.ToString();
    }
}