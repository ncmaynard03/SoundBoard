using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

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

        public StateMachine MasterStateMachine { get; set; }
        public MainWindow()
        {
            MasterStateMachine = new StateMachine();
            CurrentInstance = this;
            InitializeComponent();
            Debug.WriteLine("\n\nWindow Initialized\n\n");
            //StateMachine initialization
            


            Player = new MediaPlayer();
            Lib = new Library(MasterStateMachine);
            


            Debug.WriteLine("\n\nAbout to make first tag: ");
            Lib.TagsList.Add(new Tag("Explicit", true));
            Lib.TagsList.Add(new Tag("Tag2"));
            Lib.TagsList.Add(new Tag("Tag3"));
            Lib.TagsList.Add(new Tag("Tag4", true));
        }

        public void AddSound(object sender, RoutedEventArgs e)
        {
            _asd = new AddSoundWindow();
            Debug.WriteLine("New Sound Window");
            _asd.Show();
            Debug.WriteLine("Show");

            _asd.SelectFile();
            
        }


        private void ChangeMediaVolume(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            mediaUI.Volume = (double)volumeSlider.Value;
        }

        private void ChangeMediaSpeedRatio(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            mediaUI.SpeedRatio = (double)speedRatioSlider.Value;
        }

        private void Element_MediaOpened(object sender, EventArgs e)
        {
            if(mediaUI.NaturalDuration.HasTimeSpan)
                timelineSlider.Maximum = mediaUI.NaturalDuration.TimeSpan.TotalMilliseconds;
        }

        private void Element_MediaEnded(object sender, EventArgs e)
        {
            mediaUI.Stop();
        }

        private void SeekToMediaPosition(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            int SliderValue = (int)timelineSlider.Value;

            TimeSpan ts = new TimeSpan(0, 0, 0, 0, SliderValue);
            mediaUI.Position = ts;
        }

        void InitializePropertyValues()
        {
            mediaUI.Volume = (double)volumeSlider.Value;
            mediaUI.SpeedRatio = (double)speedRatioSlider.Value;
        }

        public Library Lib { get; }
        
        //---------------------------------------MEDIA CONTROLS
        private void CommandBindingPlay_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {e.CanExecute = true;}

        //functionality of Play button
        private void CommandBindingPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(MasterStateMachine.PlayingSound)
           Player.Play();
        }

        private void CommandBindingStop_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {e.CanExecute = true;}

        //functionality of Stop button
        private void CommandBindingStop_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(MasterStateMachine.PlayingSound == true)
            {
                mediaUI.Stop();
                MasterStateMachine.PlayingSound = false;
            }
        }

        private void CommandBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void CommandBindingAddSound_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {

        }

        private void CommandBindingAddSound_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
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
