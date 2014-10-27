using System.Windows.Input;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Animations
{
    public partial class StoryboardXaml : PhoneApplicationPage
    {
        public StoryboardXaml()
        {
            InitializeComponent();
        }

        private void OnDemarrerBoutonTap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            PenduleStoryboard.Begin();
        }

        private void OnArreterBoutonTap(object sender, GestureEventArgs e)
        {
            PenduleStoryboard.Stop();
        }
    }
}