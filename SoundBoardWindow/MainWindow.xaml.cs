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

namespace SoundBoardWindow  
{
    // Create a class that implements ICommand and accepts a delegate.
    public class SimpleDelegateCommand : ICommand
    {
        // Specify the keys and mouse actions that invoke the command. 
        public Key GestureKey { get; set; }
        public ModifierKeys GestureModifier { get; set; }
        //public MouseAction MouseGesture { get; set; } //wont be using this

        Action<object> _executeDelegate;

        public SimpleDelegateCommand(Action<object> executeDelegate)
        {
            _executeDelegate = executeDelegate;
        }

        public void Execute(object parameter)
        {
            _executeDelegate(parameter);
        }

        public bool CanExecute(object parameter) { return true; }
        public event EventHandler CanExecuteChanged;
    }




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

        public SimpleDelegateCommand playSoundCommand, pauseSoundCommand, skipSoundCommand, rotateGUIPosClockwiseCommand, toggleDrawOverAppsCommand;

        private void InitializeCommand()
        {
            
        }


    }



}
