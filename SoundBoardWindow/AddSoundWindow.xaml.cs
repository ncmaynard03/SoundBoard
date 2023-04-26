using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Diagnostics;
using System.ComponentModel;
using System.Text.RegularExpressions;

namespace SoundBoardWindow
{


    /// <summary>
    /// Interaction logic for AddSoundWindow.xaml
    /// </summary>
    public partial class AddSoundWindow : Window, INotifyPropertyChanged
    {
        private string _filePath;
        private string _fileName;
        private int _fileDuration;
        private OpenFileDialog ofd;

        public event PropertyChangedEventHandler PropertyChanged;

        public Library libr;
        public TagList Tags { get; set; }
        public StackPanel TagButtonStack { get; set; }
        public StateMachine MasterStateMachine { get; set; }
        public AddSoundWindow()
        {
            InitializeComponent();
            _filePath = _fileName = "";
            DataContext = this;
            _fileDuration = 0;
            MasterStateMachine = MainWindow.CurrentInstance.MasterStateMachine;

            ofd = new OpenFileDialog();
            Tags = MasterStateMachine.Tags;



            //for(int i = 0; i < lib.Tags.Count; i++)
            //{
            //    tags.Add(new Tag(lib.Tags[i]));
            //}
            libr = MasterStateMachine.MasterLibrary;
        }

        public void SelectFile(object sender=null, RoutedEventArgs e=null)
        {
            ofd.Filter = "Sound file | *.mp3";

            if (ofd.ShowDialog() == false)
                return;

            FilePath = ofd.FileName;
            FileName = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
            Tags.IsEditMode = true;
            TagButtonStack = TagBtnStack;
            TagButtonStack.Children.Clear();
            TagButtonStack.Children.Add(Tags.DrawPanel);
        }

        public string FileName{ get { return _fileName; } set
            { 
                if(_fileName != value)
                {
                    _fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }

        public string FilePath { get { return _filePath; }
            set
            {
                if (_filePath != value)
                {
                    _filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Z0-9,]+"); // regular expression to match anything that's not a letter, number, or comma
            e.Handled = regex.IsMatch(e.Text); // set Handled to true if the input doesn't match the regular expression
        }

        public virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var str = TagTextbox.Text;
            var newTags = str.Split(',');
            foreach(var i in newTags)
            {
                if (str != "")
                    libr.TagsList.Add(new Tag(i));
            }
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            var sf = new SoundFile(FileName, FilePath, libr.TagsList.CopyList());
            libr.add(sf);
            this.Close();
            MainWindow.CurrentInstance.DisplaySounds.Children.Add(NewSoundButton(sf));
        }

        private Button NewSoundButton(SoundFile sf)
        {
            var btn = new Button();
            btn.Content = sf.Name;
            btn.Click += (sender, args) =>
            {
                var player = MainWindow.CurrentInstance.Player;
                player.Open(sf.FileURI);
                player.Play();
            };
            btn.Width = 60;
            btn.Height = 30;
            return btn;
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            throw new NotImplementedException();
        }
    }

}
