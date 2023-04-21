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

	private List<SoundFile> _soundFiles;
	private UInt16 Opacity { get; set; }
	bool DrawOverApps { get; set; }

	DockPositions _currDockPos;
	DockPositions CurrDockPos { get; set; }

	bool PlayingSound { get; set; }

	public StateMachine()
	{
		_soundFiles = new List<SoundFile>();
		Opacity = 100;
		DrawOverApps = false;
		PlayingSound = false;
	}
}
