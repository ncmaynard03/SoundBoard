using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;
using System.Windows.Input;
using System.Security.Cryptography.X509Certificates;

namespace SoundBoardWindow  
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AddSoundWindow asd;
        MediaPlayer mp;

        public MainWindow()
        {
            InitializeComponent();
            mp = new MediaPlayer();

            //StateMachine initialization
            StateMachine.ListOfSoundFiles = new List<SoundFile>();
            StateMachine.Tags = new List<string>();
            StateMachine.Opacity = 100;
            StateMachine.DrawOverApps = false;
            StateMachine.CurrDockPos = DockPositions.Left;
            StateMachine.PlayingSound = false;
        }

        public void AddSound(object sender, RoutedEventArgs e)
        {
            asd = new AddSoundWindow();
            asd.Show();
            asd.SelectFile();
        }

        
        private void CommandBindingPlay_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //write functionality of Play button
        private void CommandBindingPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
           
        }
    }
    /*
    public class PlayKey : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBox.Show("Ctrl + ");
        }
    }

    // Create a class that implements ICommand and accepts a delegate.
    public class PlayCommandContext
    {
        public ICommand PlayCommand
        {
            get
            {
                return new PlayKey();
            }
        }
    }
    */



}
