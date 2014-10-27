using System;
using System.Windows;
using Microsoft.Phone.Controls;

namespace Conteneurs
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();

            // Sample code to localize the ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Sample code for building a localized ApplicationBar
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Set the page's ApplicationBar to a new instance of ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Create a new button and set the text value to the localized string from AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Create a new menu item with the localized string from AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}
        private void OnGridButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Grid.xaml", UriKind.RelativeOrAbsolute));
        }

        private void OnScrollViewerButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScrollViewer.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}