using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Media;
using System.Diagnostics;
using System.Windows.Controls;

namespace SoundBoardWindow
{
    public class SoundFile
    {

        /// <summary>
        /// Receive information from user input and then create a sound file object 
        /// </summary>
        /// <param name="name">name of soundFile</param>
        /// <param name="filePath">path to reach file stored locally</param>
        /// <param name="tags"></param>
        public SoundFile(string name, string filePath, TagList tags, int playbackTime, Button button)
        {
            Name = name;
            FilePath = filePath;
            FileURI = new Uri(filePath);
            PlayBackTime = playbackTime;
            Tags = tags;
            ListOfTags = tags.ListOfTags;
            Button = button;
            Debug.WriteLine("New soundfile: " + this);
        }
        public string Name { get; set; }
        public string FilePath { get; set; }
        public int PlayBackTime { get; set; }
        public TagList Tags { get; set; }
        public List<Tag> ListOfTags { get; set; }
        public Uri FileURI { get; }
        public Button Button { get; set; }
        public bool CurrentTarget { get; set; }
        
        
        public override string ToString()
        {
            return Name + " (" + FilePath + ")" + PlayBackTime;
        }

        
    }
}