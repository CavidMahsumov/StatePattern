using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StatePattern.State
{
    public abstract class State
    {
        public Player Player { get; set; }
        public void setPlayer(Player player)
        {
            this.Player = player;
        }
        abstract public void PlayButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow);
        abstract public void PauseButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow);
        abstract public void StopButton(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow);
        abstract public void TimePlayer(MediaPlayer mediaPlayer, TimeSpan timeSpan, MainWindow mainWindow);

    }
}
