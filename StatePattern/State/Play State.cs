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
    public class PlayState : State
    {
        MediaPlayer MediaPlayer { get; set; }
        public PlayState(MediaPlayer mediaPlayer)
        {
            MediaPlayer = mediaPlayer;
            
        }

        public override void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MessageBox.Show("Test");
        }

        public override void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MediaPlayer.Play();
        }

        public override void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            MessageBox.Show("Test");

        }

        public override void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, MainWindow mainWindow)
        {
            MessageBox.Show("Test");

        }
    }
}
