using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Media;

public class SoundFile
{
	private string _name { get; set; }
	private string _filePath { get; set; }
    private int _soundLength {  get; set; }
    private List<string> _tags {  get; set; }
    private Uri uri { get; set; }

    /// <summary>
    /// Receive information from user input and then create a sound file object 
    /// </summary>
    /// <param name="name">name of soundFile</param>
    /// <param name="filePath">path to reach file stored locally</param>
    /// <param name="soundLength"></param>
    /// <param name="tags"></param>
    public SoundFile(string name, string filePath, int soundLength, List<string> tags)
	{
        MediaPlayer player2 = new MediaPlayer();

	}

}
