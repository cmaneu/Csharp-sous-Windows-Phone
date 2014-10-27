using System;
using System.Collections.Generic;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;

namespace Controles.Listes
{
    public partial class Longlistselector : PhoneApplicationPage
    {
        public Longlistselector()
        {
            InitializeComponent();
            List<Contact> donnees = new List<Contact>();
            donnees.Add(new Contact() { Nom = "Delgado", Prenom = "Edward", Email = "edelgado@outlook.com" });
            donnees.Add(new Contact() { Nom = "Estrate", Prenom = "Doris", Email = "dorise@outlook.com" });
            donnees.Add(new Contact() { Nom = "Chiaramini", Prenom = "Héléna", Email = "hele66@gmail.com" });
            donnees.Add(new Contact() { Nom = "Selen", Prenom = "Andrea", Email = "ase@outlook.com" });

            ListeSimple.ItemsSource = donnees;

            List<dynamic> albums = new List<dynamic>();
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/fe781ecd9879a82beed80f6d3e80745b/200x200-000000-80-0-0.jpg"), Titre = "PRISM" });
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/063d0b1eccd4d08ed2ebad075b754a05/200x200-000000-80-0-0.jpg"), Titre = "Delta Machine" });
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/914db9146f330d0a2969d157872da5eb/200x200-000000-80-0-0.jpg"), Titre = "racine carrée" });
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/615db2012ca3877aee3da15e5e7f7017/200x200-000000-80-0-0.jpg"), Titre = "If you wait" });
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/7e8314f4280cffde363547a495a260bc/250x250-000000-80-0-0.jpg"), Titre = "Night Visions" });
            albums.Add(new { PochetteImageUri = new Uri("http://cdn-images.deezer.com/images/cover/dffef0ec67705fdca2b1dd9f55a5abb3/250x250-000000-80-0-0.jpg"), Titre = "The 2nd Law" });
            

            ListeGrille.ItemsSource = albums;



            List<Region<Ville>> regions = new List<Region<Ville>>();

            Region<Ville> europe = new Region<Ville>();
            europe.Key = "Europe";
            europe.Add(new Ville() { Nom = "Paris", ImageUri = new Uri("http://static4.wikia.nocookie.net/__cb20131213104912/disney/images/f/f6/Eiffel_Tower,_Paris.jpg") });
            europe.Add(new Ville() { Nom = "Lyon", ImageUri = new Uri("http://www.youthhostel.ch/system/ck_assets/uploads/866/content/lyon-hostels-7617853.jpg") });
            europe.Add(new Ville() { Nom = "Marseille", ImageUri = new Uri("http://www.home-hunts.net/wp-content/uploads/2013/07/Marseille-corniche.jpg") });
            europe.Add(new Ville() { Nom = "Dublin", ImageUri = new Uri("http://cdni.condenast.co.uk/646x430/d_f/dublin_cnt_24nov09_iStock_b.jpg") });
            regions.Add(europe);

            Region<Ville> usa = new Region<Ville>();
            usa.Key = "United States";
            usa.Add(new Ville() { Nom = "San Francisco", ImageUri = new Uri("http://pnhpcalifornia.org/wp-content/uploads/2012/12/original.jpg") });
            usa.Add(new Ville() { Nom = "New York", ImageUri = new Uri("http://www.burgessyachts.com/media/adminforms/locations/n/e/new_york_1.jpg") });
            usa.Add(new Ville() { Nom = "Boston", ImageUri = new Uri("http://studentsforliberty.org/wp-content/uploads/2013/04/search-engine-optimization-boston1.jpg") });
            usa.Add(new Ville() { Nom = "Seattle", ImageUri = new Uri("http://media-cdn.tripadvisor.com/media/photo-s/00/18/8d/20/seattle.jpg") });
            regions.Add(usa);
            
            ListeGroupes.ItemsSource = regions;

        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

        }


        public class Region<T> : List<T>
        {
            public string Key { get; set; }
        }

        public class Ville
        {
            public string Nom { get; set; }
            public Uri ImageUri { get; set; }
        }

        public class Contact
        {
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Email { get; set; }
        }
    }
}