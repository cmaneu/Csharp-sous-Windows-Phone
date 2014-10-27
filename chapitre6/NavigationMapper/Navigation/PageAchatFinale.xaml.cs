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
    public partial class PageAchatFinale : PhoneApplicationPage
    {
        public PageAchatFinale()
        {
            InitializeComponent();
        }

        private void OnRetourBoutonTapped(object sender, GestureEventArgs e)
        {
            RetourPageAccueil();
        }

        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);
            e.Cancel = true;
            RetourPageAccueil();
        }

        private void RetourPageAccueil()
        {
            // Suppression de la PageAchat2
            NavigationService.RemoveBackEntry();

            // Suppression de la PageAchat1
            NavigationService.RemoveBackEntry();

            // Retour à la dernière page
            NavigationService.GoBack();
        }
    }
}