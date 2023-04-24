using System;
using System.Collections.Generic;
using System.Media;
using System.Windows.Media;

namespace SoundBoardWindow
{
    public class SoundFile
    {
        private string _name;
        private string _filePath;
        private int _playbackTime;
        private TagList _tags;
        private Uri _uri;

        /// <summary>
        /// Receive information from user input and then create a sound file object 
        /// </summary>
        /// <param name="name">name of soundFile</param>
        /// <param name="filePath">path to reach file stored locally</param>
        /// <param name="tags"></param>
        public SoundFile(string name, string filePath, TagList tags)
        {
            _name = name;
            _filePath = filePath;
            _uri = new Uri(filePath);
            _tags = tags;
        }

        public string Name { get; set; }
        public string FilePath { get; set; }
        public int playbackTime { get; }
        public List<Tag> tags { get; }
        public Uri uri { get; }
    }
}