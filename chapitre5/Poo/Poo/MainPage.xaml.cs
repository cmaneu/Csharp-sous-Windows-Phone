using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Poo.Resources;

namespace Poo
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            //Ligne ligneNormale = new Ligne("Ligne 1", 12);
            //Console.WriteLine(ligneNormale.GetDescription());

            LigneTrain ligneParisToulouse = new LigneTrain("Paris-Toulouse", 5, "SNCF");
            Console.WriteLine(ligneParisToulouse.GetDescription());

            Ligne ligneParisToulouseClasseBase = new LigneTrain("Paris-Toulouse", 5, "SNCF");
            Console.WriteLine(ligneParisToulouseClasseBase.GetDescription());
        }

        private void OnBoutonCalculCkicked(object sender, RoutedEventArgs e)
        {
            LigneTrain ligneParisToulouseClasseBase = new LigneTrain("Paris-Toulouse", 5, "SNCF");
            ligneParisToulouseClasseBase.GetDescription();
        }
            
    }
}