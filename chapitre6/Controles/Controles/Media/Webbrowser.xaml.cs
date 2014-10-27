using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Controles.Media
{
    public partial class Webbrowser : PhoneApplicationPage
    {
        public Webbrowser()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            SimpleWebBrowser.IsScriptEnabled = true;
            SimpleWebBrowser.Navigate(new Uri("http://github.com/cmaneu"));

            StringWebBrowser.NavigateToString("<html><h1>Bienvenue</h1><p>Ceci est un contrôle HTML</p></html>");

            ScriptWebBrowser.IsScriptEnabled = true;
            ScriptWebBrowser.NavigateToString("<html><h1>HTML + Windows Phone</h1><input type='button' value='Retour' onclick='window.external.notify(\"back\");' /></html>");
            ScriptWebBrowser.ScriptNotify += OnScritpWebbrowserScriptNotify;

        }

        private void OnScritpWebbrowserScriptNotify(object sender, NotifyEventArgs e)
        {
            if (e.Value == "back")
            {
                NavigationService.GoBack();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ScriptWebBrowser.InvokeScript("alert", "Coucou depuis Windows Phone");
        }

    }
}