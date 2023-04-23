using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoundBoardWindow
{
    public class TagButton
    {
        private string _name;
        public TagButton(string name)
        {
            _name = name;
        }

        public string Name { get; set; }
    }

    public class Library
    {
        private List<SoundFile> _soundFiles;
        private List<string> _tags;
        private int _fileCount;

        public Library()
        {
            _soundFiles = new List<SoundFile>();
            _tags = new List<string>();
            _fileCount = 0;
        }

        public void add(SoundFile sf)
        {
            try
            {
                _soundFiles.Add(sf);
                for(int i = 0; i < sf.tags.Count; i++)
                {
                    var tag = sf.tags[i];

                    //ignores iteration if tag is already in list
                    if (_tags.Contains(tag))
                        continue;

                    _tags.Add(tag);
                    _fileCount++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in 'Library.add':\n" + e.Message);
            }
        }

        public List<SoundFile> SoundFiles { get; }
        public List<string> Tags { get; }
        public int FileCount { get; }
    }
}
