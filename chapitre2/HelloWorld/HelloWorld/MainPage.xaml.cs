using System.Windows;
using Microsoft.Phone.Controls;

namespace HelloWorld
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Bonjour " + tb_saisie.Text);
        }
    }
}