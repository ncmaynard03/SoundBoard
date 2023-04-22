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

/// <summary>
/// Holds all the global variables for the rest of the program to use.
/// </summary>
public static class StateMachine
{
    //Have Library.cs talk to this list of SoundFiles
    private static List<SoundFile> _soundFiles;
    public static List<SoundFile> SoundFiles { get; set; }

    //Have Library.cs talk to this list of tags
    private static List<string> _tags;
    public static List<string> Tags { get; set; }

    private static UInt16 _opacity;
    public static UInt16 Opacity { get; set; }

    private static bool _drawOverApps;
    public static bool DrawOverApps { get; set; }

    private static DockPositions _currDockPos;
    public static DockPositions CurrDockPos { get; set; }

    private static bool _playingSound;
    public static bool PlayingSound { get; set; }

}
