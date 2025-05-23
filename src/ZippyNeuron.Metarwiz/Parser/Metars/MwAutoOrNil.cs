﻿using System;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Metars;

public class MwAutoOrNil : MetarItem
{
    private readonly string _type;
    
    internal MwAutoOrNil(Match match)
    {
        _ = match ?? throw new ArgumentNullException(nameof(match));
        
        _type = match.Groups["TYPE"].Value;
    }

    public bool IsAuto => _type == "AUTO";
    public bool IsNil => _type == "NIL";

    internal static string Pattern => @"( )(?<TYPE>AUTO|NIL)";

    public override string ToString()
    {
        return _type;
    }
}
