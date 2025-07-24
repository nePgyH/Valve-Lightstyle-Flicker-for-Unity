using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ValveLightstylePreset
{
    public string ID;       // Machine-readable ID (can be enum-like, for code comparisons)
    public string Name;     // User-friendly display name
    public string Pattern;  // Lightstyle pattern
}

public static class ValveLightstylePresets
{
    // List of predefined lightstyle presets.
    // You can add your own custom patterns here as needed by creating new LightstylePreset instances.
    public static readonly List<ValveLightstylePreset> All = new()
    {
        new ValveLightstylePreset { ID = "Normal", Name = "Normal", Pattern = "m" },
        new ValveLightstylePreset { ID = "FluorescentFlicker", Name = "Fluorescent flicker", Pattern = "mmamammmmammamamaaamammma" },
        new ValveLightstylePreset { ID = "SlowStrongPulse", Name = "Slow, strong pulse", Pattern = "abcdefghijklmnopqrstuvwxyzyxwvutsrqponmlkjihgfedcba" },
        new ValveLightstylePreset { ID = "SlowPulseNoblack", Name = "Slow pulse, noblack", Pattern = "abcdefghijklmnopqrrqponmlkjihgfedcba" },
        new ValveLightstylePreset { ID = "GentlePulse", Name = "Gentle pulse", Pattern = "jklmnopqrstuvwxyzyxwvutsrqponmlkj" },
        new ValveLightstylePreset { ID = "FlickerA", Name = "Flicker A", Pattern = "mmnmmommommnonmmonqnmmo" },
        new ValveLightstylePreset { ID = "FlickerB", Name = "Flicker B", Pattern = "nmonqnmomnmomomno" },
        new ValveLightstylePreset { ID = "CandleA", Name = "Candle A", Pattern = "mmmmmaaaaammmmmaaaaaabcdefgabcdefg" },
        new ValveLightstylePreset { ID = "CandleB", Name = "Candle B", Pattern = "mmmaaaabcdefgmmmmaaaammmaamm" },
        new ValveLightstylePreset { ID = "CandleC", Name = "Candle C", Pattern = "mmmaaammmaaammmabcdefaaaammmmabcdefmmmaaaa" },
        new ValveLightstylePreset { ID = "FastStrobe", Name = "Fast strobe", Pattern = "mamamamamama" },
        new ValveLightstylePreset { ID = "SlowStrobe", Name = "Slow strobe", Pattern = "aaaaaaaazzzzzzzz" },
        new ValveLightstylePreset { ID = "UnderwaterLightMutation", Name = "Underwater light mutation", Pattern = "mmnnmmnnnmmnn" }
    };

    // Helper method to find a preset by its ID.
    // Returns null if no preset with the given ID is found.
    public static ValveLightstylePreset GetByID(string id) => All.Find(p => p.ID == id);
}
