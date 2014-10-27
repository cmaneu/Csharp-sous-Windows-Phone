using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Conversions
{
    public partial class ConversionStringPage : PhoneApplicationPage
    {
        public ConversionStringPage()
        {
            InitializeComponent();
            this.Loaded += ConversionStringPage_Loaded;
        }

        void ConversionStringPage_Loaded(object sender, RoutedEventArgs e)
        {
            // Conversion monétaire
            float montantCommand = 183.232f;
            tb_monetaire_depart.Text += montantCommand;
            tb_monetaire_resultat.Text += montantCommand.ToString("c");

            // N° de téléphone
            // Le n° est stocké sous forme de int, mais on perd le 0 initial
            int numTel = 140302010;
            tb_tel_depart.Text += numTel;
            tb_tel_resultat.Text += numTel.ToString("0# ## ## ## ##");

            DateTime date = new DateTime(2013, 06, 01);
            tb_date_depart.Text += date.ToString();
            tb_date_resultat.Text += date.ToString("dddd dd MMMM yyyy");

        }
    }
}