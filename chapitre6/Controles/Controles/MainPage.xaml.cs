using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Controles.Resources;

namespace Controles
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnBtnSampleClicked(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button == null || button.Tag == null)
            {
                MessageBox.Show("Aucune page n'est indiquée sur ce bouton.");
                return;
            }

            Uri navigateUri;
            if (!Uri.TryCreate(button.Tag.ToString(), UriKind.RelativeOrAbsolute, out navigateUri))
            {
                MessageBox.Show("La page indiquée a un format incorrect.");
                return;
            }

            NavigationService.Navigate(navigateUri);
        }
    }
}