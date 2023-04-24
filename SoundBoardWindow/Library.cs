using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Diagnostics;

namespace SoundBoardWindow
{
    public class Tag
    {
        public Tag(string name, bool included=false)
        {
            Name = name;
            Included = included;
        }

        public string Name { get; set; }
        public bool Included { get; set; }
        public override string ToString()
        {
            return Name + (Included ? "- Included" : "");
        }
    }

<<<<<<< HEAD
    public class TagList
    {
        private List<Tag> _usedTags;

        public List<Tag> AllTags { get; set; }
        public bool IsEditMode { get; set; }
        public StackPanel DrawPanel { get; set; }

        public TagList() {
            _usedTags = new List<Tag>();
            AllTags = new List<Tag>();
            DrawPanel = new StackPanel();
            UpdatePanel();
        }

        public void Add(Tag tag)
        {
            
            if (AllTags.Contains(tag)) {
                Debug.WriteLine("Already included");
                return;
            }

            AllTags.Add(tag);
            if (tag.Included && !_usedTags.Contains(tag))
                _usedTags.Add(tag);
            Debug.WriteLine(this);
            UpdatePanel();
        }

        public bool Contains(Tag tag)
        {
            return AllTags.Contains(tag);
        }

        

        public void Toggle(Tag tag)
        {
            if (!AllTags.Contains(tag))
                return;

            tag.Included = !tag.Included;

            Debug.WriteLine(this);
        }


        public void UpdatePanel()
        {
            
            Debug.WriteLine("\n\nTagList.UpdateUI call\n\n");
            DrawPanel.Children.Clear();
            if (!IsEditMode)
            {
                var wp = new WrapPanel();
                DrawPanel.Children.Add(wp);
                foreach (Tag tag in AllTags)
                {
                    var text = "#" + tag.Name;
                    var l = new Label();
                    l.Content = text;
                    wp.Children.Add(l);
                }
                return;
            }

            //Edit mode
            var usedWP = new WrapPanel();
            var unusedWP = new WrapPanel();
            DrawPanel.Children.Add(usedWP);
            DrawPanel.Children.Add(new Separator());
            DrawPanel.Children.Add(unusedWP);

            foreach (Tag tag in AllTags)
            {
                Debug.WriteLine(tag);

                string text = (tag.Included ? "-" : "+") + tag.Name;
                Debug.WriteLine(text);

                Button button = new Button();
                button.Content = text;
                button.Click += (sender, args) =>
                {
                    Toggle(tag);
                    UpdatePanel();
                };
                button.Width = Double.NaN;

                if (tag.Included)
                {
                    if (!_usedTags.Contains(tag))
                        _usedTags.Add(tag);
                    
                    usedWP.Children.Add(button);
                }
                else
                {
                    if (_usedTags.Contains(tag))
                        _usedTags.Remove(tag);
                    unusedWP.Children.Add(button);
                }
            }
            return;
        }

        public override string ToString()
        {
            var str = "Used tags: ";
            for (int i = 0; i < _usedTags.Count; i++)
            {
                str += "\n    " + _usedTags[i];
            }
            str += "\nAll tags: ";
            for (int i = 0; i < AllTags.Count; i++)
            {
                str += "\n    " + AllTags[i];
            }
            return str + "\n\n\n";
        }
    }

=======
>>>>>>> 37f0a9d47b54d971f07b7550b3db4c030f16ec94
    public class Library
    {
        private List<SoundFile> _soundFiles;
        public TagList TagsList { get; set; }
        private int _fileCount;
        public List<Tag> ListOfTags { get; set; }

        public Library()
        {
            _soundFiles = new List<SoundFile>();
            ListOfTags = new List<Tag>();
            TagsList = new TagList();
            TagsList.AllTags = ListOfTags;
            _fileCount = 0;

            

            TagsList.IsEditMode = true;
            TagsList.UpdatePanel();
        }

        public void add(SoundFile sf)
        {
            Debug.WriteLine("\n\nLibrary.Add call\n\n");
            try
            {
                _soundFiles.Add(sf);
                for(int i = 0; i < sf.tags.Count; i++)
                {
                    var tag = sf.tags[i];

                    //ignores iteration if tag is already in list
                    if (TagsList.Contains(tag))
                        continue;

                    TagsList.Add(tag);
                    _fileCount++;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in 'Library.add':\n" + e.Message);
            }
        }

        public List<SoundFile> SoundFiles { get; }
        public List<Tag> AllTags { get; }
        public int FileCount { get; }
    }
}
