using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace StatePattern.State
{
   public  class Player
    {
        public State State { get; set; }

        public Player(State state)
        {
            this.ChangeState(state);
        }
        public void ChangeState(State state)
        {
            this.State = state;
            state.setPlayer(this);

        }


        public void Play(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            State.PlayButton(mediaPlayer, Music, mainWindow);
        }

        public void Pause(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            State.PauseButton(mediaPlayer, Music, mainWindow);
        }

        public void Stop(MediaPlayer mediaPlayer, ObservableCollection<Music> Music, MainWindow mainWindow)
        {
            State.StopButton(mediaPlayer, Music, mainWindow);
        }

        public void Time(MediaPlayer mediaPlayer, TimeSpan timeSpan, MainWindow mainWindow)
        {
            State.TimePlayer(mediaPlayer, timeSpan, mainWindow);
        }
    }
}
