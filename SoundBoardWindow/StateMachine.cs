using System;
using System.Collections.Generic;
using System.Diagnostics;

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
        public bool PlayingSound { get; set; } = false;
        public bool DrawOverApps { get; set; } = true;
        public ushort Opacity { get; set; } = 100;
        public DockPositions CurrDockPos { get; set; } = DockPositions.Left;
        //Havey.cs talk to this list of tags
        public List<Tag> ListOfTags { get; set; } = new List<Tag>();
        public List<SoundFile> ListOfSoundFiles { get; set; } = new List<SoundFile>();
        public Library MasterLibrary { get; set; } 
        public TagList Tags { get; set; }

        public StateMachine()
        {
            Debug.WriteLine("\n\nNew StateMachine\n\n");
            Tags = new TagList(this);
            ListOfTags = Tags.ListOfTags;
            MasterLibrary = new Library(this);
        }
    }
}