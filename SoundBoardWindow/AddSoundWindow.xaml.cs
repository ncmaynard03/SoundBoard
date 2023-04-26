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
            Tags.IsEditMode = true;
            TagButtonStack = TagBtnStack;
            TagButtonStack.Children.Clear();
            TagButtonStack.Children.Add(Tags.DrawPanel);
        }

        private void SubmitBtn_Click(object sender, RoutedEventArgs e)
        {
            libr.Add(new SoundFile(FileName, FilePath, libr.TagsList.CopyList()), 13); //Fix add actual time variable
            foreach (var item in MasterStateMachine.MasterLibrary.SoundFiles)
            {
                Debug.WriteLine(item);
            }
            this.Close();
        }

        private void ClearBtn_Click(object sender, RoutedEventArgs e)
        {
            Tags.IsEditMode = true;
            foreach()
            
        }
    }

}
