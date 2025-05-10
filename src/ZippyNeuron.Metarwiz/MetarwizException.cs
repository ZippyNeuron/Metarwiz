using System;

namespace ZippyNeuron.Metarwiz;

internal class MetarwizException : ApplicationException
{
    internal MetarwizException(string message) : base(message) { }
}
