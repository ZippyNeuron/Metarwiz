using ZippyNeuron.Metarwiz.Parser;

namespace ZippyNeuron.Metarwiz;

public interface IMetarwiz
{
    public MetarwizResult Parse(string metar, string tag);

    public string ToString();
}