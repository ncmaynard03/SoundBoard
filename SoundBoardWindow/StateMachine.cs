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

public enum ColorSchemes
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
    //Have Library.cs talk to this list of ListOfSoundFiles
    private static List<SoundFile> listOfSoundFiles;
    public static List<SoundFile> ListOfSoundFiles { get; set; }

    //Have Library.cs talk to this list of tags
    private static List<string> tags;
    public static List<string> Tags { get; set; }

    private static UInt16 opacity;
    public static UInt16 Opacity { get; set; }

    private static bool drawOverOtherApps;
    public static bool DrawOverApps { get; set; }

    private static DockPositions currDockPos;
    public static DockPositions CurrDockPos { get; set; }

    private static bool playingSound;
    public static bool PlayingSound { get; set; }

}
