using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class PageAchat2 : PhoneApplicationPage
    {
        public PageAchat2()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (!NavigationContext.QueryString.ContainsKey("typePaiement"))
            {
                MessageBox.Show("Erreur lors de la navigation vers cette page.");
                NavigationService.GoBack();
                return;
            }

            string typePaiement = NavigationContext.QueryString["typePaiement"];

            if (!NavigationContext.QueryString.ContainsKey("montant"))
            {
                MessageBox.Show("Erreur lors de la navigation vers cette page.");
                NavigationService.GoBack();
                return;
            }

            double montant = Convert.ToDouble(NavigationContext.QueryString["montant"]);

            TexteConfirmation.Text = string.Format("Votre achat de {0:C} sera débité de votre {1}.", montant, typePaiement == "cb" ? "carte bleue" : "compte La boutique du MP3");
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            var result = MessageBox.Show("Voulez-vous annuler votre achat ?", "CONFIRMATION D'ANNULATION", MessageBoxButton.OKCancel);
            if (result != MessageBoxResult.OK)
            {
                e.Cancel = true;
            }

        }

        private void OnConfirmationButtonTapped(object sender, GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PageAchatFinale.xaml", UriKind.Relative));
        }
    }
}