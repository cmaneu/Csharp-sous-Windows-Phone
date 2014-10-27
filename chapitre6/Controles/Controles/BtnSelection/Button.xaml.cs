using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Controles.BtnSelection
{
    public partial class Button : PhoneApplicationPage
    {
        public Button()
        {
            InitializeComponent();
        }

        private void OnBtnDoubleTap(object sender, GestureEventArgs e)
        {
            LayoutRoot.Background = new SolidColorBrush(Colors.Blue);
        }
    }
}