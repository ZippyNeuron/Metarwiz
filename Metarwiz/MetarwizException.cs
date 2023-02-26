using System;

namespace ZippyNeuron.Metarwiz;

public class MetarwizException : ApplicationException
{
    public MetarwizException(string message) : base(message) { }
}
