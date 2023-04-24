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
            InitializeCommand();
            mp = new MediaPlayer();

            //StateMachine initialization
            StateMachine.SoundFiles = new List<SoundFile>();
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

        private PlayCommand _playSoundCommand;
        public PlayCommand PlaySoundCommand { get { return _playSoundCommand; } }
            //, pauseSoundCommand, skipSoundCommand, rotateGUIPosClockwiseCommand, toggleDrawOverAppsCommand;

        //Initialize Keybinds
        private void InitializeCommand()
        {
            _playSoundCommand = new PlayCommand(x => this.Play_Sound(x));
            
            DataContext = this;
            PlaySoundCommand.GestureKey = Key.P;
            PlaySoundCommand.GestureModifier = ModifierKeys.Alt;
        }

        //plays sound after button push
        public void Play_Sound(object sf)
        {
            if (sf != null )
            {
                sf = sf as SoundFile;
                
            }

            MessageBox.Show("Play_Sound reached!");
        }

        //determine if can execute
        private void CommandBindingPlay_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        //write functionality of Play button
        private void CommandBindingPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MessageBox.Show("Play button clicked");
        }
    }

    // Create a class that implements ICommand and accepts a delegate.
    public class PlayCommand : ICommand
    {
        // Specify the keys and mouse actions that invoke the command. 
        public Key GestureKey { get; set; }
        public ModifierKeys GestureModifier { get; set; }

        Action<object> _executeDelegate;

        public PlayCommand(Action<object> executeDelegate)
        {
            _executeDelegate = executeDelegate;
        }

        
        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;
    }



}
