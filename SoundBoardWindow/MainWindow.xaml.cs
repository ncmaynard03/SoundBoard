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
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AddSoundWindow _asd;
        public MediaPlayer Player { get; set; }
        public static MainWindow CurrentInstance { get; private set; }
        public Library Lib { get { return MasterStateMachine.MasterLibrary; } }
        public TagList Tags { get { return MasterStateMachine.Tags; } }

        public StateMachine MasterStateMachine { get; set; }
        public MainWindow() 
        {
            MasterStateMachine = new StateMachine();
            CurrentInstance = this;
            InitializeComponent();
            DataContext = this;


            Debug.WriteLine("\n\nWindow Initialized\n\n");
            //StateMachine initialization
            


            Player = new MediaPlayer();
            


            Debug.WriteLine("\n\nAbout to make first tag: ");
            Lib.TagsList.Add(new Tag("Explicit", true));
            Lib.TagsList.Add(new Tag("Song"));
            Lib.TagsList.Add(new Tag("Rick Rolled", true));
            Lib.TagsList.Add(new Tag("This is a really long tag"));

            //allows for capturing key modifiers with a specific key
            EventManager.RegisterClassHandler(typeof(Window),
                Keyboard.KeyDownEvent, new KeyEventHandler(KeyDown), true);
        }
        public void AddSound(object sender, RoutedEventArgs e)
        {

            _asd = new AddSoundWindow();
            Debug.WriteLine("New Sound Window");
            _asd.Show();
            Debug.WriteLine("Show");

            _asd.SelectFile();
            
        }

        
        //---------------------------------------MEDIA CONTROLS
        private void KeyDown(object sender, KeyEventArgs e)
        {
            if ((Keyboard.Modifiers & ModifierKeys.Alt) == ModifierKeys.Alt) // Is Alt key pressed
            {
                //Keybinding for play
                if (Keyboard.IsKeyDown(Key.Space))
                {
                    // do something here
                    if (MasterStateMachine.PlayingSound)
                        Player.Play();
                }
                //KeyBinding for stop
                else if (Keyboard.IsKeyDown(Key.O))
                {
                    if (MasterStateMachine.PlayingSound == true)
                    {
                        mediaUI.Stop();
                        MasterStateMachine.PlayingSound = false;
                    }
                }
            }
        }

        //---------------------------------------
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
