﻿using System;
using System.Text.RegularExpressions;

namespace ZippyNeuron.Metarwiz.Parser.Metars;

public class MwLocation : MetarItem
{
    private readonly string _icao;

    internal MwLocation(Match match)
    {
        _ = match ?? throw new ArgumentNullException(nameof(match));
        
        _icao = match.Groups["ICAO"].Value;
    }

    public string ICAO => _icao;

    internal static string Pattern => @"^METAR( )(?<ICAO>[A-Z]{4})";

    public override string ToString()
    {
        return _icao;
    }
}
