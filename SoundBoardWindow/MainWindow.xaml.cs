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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using Microsoft.Win32;

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

        public MainWindow()
        {
            InitializeComponent();
            _player = new MediaPlayer();
            Lib = new Library();

            CurrentInstance = this;
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

    }



}
