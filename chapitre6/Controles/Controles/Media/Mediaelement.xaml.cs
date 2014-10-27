using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Controles.Mutimedia
{
    public partial class Mediaelement : PhoneApplicationPage
    {
        public Mediaelement()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Media.Play();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Media.Pause();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Media.Stop();
        }

        private void UpdateButtonStatus()
        {
            PauseButton.IsEnabled = Media.CanPause;
            StopButton.IsEnabled = Media.CurrentState == MediaElementState.Playing;
            PlayButton.IsEnabled = !StopButton.IsEnabled;
        }

        private void OnMediaCurrentStateChanged(object sender, RoutedEventArgs e)
        {
            UpdateButtonStatus();
            switch (Media.CurrentState)
            {
                
                case MediaElementState.Opening:
                case MediaElementState.Individualizing:
                case MediaElementState.AcquiringLicense:
                case MediaElementState.Buffering:
                    Progression.IsIndeterminate = true;
                    break;
                case MediaElementState.Paused:
                case MediaElementState.Playing:
                case MediaElementState.Stopped:
                    Progression.IsIndeterminate = false;
                    break;
            }
        }
    }
}