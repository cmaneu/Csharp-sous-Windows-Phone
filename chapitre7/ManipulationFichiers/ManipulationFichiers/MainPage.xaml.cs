using System;
using System.IO;
using System.ServiceModel.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Windows.Storage;
using Windows.Storage.FileProperties;
using Microsoft.Phone.Controls;

namespace ManipulationFichiers
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEcrireFichierLocalTapped(object sender, GestureEventArgs e)
        {
            var localFolder = ApplicationData.Current.LocalFolder;
  
            StorageFile sampleFile = await localFolder.CreateFileAsync("dataFile.txt",CreationCollisionOption.OpenIfExists);
            await FileIO.AppendTextAsync(sampleFile, "Bonjour - " + DateTime.Now.ToShortTimeString());
            MessageBox.Show("Fichier créé avec succès");
        }

        private async void OnLireFichierLocalTapped(object sender, GestureEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            try
            {
                StorageFile sampleFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appdata:///local/dataFile.txt"));
                //StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
                string fileContents = await FileIO.ReadTextAsync(sampleFile);
                MessageBox.Show("Fichier lu avec succès." + Environment.NewLine + fileContents);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier n'existe pas");
            }
        }

        private async void OnSupprimerFichierLocalTapped(object sender, GestureEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            try
            {
                StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
                await sampleFile.DeleteAsync();
                MessageBox.Show("Fichier supprimé avec succès.");
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier n'existe pas");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.ToString());
                MessageBox.Show("Impossible de supprimer le fichier. Plus d'informations dans la console.");
            }
            
        }

        private void OnInfosFichierLocalTapped(object sender, GestureEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;
            FileInfo fileInfo = new FileInfo(Path.Combine(localFolder.Path, "dataFile.txt"));
            if (fileInfo.Exists)
            {
                MessageBox.Show(string.Format("Date de création: {0:G} \nDernier accès: {1:G}\nTaille: {2:N} Ko", fileInfo.CreationTime, fileInfo.LastAccessTime, fileInfo.Length / 1024));    
            }
            else
            {
                MessageBox.Show("Le fichier n'existe pas");
            }
        }

        private async void OnLireFichierPackageTapped(object sender, GestureEventArgs e)
        {
            try
            {
                StorageFile sampleFile = await StorageFile.GetFileFromApplicationUriAsync(new Uri("ms-appx:///MonFichier.txt"));
                string fileContents = await FileIO.ReadTextAsync(sampleFile);
                MessageBox.Show("Fichier lu avec succès." + Environment.NewLine + fileContents);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier n'existe pas");
            }
        }

        private async void OnCreerArborescenceTapped(object sender, GestureEventArgs e)
        {
            try
            {
                StorageFolder localFolder = ApplicationData.Current.LocalFolder;
                StorageFolder folder1 = await localFolder.CreateFolderAsync("Dossier 1");
                await folder1.CreateFileAsync("fichier 1.txt");
                await folder1.CreateFileAsync("fichier 2.txt");
                await folder1.CreateFileAsync("fichier 3.txt");
                StorageFolder folder2 = await localFolder.CreateFolderAsync("Dossier 2");
                await folder2.CreateFileAsync("image 1.jpg");
                await folder2.CreateFileAsync("image 2.jpg");
                await folder2.CreateFileAsync("image 3.jpg");
                await folder2.CreateFileAsync("image 4.jpg");
                await folder2.CreateFileAsync("image 5.jpg");
                await folder2.CreateFileAsync("image 6.jpg");
                MessageBox.Show("Arborescence créée avec succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur est survenue lors de la création de l'arborescence. " + ex.ToString());
            }
        }

        private async void OnLireArborescenceTapped(object sender, GestureEventArgs e)
        {
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            string fichiers = await GetArborescence(localFolder);
            MessageBox.Show(fichiers);
        }

        async Task<string> GetArborescence(StorageFolder folder)
        {
            StringBuilder sb = new StringBuilder();
            await GetArborescence(folder, sb, "");
            return sb.ToString();
        }

        async Task<StringBuilder> GetArborescence(StorageFolder folder, StringBuilder sb, string niveauArborescence)
        {

            sb.AppendLine(string.Concat(niveauArborescence,"[ ]", folder.Name));

            var dossiers = await folder.GetFoldersAsync();
            foreach (var storageFolder in dossiers)
            {
                StorageFolder dossier = storageFolder as StorageFolder;
                if(dossier == null)
                    continue;
                await GetArborescence(dossier, sb, niveauArborescence + "  ");
            }

            var fichiers = await folder.GetFilesAsync();
            foreach (var storageFile in fichiers)
            {
                StorageFile fichier = storageFile as StorageFile;
                if (fichier == null)
                    continue;

                sb.AppendLine(string.Concat(niveauArborescence, "- ", fichier.Name));    
            }

            return sb;
        }

        private async void OnCreerFichierTemporaireTapped(object sender, GestureEventArgs e)
        {
            var tempFolder = ApplicationData.Current.TemporaryFolder;

            StorageFile sampleFile = await tempFolder.CreateFileAsync("tempFile.txt", CreationCollisionOption.GenerateUniqueName);
            FileIO.AppendTextAsync(sampleFile, GetTempFileContents());
            MessageBox.Show("Fichier temporaire créé. " + sampleFile.Name);
        }

        private string GetTempFileContents()
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < 2048; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private async void OnTailleFichiersTemporairesTapped(object sender, GestureEventArgs e)
        {
            var tempFolder = ApplicationData.Current.TemporaryFolder;
            var taille = await GetDirectorySize(tempFolder);
            MessageBox.Show(string.Format("Taille des fichiers temporaires: {0} ko", taille));
        }

        async Task<ulong> GetDirectorySize(StorageFolder folder)
        {
            ulong taille = 0;
            var dossiers = await folder.GetFoldersAsync();
            foreach (var storageFolder in dossiers)
            {
                StorageFolder dossier = storageFolder as StorageFolder;
                if (dossier == null)
                    continue;
                taille += await GetDirectorySize(dossier);
            }

            var fichiers = await folder.GetFilesAsync();
            foreach (var storageFile in fichiers)
            {
                StorageFile fichier = storageFile as StorageFile;
                if (fichier == null)
                    continue;

                BasicProperties proprietes = await fichier.GetBasicPropertiesAsync();
                taille += proprietes.Size;
            }

            return taille;
        }

        private async void OnSupprimerTousTapped(object sender, GestureEventArgs e)
        {
            await DeleteFolderContentsAsync(ApplicationData.Current.TemporaryFolder, StorageDeleteOption.Default);
            await DeleteFolderContentsAsync(ApplicationData.Current.LocalFolder, StorageDeleteOption.Default);
            MessageBox.Show("Tous les fichiers ont été supprimés");
        }

        public static async Task DeleteFolderContentsAsync(StorageFolder folder, StorageDeleteOption option)
        {
            // Try to delete all files
            var files = await folder.GetFilesAsync();
            foreach (var file in files)
            {
                StorageFile f = file as StorageFile;
                if (f == null) 
                    continue;
                    
                await f.DeleteAsync(option);
            }

            // Iterate through all subfolders
            var subFolders = await folder.GetFoldersAsync();
            foreach (var subFolder in subFolders)
            {
                StorageFolder dossier = subFolder as StorageFolder;
                // Delete the contents
                await DeleteFolderContentsAsync(dossier, option);

                // Delete the subfolder
                await dossier.DeleteAsync(option);
            }
        }
    }
}