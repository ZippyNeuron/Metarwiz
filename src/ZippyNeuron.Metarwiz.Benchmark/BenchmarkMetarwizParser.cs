using BenchmarkDotNet.Attributes;

namespace Metarwiz.Benchmark;

public class BenchmarkMetarwizParser
{
    [Benchmark]
    public void Metarwiz_Parse()
    {
        string metar =
            "METAR EGLC 221630Z AUTO 24008KT 9999 R32L/M0400V1200D +VCFG -RA BKN025 SCT040 M01/M10 Q1022 REFZRA WS R18C W15/S2 R27L/421594 NOSIG RMK AO2 P1234 T00640036 $ PK WND 20032/25 58033 SLP125 10066 21012 60009 TWR VIS 1 70090 CIG 013V017 WSHFT 1715";

        ZippyNeuron.Metarwiz.Metarwiz metarwiz = new();

        metarwiz.Parse(metar, null);
    }
}