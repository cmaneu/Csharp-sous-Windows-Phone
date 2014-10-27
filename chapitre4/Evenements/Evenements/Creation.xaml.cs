using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Evenements
{
    public partial class Creation : PhoneApplicationPage
    {
        public Creation()
        {
            InitializeComponent();
        }

        public event EventHandler CommandeValidee;

        protected virtual void OnCommandeValidee()
        {
            EventHandler handler = CommandeValidee;
            if (handler != null) handler(this, EventArgs.Empty);
        }
    }
}