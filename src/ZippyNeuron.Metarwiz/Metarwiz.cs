using ZippyNeuron.Metarwiz.Parser;

namespace ZippyNeuron.Metarwiz;

public class Metarwiz : IMetarwiz
{
    public Metarwiz() { }

    public MetarwizResult Parse(string metar, string tag = "")
    {
        if (string.IsNullOrEmpty(metar))
            throw new MetarwizException("The report cannot be empty.");

        if (metar.Length < 5 || !metar.StartsWith("METAR"))
            throw new MetarwizException("The METAR report should start with METAR.");

        var parser = new MetarParser(metar, tag);

        parser.Parse();

        return new MetarwizResult(parser.Items, parser.Info);
    }
}