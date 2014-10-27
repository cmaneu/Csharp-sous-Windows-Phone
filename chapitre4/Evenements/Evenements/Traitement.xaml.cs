using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using System.Windows.Threading; // A ajouter
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Evenements
{
    public partial class Traitement : PhoneApplicationPage
    {
        private DispatcherTimer _timer;

        public Traitement()
        {
            InitializeComponent();
        }
       
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _timer = new DispatcherTimer();
            _timer.Interval = new TimeSpan(0,0,1);
            _timer.Tick += TimerOnTick;
            _timer.Tick += TimerOnTickColor;
            _timer.Start();
        }

        private void TimerOnTickColor(object sender, EventArgs e)
        {
            var color = Color.FromArgb(255, 
                                        BitConverter.GetBytes(DateTime.Now.Minute)[0], 
                                        BitConverter.GetBytes(DateTime.Now.Second)[0], 
                                        BitConverter.GetBytes(DateTime.Now.Millisecond)[0]);
            LayoutRoot.Background = new SolidColorBrush(color);
        }

        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            _timer.Stop();
            _timer.Tick -= TimerOnTick;
            _timer.Tick -= TimerOnTickColor;
        }

        private void TimerOnTick(object sender, EventArgs eventArgs)
        {
            tb_heure.Text = string.Format("Il est {0:hh:mm:ss}", DateTime.Now);
        }
    }
}