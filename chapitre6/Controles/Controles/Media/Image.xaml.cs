using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Windows.Storage;
using Windows.Storage.Streams;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Controles.Mutimedia
{
    public partial class Image : PhoneApplicationPage
    {
        public Image()
        {
            InitializeComponent();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            HttpClient client = new HttpClient();
            StorageFile file = await Windows.Storage.ApplicationData.Current.LocalFolder.CreateFileAsync("monimage.jpg", CreationCollisionOption.ReplaceExisting);
            using (Stream writeStream = await file.OpenStreamForWriteAsync())
            {
                Stream stream = await client.GetStreamAsync("http://maneu.net/img/background.jpg");
                await stream.CopyToAsync(writeStream);
            }

            StorageImage.Source = new BitmapImage(new Uri(file.Path));
            // ms-appdata://
        }
    }
}