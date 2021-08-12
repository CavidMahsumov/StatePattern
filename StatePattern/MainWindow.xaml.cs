using StatePattern.State;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
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
using System.Windows.Threading;

namespace StatePattern
{

    public partial class MainWindow : Window
    {


        private bool _isDragging = false;

        public ObservableCollection<Music> Music { get; set; }

        public MainWindow()
        {
            string Filepath_1 = "../../Musicc/1.mp3";
            Music = new ObservableCollection<Music>
            {
                new Music
                {
                     Name=Filepath_1
                }
            };
            mediaPlayer.Open(new Uri(Music[0].Name, UriKind.RelativeOrAbsolute));



            this.DataContext = this;



            InitializeComponent();
        }


        public object selecti;

   

        string location = "";



        private MediaPlayer mediaPlayer = new MediaPlayer();

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            Player play = new Player(new PlayState(mediaPlayer));
            play.Play(mediaPlayer, Music, this);
            Timer();
        
        }

        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            Player play = new Player(new StopState(mediaPlayer));

            play.Stop(mediaPlayer, Music, this);

            Timer();
        }

        private void Pause_Click(object sender, RoutedEventArgs e)
        {
            Player play = new Player(new PauseState(mediaPlayer));

            play.Pause(mediaPlayer, Music, this);


            Timer();
        }

        public void Timer()
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            try
            {
                if (mediaPlayer.Source != null)
                {
                    TimeSpan ts = new TimeSpan();

                    Player play = new Player(new TimeState(mediaPlayer));
                    play.Time(mediaPlayer, ts, this);

                    
                }

            }
            catch (Exception)
            {

            }

        }


        private void TimeSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            _isDragging = true;
        }

        private void TimeSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            _isDragging = false;
            mediaPlayer.Position = TimeSpan.FromSeconds(SLider.Value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
