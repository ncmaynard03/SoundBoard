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

namespace SoundBoardWindow
{


    /// <summary>
    /// Interaction logic for AddSoundWindow.xaml
    /// </summary>
    public partial class AddSoundWindow : Window, INotifyPropertyChanged
    {
        private string filePath;
        private string fileName;
        private OpenFileDialog ofd;

        public event PropertyChangedEventHandler PropertyChanged;

        public AddSoundWindow()
        {
            InitializeComponent();
            filePath = fileName = "";
            this.DataContext = this;
            ofd = new OpenFileDialog();
            Console.WriteLine("\n\nNew Dialogue\n\n");
            //SelectFile();
        }

        public void SelectFile(object sender=null, RoutedEventArgs e=null)
        {


            ofd.Filter = "Sound file | *.mp3";

            if (ofd.ShowDialog() == false)
            {
                Debug.WriteLine("\n\nNope\n\n");
                return;
            }

            Debug.WriteLine(ofd.FileName);
            FilePath = ofd.FileName;
            FileName = System.IO.Path.GetFileNameWithoutExtension(ofd.FileName);
            //DataContext = this;
            Console.WriteLine(FileName + "\n\n");

        }

        public string FileName { get { return fileName; } set
            {
               
                if(fileName != value)
                {
                    fileName = value;
                    OnPropertyChanged("FileName");
                }
            }
        }

        public string FilePath { get { return filePath; }
            set
            {

                if (filePath != value)
                {
                    filePath = value;
                    OnPropertyChanged("FilePath");
                }
            }
        }
        public virtual void OnPropertyChanged(string propertyName)
        {
            Console.WriteLine("\n\nProperty Changed\n\n");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

}
