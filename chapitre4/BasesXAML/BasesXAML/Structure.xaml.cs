﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace BasesXAML
{
    public partial class Structure : PhoneApplicationPage
    {
        public Structure()
        {
            InitializeComponent();
            saisie_prenom.Text = "Aurore";
        }
    }
}