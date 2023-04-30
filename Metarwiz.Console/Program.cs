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
        string metar = "METAR EGLC 221630Z AUTO 24008KT 9999 R32L/M0400V1200D +VCFG -RA BKN025 SCT040 M01/M10 Q1022 REFZRA WS R18C W15/S2 NOSIG RMK AO2 P1234 T00640036 $ PK WND 20032/25 58033 SLP125 10066 21012 60009 TWR VIS 1 70090 CIG 013V017 WSHFT 1715";

        IMetarwiz metarwiz = new Metarwiz();

        metarwiz.Parse(metar, null);

        Out("MwMetar",              GetProperties(metarwiz.Get<MwMetar>()));
        Out("MwLocation",           GetProperties(metarwiz.Get<MwLocation>()));
        Out("MwTimeOfObservation",  GetProperties(metarwiz.Get<MwTimeOfObservation>()));
        Out("MwAutoOrNil",          GetProperties(metarwiz.Get<MwAutoOrNil>()));
        Out("MwSurfaceWindGroup",   GetProperties(metarwiz.Get<MwSurfaceWindGroup>()));
        Out("MwVisibilityGroup",    GetProperties(metarwiz.Get<MwVisibilityGroup>()));
        Out("MwRunwayVisualRange",  GetProperties(metarwiz.Get<MwRunwayVisualRange>()));
        Out("MwWeather",            GetProperties(metarwiz.Get<MwWeather>()));
        foreach (MwCloud cloud in metarwiz.GetMany<MwCloud>())
            Out($"MwCloud",         GetProperties(cloud));
        Out("MwTemperature",        GetProperties(metarwiz.Get<MwTemperature>()));
        Out("MwPressure",           GetProperties(metarwiz.Get<MwPressure>()));
        foreach (MwRecentWeather cloud in metarwiz.GetMany<MwRecentWeather>())
            Out($"MwRecentWeather", GetProperties(cloud));
        Out("MwWindShearGroup",     GetProperties(metarwiz.Get<MwWindShearGroup>()));
        Out("MwStateOfSeaSurface",  GetProperties(metarwiz.Get<MwStateOfSeaSurface>()));
        //Out("MwStateOfRunway",      GetProperties(metarwiz.Get<MwStateOfRunway>()));
        Out("MwNoSig",              GetProperties(metarwiz.Get<MwNoSig>()));

        Out("RwRemarks", GetProperties(metarwiz.Get<RwRemarks>()));
        Out("RwAutomatedStation", GetProperties(metarwiz.Get<RwAutomatedStation>()));
        Out("RwHourlyPrecipitation", GetProperties(metarwiz.Get<RwHourlyPrecipitation>()));
        Out("RwHourlyTemperature", GetProperties(metarwiz.Get<RwHourlyTemperature>()));
        Out("RwNeedsMaintenance", GetProperties(metarwiz.Get<RwNeedsMaintenance>()));
        Out("RwPeakWindGroup", GetProperties(metarwiz.Get<RwPeakWindGroup>()));
        Out("RwPressureTendency", GetProperties(metarwiz.Get<RwPressureTendency>()));
        Out("RwSeaLevelPressure", GetProperties(metarwiz.Get<RwSeaLevelPressure>()));
        Out("RwSixHourMaxTemperature", GetProperties(metarwiz.Get<RwSixHourMaxTemperature>()));
        Out("RwSixHourMinTemperature", GetProperties(metarwiz.Get<RwSixHourMinTemperature>()));
        Out("RwSixHourPrecipitation", GetProperties(metarwiz.Get<RwSixHourPrecipitation>()));
        Out("RwSurfaceTowerVisibilityGroup", GetProperties(metarwiz.Get<RwSurfaceTowerVisibilityGroup>()));
        Out("RwTwentyFourHourPrecipitation", GetProperties(metarwiz.Get<RwTwentyFourHourPrecipitation>()));
        Out("RwVariableCeilingGroup", GetProperties(metarwiz.Get<RwVariableCeilingGroup>()));
        Out("RwWindShiftGroup", GetProperties(metarwiz.Get<RwWindShiftGroup>()));

        Out("Metar (Original)", $" | {metar}");
        Out("Metar (Processed)", $" | {metarwiz}");

        Out("Metar (Checksum)", $" | Passed: {metarwiz.ToString() == metar}");
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