using System;
using System.Windows;
using Windows.UI.Notifications;
using Windows.UI.StartScreen;
using Microsoft.Phone.Controls;
using NotificationsExtensions.TileContent;
using NotificationsExtensions.ToastContent;

namespace Notifications
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void OnMajTuilePrincipaleClicked(object sender, RoutedEventArgs e)
        {
            ITileWide310x150ImageAndText02 tuileLarge = TileContentFactory.CreateTileWide310x150ImageAndText02();
            tuileLarge.TextCaption1.Text = "Ecoutez le nouvel album d'Ellie Goulding";
            tuileLarge.Image.Src = "http://api.deezer.com/artist/311820/image";
            var tuileCarree = TileContentFactory.CreateTileSquare150x150PeekImageAndText01();
            tuileCarree.TextHeading.Text = "Nouvel album d'Ellie Goulding";
            tuileCarree.Image.Src = "http://api.deezer.com/artist/311820/image";
            tuileLarge.Square150x150Content = tuileCarree;

            TileNotification tileNotification = new TileNotification(tuileLarge.GetXml());
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification);
        }

        private void OnMajTuilePrincipale2Clicked(object sender, RoutedEventArgs e)
        {
            TileUpdateManager.CreateTileUpdaterForApplication().EnableNotificationQueue(true);

            // Créer template 1
            ITileWide310x150ImageAndText02 tuileLarge1 = TileContentFactory.CreateTileWide310x150ImageAndText02();
            tuileLarge1.TextCaption1.Text = "Ecoutez le nouvel album d'Ellie Goulding";
            tuileLarge1.Image.Src = "http://api.deezer.com/artist/311820/image?size=400x400";
            var tuileCarree1 = TileContentFactory.CreateTileSquare150x150PeekImageAndText01();
            tuileCarree1.TextHeading.Text = "Nouvel album d'Ellie Goulding";
            tuileCarree1.Image.Src = "http://api.deezer.com/artist/311820/image?size=400x400";
            tuileLarge1.Square150x150Content = tuileCarree1;
            TileNotification tileNotification1 = new TileNotification(tuileLarge1.GetXml());
            tileNotification1.Tag = "actu-sortie";
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification1);

            // Créer template 2
            ITileWide310x150ImageAndText02 tuileLarge2 = TileContentFactory.CreateTileWide310x150ImageAndText02();
            tuileLarge2.TextCaption1.Text = "Le retour de Katy Perry sur la scène";
            tuileLarge2.Image.Src = "http://api.deezer.com/artist/144227/image?size=400x400";
            var tuileCarree2 = TileContentFactory.CreateTileSquare150x150PeekImageAndText01();
            tuileCarree2.TextHeading.Text = "Katy Perry en tournée";
            tuileCarree2.Image.Src = "http://api.deezer.com/artist/144227/image?size=400x400";
            tuileLarge2.Square150x150Content = tuileCarree2;
            TileNotification tileNotification2 = new TileNotification(tuileLarge2.GetXml());
            tileNotification2.Tag = "actu-tournee";
            TileUpdateManager.CreateTileUpdaterForApplication().Update(tileNotification2);
        }

        private async void OnCreeTuileSecondaireClicked(object sender, RoutedEventArgs e)
        {
            string identifiantTuile = "MonApplication.Album.6982745";
            string arguments = "/AlbumPage.xaml?albumId=6982745";
            SecondaryTile tuileSecondaire = new SecondaryTile(identifiantTuile, "Texte de la tuile", arguments, new Uri("ms-appx:///Assets/SquareTile150x150.png"), TileSize.Square150x150);
            tuileSecondaire.VisualElements.ShowNameOnSquare150x150Logo = true;
            tuileSecondaire.VisualElements.ForegroundText = ForegroundText.Dark;
            await tuileSecondaire.RequestCreateAsync();
        }

        private void OnMajTuileSecondaireClicked(object sender, RoutedEventArgs e)
        {
            ITileWide310x150ImageAndText02 tuileLarge = TileContentFactory.CreateTileWide310x150ImageAndText02();
            tuileLarge.TextCaption1.Text = "Ecoutez le nouvel album d'Ellie Goulding";
            tuileLarge.Image.Src = "http://api.deezer.com/artist/311820/image";
            var tuileCarree = TileContentFactory.
            CreateTileSquare150x150PeekImageAndText01();
            tuileCarree.TextHeading.Text = "Nouvel album d'Ellie Goulding";
            tuileCarree.Image.Src = "http://api.deezer.com/artist/311820/image";
            tuileLarge.Square150x150Content = tuileCarree;
            TileNotification tile = new TileNotification(tuileLarge.GetXml());
            TileUpdateManager.CreateTileUpdaterForSecondaryTile("MonApplication.Album.6982745").Update(tile);
        }

        private async void OnSupprimeTuileSecondiareClicked(object sender, RoutedEventArgs e)
        {
            if (Windows.UI.StartScreen.SecondaryTile.Exists("MonApplication.Album.6982745"))
            {
                SecondaryTile secondaryTile = new SecondaryTile("MonApplication.Album.6982745");
                await secondaryTile.RequestDeleteAsync();
                MessageBox.Show("La tuile secondaire a été supprimée.");
            }
            else
            {
                MessageBox.Show("Aucune tuile secondaire existe.");
            }
        }

        private void OnAfficheToastClicked(object sender, RoutedEventArgs e)
        {
            var toast = ToastContentFactory.CreateToastText02();
            toast.TextHeading.Text = "MonAppli";
            toast.TextBodyWrap.Text = "Une mise à jour est disponible !";
            toast.Launch = "/MiseAJourApplication.xaml?version=2.2.3.1";

            ToastNotification toastNotification = new ToastNotification(toast.GetXml());
            ToastNotificationManager.CreateToastNotifier().Show(toastNotification);
        }

        private void OnAfficheToastFuturClicked(object sender, RoutedEventArgs e)
        {
            var toast = ToastContentFactory.CreateToastText02();
            toast.TextHeading.Text = "MonAppli";
            toast.TextBodyWrap.Text = "Une mise à jour est disponible !";
            toast.Launch = "/MiseAJourApplication.xaml?version=2.2.3.1";

            ScheduledToastNotification scheduledToast = new ScheduledToastNotification(toast.GetXml(), DateTime.Now.AddMinutes(2));
            scheduledToast.Id = "miseajour";
            ToastNotificationManager.CreateToastNotifier().AddToSchedule(scheduledToast);
        }

        private void OnAfficheToastMultipleClicked(object sender, RoutedEventArgs e)
        {
            var toastG1T1 = ToastContentFactory.CreateToastText02();
            toastG1T1.TextHeading.Text = "MonAppli";
            toastG1T1.TextBodyWrap.Text = "Une mise à jour est disponible !";
            toastG1T1.Launch = "/MiseAJourApplication.xaml";
            ToastNotification toastNotificationtoastG1T1 = new ToastNotification(toastG1T1.GetXml());
            toastNotificationtoastG1T1.Group = "1";
            toastNotificationtoastG1T1.Tag = "1";
            ToastNotificationManager.CreateToastNotifier().Show(toastNotificationtoastG1T1);
            var toastG2T1 = ToastContentFactory.CreateToastText02();
            toastG2T1.TextHeading.Text = "Bon plan";
            toastG2T1.TextBodyWrap.Text = "Les musées de Paris sont gratuits aujourd'hui";
            toastG2T1.Launch = "/BonPlan.xaml?id=17394";
            ToastNotification toastNotificationtoastG2T1 = new ToastNotification(toastG2T1.GetXml());
            toastNotificationtoastG2T1.Group = "bonplan";
            toastNotificationtoastG2T1.Tag = "1";
            ToastNotificationManager.CreateToastNotifier().Show(toastNotificationtoastG2T1);
            var toastG2T2 = ToastContentFactory.CreateToastText02();
            toastG2T2.TextHeading.Text = "Bon plan";
            toastG2T2.TextBodyWrap.Text = "Dégustation des produits du terroir Place de l'Hôtel de Ville";
        }

        private void OnMajToastClicked(object sender, RoutedEventArgs e)
        {
            var toastG2T1 = ToastContentFactory.CreateToastText02();
            toastG2T1.TextHeading.Text = "Bon plan";
            toastG2T1.TextBodyWrap.Text = "Les musées de Paris sont gratuits aujourd'hui et demain";
            toastG2T1.Launch = "/BonPlan.xaml?id=17394";
            ToastNotification toastNotificationtoastG2T1 = new
            ToastNotification(toastG2T1.GetXml());
            toastNotificationtoastG2T1.Group = "bonplan";
            toastNotificationtoastG2T1.Tag = "1";
            ToastNotificationManager.CreateToastNotifier().
            Show(toastNotificationtoastG2T1);
        }
    }
}