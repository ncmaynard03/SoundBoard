using System;
using System.Collections.Generic;

/// <summary>
/// Holds current general use states for the application
/// </summary>
/// 
namespace SoundBoardWindow {
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
    public class StateMachine
    {
        //Have Library.cs talk to this list of SoundFiles
        public static bool PlayingSound { get; set; } = false;
        public static bool DrawOverApps { get; set; } = true;
        public static ushort Opacity { get; set; } = 100;
        public static DockPositions CurrDockPos { get; set; } = DockPositions.Left;
        //Have Library.cs talk to this list of tags
        public static TagList Tags { get; set; } = new TagList();
        public static List<Tag> ListOfTags { get; set; } = Tags.ListOfTags;
        public static List<SoundFile> ListOfSoundFiles { get; set; } = new List<SoundFile>();
        public static Library MasterLibrary { get; set; } = new Library();

    }
}