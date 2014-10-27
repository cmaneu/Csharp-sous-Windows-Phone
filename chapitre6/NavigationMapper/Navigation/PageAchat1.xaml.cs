using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Navigation
{
    public partial class PageAchat1 : PhoneApplicationPage
    {
        public PageAchat1()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!NavigationContext.QueryString.ContainsKey("albumId"))
            {
                MessageBox.Show("Erreur lors de la navigation vers cette page.");
                NavigationService.GoBack();
                return;
            }

            DataContext = AlbumSource.GetAlbum(Convert.ToInt32(NavigationContext.QueryString["albumId"]));
        }

        private void OnBoutonCbTapped(object sender, GestureEventArgs e)
        {
            Album albumCourant = DataContext as Album;
            if (albumCourant == null)
                return;

            NavigationService.Navigate(new Uri("/PageAchat2.xaml?typePaiement=cb&montant=" + albumCourant.Prix, UriKind.Relative));
        }

        private void OnBoutonCompteTapped(object sender, GestureEventArgs e)
        {
            Album albumCourant = DataContext as Album;
            if (albumCourant == null)
                return;

            NavigationService.Navigate(new Uri("/PageAchat2.xaml?typePaiement=compte&montant=" + albumCourant.Prix, UriKind.Relative));
        }
    }
}