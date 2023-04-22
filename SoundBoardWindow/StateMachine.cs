using System;
using System.Collections.Generic;

/// <summary>
/// Holds current general use states for the application
/// </summary>
/// 

public enum DockPositions
{
    Left,
    Right, 
	Top, 
	Bottom
}

public enum colorSchemes
{
	Gray,
	Red,
	Blue,
	Yellow,
	Green
}

public class StateMachine
{
    List<SoundFile> _soundFiles;
    public List<SoundFile> SoundFiles { get; set; }

    UInt16 _opacity;
    public UInt16 Opacity { get; set; }

    bool _drawOverApps;
    public bool DrawOverApps { get; set; }

    DockPositions _currDockPos;
    public DockPositions CurrDockPos { get; set; }

    public bool PlayingSound { get; set; }

    public StateMachine()
    {
        SoundFiles = new List<SoundFile>();
        Opacity = 100;
        DrawOverApps = false;
        PlayingSound = false;
    }
}
