using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using OrientationResolution.Resources;

namespace OrientationResolution
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            OrientationChanged += OnOrientationChanged;
        }

        private void OnOrientationChanged(object sender, OrientationChangedEventArgs e)
        {          
            switch (e.Orientation)
            {

                case PageOrientation.Portrait:
                case PageOrientation.PortraitUp:
                case PageOrientation.PortraitDown:
                    Grid.SetColumn(EcouterAlbumButton, 0);
                    Grid.SetRowSpan(ListePistes, 1);
                    Grid.SetRow(ListePistes, 1);    

                    break;
                case PageOrientation.Landscape:
                case PageOrientation.LandscapeLeft:
                case PageOrientation.LandscapeRight:
                    Grid.SetColumn(EcouterAlbumButton, 1);
                    Grid.SetRow(ListePistes, 0);    
                    Grid.SetRowSpan(ListePistes, 2);    
                    break;

            }
        }
    }
}