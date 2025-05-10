using System;
using System.Collections.Generic;
using ZippyNeuron.Metarwiz.Parser.Metars;
using ZippyNeuron.Metarwiz.Parser.Remarks;

namespace ZippyNeuron.Metarwiz.Parser;

internal static class MetarParserItemTypes
{
    internal static IEnumerable<Type> MetarTypesToParse = new Type[]
    {
        typeof(MwLocation),
        typeof(MwMetar),
        typeof(MwSurfaceWindGroup),
        typeof(MwVisibilityGroup),
        typeof(MwWindShearGroup),
        typeof(MwAutoOrNil),
        typeof(MwCloud),
        typeof(MwNoSig),
        typeof(MwPressure),
        typeof(MwRecentWeather),
        typeof(MwRunwayVisualRange),
        typeof(MwTemperature),
        typeof(MwTimeOfObservation),
        typeof(MwWeather),
        typeof(MwStateOfSeaSurface),
        typeof(MwStateOfRunway)
    };

    internal static IEnumerable<Type> RemarkTypesToParse = new Type[]
    {
        typeof(RwRemarks),
        typeof(RwSurfaceTowerVisibilityGroup),
        typeof(RwVariableCeilingGroup),
        typeof(RwPeakWindGroup),
        typeof(RwWindShiftGroup),
        typeof(RwAutomatedStation),
        typeof(RwHourlyPrecipitation),
        typeof(RwHourlyTemperature),
        typeof(RwNeedsMaintenance),
        typeof(RwPressureTendency),
        typeof(RwSeaLevelPressure),
        typeof(RwSixHourMaxTemperature),
        typeof(RwSixHourMinTemperature),
        typeof(RwSixHourPrecipitation),
        typeof(RwTwentyFourHourPrecipitation),
    };
}
