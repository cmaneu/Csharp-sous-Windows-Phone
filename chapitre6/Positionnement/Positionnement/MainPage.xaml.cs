using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Positionnement
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBtnWidthHeightClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/WidthHeight.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnBtnMarginClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Marges.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnBtnAlignementsClicked(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Alignements.xaml", UriKind.RelativeOrAbsolute));
            
        }

    }
}