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

    public class TagList
    {
        private List<Tag> _usedTags;
        public int Count { get
            {
                return ListOfTags.Count;
            }
                }

        public TagList AllTags { get; set; }
        public List<Tag> ListOfTags { get; set; }
        public bool IsEditMode { get; set; }
        public StackPanel DrawPanel { get; set; }
        public StateMachine MasterStateMachine { get; set; }
        public TagList(StateMachine sm) {
            Debug.WriteLine("\n\n New Taglist\n\n");
            MasterStateMachine = sm;
            _usedTags = new List<Tag>();
            ListOfTags = new List<Tag>();
            DrawPanel = new StackPanel();
            Debug.WriteLine("FInished tl init\n\n");
        }

        public TagList CopyList()
        {

            return new TagList(MasterStateMachine);
            
        }

        public void Add(Tag tag)
        {
            Debug.WriteLine("\n\nTagList.Add call " + tag.Name);
            
            if (MasterStateMachine.Tags.Contains(tag)) {
                Debug.WriteLine("Already included");
                return;
            }

            MasterStateMachine.ListOfTags.Add(tag);
            if (tag.Included && !_usedTags.Contains(tag))
                _usedTags.Add(tag);
            Debug.WriteLine(this);
            UpdatePanel();
        }

        public bool Contains(Tag tag)
        {
            Debug.WriteLine("\n\nTagList.Contains Call: " + tag.Name);
            for(int i = 0; i < MasterStateMachine.ListOfTags.Count; i++)
            {
                if (MasterStateMachine.ListOfTags[i].Name == tag.Name)
                {
                    Debug.WriteLine("Tag Found");
                    return true;
                }
            }
            Debug.WriteLine("Tag Not Found");
            return false;
        }

        public bool Contains(SoundFile sf)
        {
            for (int i = 0; i < MasterStateMachine.ListOfSoundFiles.Count; i++)
            {
                if (MasterStateMachine.ListOfSoundFiles[i].Name == sf.Name)
                    return true;
            }
            return false;
        }

        

        public void Toggle(Tag tag)
        {
            if (!MasterStateMachine.ListOfTags.Contains(tag))
                return;


            tag.Included = !tag.Included;

            Debug.WriteLine(this);
        }


        public void UpdatePanel()
        {
            
            Debug.WriteLine("\n\nTagList.UpdatePanel call\n\n");
            DrawPanel.Children.Clear();
            if (!IsEditMode)
            {
                var wp = new WrapPanel();
                DrawPanel.Children.Add(wp);
                foreach (Tag tag in ListOfTags)
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

            foreach (Tag tag in ListOfTags)
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
            for (int i = 0; i < MasterStateMachine.ListOfTags.Count; i++)
            {
                str += "\n    " + MasterStateMachine.ListOfTags[i];
            }
            return str + "\n\n\n";
        }
    }

    public class Library
    {
        private List<SoundFile> ListOfSoundFiles { get; set; }
        public TagList TagsList { get; set; }
        public StateMachine MasterStateMachine { get; set; }
        public List<Tag> ListOfTags { get; set; }

        public Library(StateMachine sm)
        {
            Debug.WriteLine("\n\nNew Library\n\n");
            MasterStateMachine = sm;
            SoundFiles = sm.ListOfSoundFiles;

            ListOfTags = sm.ListOfTags;
            TagsList = sm.Tags;

            

        }

        public void add(SoundFile sf)
        {
            Debug.WriteLine("\n\nLibrary.add call: " + sf);
            try
            {
                SoundFiles.Add(sf);
                for(int i = 0; i < sf.Tags.Count; i++)
                {
                    var tag = sf.ListOfTags[i];

                    //ignores iteration if tag is already in list
                    if (TagsList.Contains(tag))
                        continue;

                    TagsList.Add(tag);
                }
            }
            catch(Exception e)
            {
                Console.WriteLine("Error in 'Library.add':\n" + e.Message);
            }
        }

        public List<SoundFile> SoundFiles { get; }
        public int FileCount { get; }
    }
}
