using System;
using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Conversions
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructeur
        public MainPage()
        {
            InitializeComponent();
        }

        // Conversion explicite
        private void ShortVersIntTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();

            short s = 42;
            int i = s;
            Console.WriteLine("Valeur de s: " + s); // Affiche 42
            Console.WriteLine("Valeur de i: " + i); // Affiche 42
        }

        // Conversion implicite avec un cast
        private void IntVersShortTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            // Les lignes suivantes commentées provoquent une exception
            //int i = 1337;
            //short s = i;

            int i = 1337;
            short s = (short)i;
            Console.WriteLine("Valeur de i: " + i); // Affiche 1337
            Console.WriteLine("Valeur de s: " + s); // Affiche 1337
        }

        // Conversion implicite avec un cast - l'entier est trop grand pour le short
        private void GrosIntVersShortTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();

            // La valeur maximale d'un short est 32 767
            int i = 33000;
            short s = (short)i;
            Console.WriteLine("Valeur de i: " + i); // Affiche 33000
            Console.WriteLine("Valeur de s: " + s); // Affiche -32536
        }

        private void StringToIntTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            string chaine = "75100";
            int i = Convert.ToInt32(chaine);
            Console.WriteLine("Valeur de chaine: " + chaine);
            Console.WriteLine("Valeur de i: " + i);
        }


        private void StringErrorToIntTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            string chaine = "deux mille";
            int i = Convert.ToInt32(chaine);
            Console.WriteLine("Valeur de chaine: " + chaine);
            Console.WriteLine("Valeur de i: " + i);
        }

        private void StringTryParseToIntTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            string chaine = "deux mille";
            Console.WriteLine("Valeur de chaine: " + chaine);
            int i;
            if (int.TryParse(chaine, out i))
            {
                Console.WriteLine("Valeur de i: " + i);
            }
            else
            {
                Console.WriteLine("Impossible de convertir la chaîne");
            }
            
            
        }

        private void ObjectToIntTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            object o1 = "Bonjour à tous";
            string s1 = o1 as string;
            if (s1 != null)
            {
                Console.WriteLine("o1 converti en string: " + s1);
            }
            else
            {
                Console.WriteLine("o1 n'est pas une string");
            }

            object o2 = 12730;
            string s2 = o2 as string;
            if (s2 != null)
            {
                Console.WriteLine("o2 converti en string: " + s2);
            }
            else
            {
                Console.WriteLine("o2 n'est pas une string");
            }
                
        }

        private void ConversionsStringTapped(object sender, System.Windows.Input.GestureEventArgs e)
        {
            Console.Clear();
            NavigationService.Navigate(new Uri("/ConversionStringPage.xaml",UriKind.RelativeOrAbsolute));
        }
    }

    public static class TextBlockConsoleExtensions
    {
        public static void WriteLine(this TextBlock textblock, string text)
        {
            textblock.Text += text + Environment.NewLine;
        }

        public static void Clear(this TextBlock textblock)
        {
            textblock.Text = string.Empty;
        }
    }
}