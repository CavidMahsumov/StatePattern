using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace StatePattern.State
{
    public class TimeState : State
    {
        MediaPlayer MediaPlayer { get; set; }
        public TimeState(MediaPlayer mediaPlayer)
        {
            MediaPlayer = mediaPlayer;
        }
        public override void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MessageBox.Show("Test");
        }

        public override void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MessageBox.Show("Test");

        }

        public override void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MessageBox.Show("Test");

        }

        public override void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, MainWindow mainWindow)
        {
            mainWindow.CurrentTimelbl.Content = string.Format( mediaPlayer.Position.ToString(@"mm\:ss")) ; ;;
            mainWindow.TotalTime.Content = string.Format(mediaPlayer.NaturalDuration.TimeSpan.ToString(@"mm\:ss"));
            mainWindow.SLider.Visibility = Visibility.Visible;

            timeSpan = mediaPlayer.NaturalDuration.TimeSpan;

            mainWindow.SLider.Minimum = 0;
            mainWindow.SLider.Maximum = mediaPlayer.NaturalDuration.TimeSpan.TotalSeconds;
            mainWindow.SLider.SmallChange = 1;
            mainWindow.SLider.LargeChange = Math.Min(10, timeSpan.Seconds / 10);

            mainWindow.SLider.Value = mediaPlayer.Position.TotalSeconds;
        }
    }
}
