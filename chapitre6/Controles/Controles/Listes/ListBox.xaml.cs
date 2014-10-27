using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Controles.Listes
{
    public partial class ListBox : PhoneApplicationPage
    {
        public ListBox()
        {
            InitializeComponent();
            List<Contact> donnees = new List<Contact>();
            donnees.Add(new Contact() { Nom = "Delgado", Prenom = "Edward", Email = "edelgado@outlook.com" });
            donnees.Add(new Contact() { Nom = "Estrate", Prenom = "Doris", Email = "dorise@outlook.com" });
            donnees.Add(new Contact() { Nom = "Chiaramini", Prenom = "Héléna", Email = "hele66@gmail.com" });
            donnees.Add(new Contact() { Nom = "Selen", Prenom = "Andrea", Email = "ase@outlook.com" });

        

            Liste.ItemsSource = donnees;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
          
        }

        public class Contact
        {
            public string Nom { get; set; } 
            public string Prenom { get; set; } 
            public string Email { get; set; } 
        }
    }
}