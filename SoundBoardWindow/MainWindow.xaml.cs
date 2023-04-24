﻿using System;
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
using System.Diagnostics;

namespace SoundBoardWindow  
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private AddSoundWindow _asd;
        private MediaPlayer _player;
        public static MainWindow CurrentInstance { get; private set; }

        public StateMachine MasterStateMachine { get; set; }
        public MainWindow()
        {
            MasterStateMachine = new StateMachine();
            CurrentInstance = this;
            InitializeComponent();
            Debug.WriteLine("\n\nWindow Initialized\n\n");
            //StateMachine initialization
            


            _player = new MediaPlayer();
            Lib = new Library(MasterStateMachine);


            Debug.WriteLine("\n\nAbout to make first tag: ");
            Lib.TagsList.Add(new Tag("Tag1", true));
            Lib.TagsList.Add(new Tag("Tag2"));
            Lib.TagsList.Add(new Tag("Tag3"));
            Lib.TagsList.Add(new Tag("Tag4", true));
        }

        public void AddSound(object sender, RoutedEventArgs e)
        {
            _asd = new AddSoundWindow();
            _asd.Show();
            _asd.SelectFile();
            
        }

        public void TogglePaused(Object Sender, MouseButtonEventArgs args)
        {
            MasterStateMachine.PlayingSound = !MasterStateMachine.PlayingSound;
        }

        void OnMouseDownPlayMedia(object sender, MouseButtonEventArgs args)
        {
            mediaUI.Play();
            InitializePropertyValues();
        }

        void OnMouseDownPauseMedia(object sender, MouseButtonEventArgs args)
        {
            mediaUI.Pause();
        }

        void OnMouseDownStopMedia(object sender, MouseButtonEventArgs args)
        {
            mediaUI.Stop();
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
        
        //---------------------------------------
        private void CommandBindingPlay_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {e.CanExecute = true;}

        //functionality of Play button
        private void CommandBindingPlay_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if(MasterStateMachine.PlayingSound)
           _player.Play();
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
