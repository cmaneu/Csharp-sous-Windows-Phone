using System.Windows.Controls;
using Microsoft.Phone.Controls;

namespace Animations
{
    public partial class TiltEffect : PhoneApplicationPage
    {
        public TiltEffect()
        {
            InitializeComponent();

            if (!Microsoft.Phone.Controls.TiltEffect.TiltableItems.Contains(typeof(Grid)))
            {
                Microsoft.Phone.Controls.TiltEffect.TiltableItems.Add(typeof(Grid));
            }
        }
    }
}