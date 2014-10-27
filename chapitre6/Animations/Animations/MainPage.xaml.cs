using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Animations
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnButtonTapped(object sender, GestureEventArgs e)
        {
            Button button = sender as Button;
            if(button == null || button.Tag == null)
                return;

            NavigationService.Navigate(new Uri(button.Tag.ToString(), UriKind.Relative));
        }
    }
}