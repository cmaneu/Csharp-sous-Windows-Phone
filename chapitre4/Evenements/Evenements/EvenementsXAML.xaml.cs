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

namespace Evenements
{
    public partial class EvenementsXAML : PhoneApplicationPage
    {
        public EvenementsXAML()
        {
            InitializeComponent();
        }

        private void BoutonTapped(object sender, GestureEventArgs e)
        {
            Button tappedBouton = sender as Button;
            if (tappedBouton != null)
            {
                MessageBox.Show(string.Format("Bonjour du bouton {0} en ({1},{2})", tappedBouton.Content, e.GetPosition(this).X, e.GetPosition(this).Y));
            }

            e.Handled = true;
        }

        private void PageTapped(object sender, GestureEventArgs e)
        {
            MessageBox.Show(string.Format("Page touchée en ({0},{1}) sur un objet {2}", e.GetPosition(this).X, e.GetPosition(this).Y ,e.OriginalSource.GetType()));
        }
    }
}