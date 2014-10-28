using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Navigation;
using Microsoft.Devices.Sensors;
using Microsoft.Phone.Controls;
using Microsoft.Xna.Framework;

namespace MotionApi
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (!Motion.IsSupported)
            {
                MessageBox.Show("L'API Motion n'est pas supportée sur ce téléphone.");
                return;
            }
            var motion = new Motion();
            motion.TimeBetweenUpdates = TimeSpan.FromMilliseconds(20);
            motion.CurrentValueChanged += OnMotionCurrentValueChanged;
            try
            {
                motion.Start();
            }
            catch (Exception)
            {
                MessageBox.Show("Impossible de démarrer la capture du mouvement.");
            }
        }

        private void OnMotionCurrentValueChanged(object sender, SensorReadingEventArgs<MotionReading> e)
        {
            Dispatcher.BeginInvoke(() =>
            {
                ((RotateTransform)yawtriangle.RenderTransform).Angle = MathHelper.ToDegrees(e.SensorReading.Attitude.Yaw);
                ((RotateTransform)pitchtriangle.RenderTransform).Angle = MathHelper.ToDegrees(e.SensorReading.Attitude.Pitch);
                ((RotateTransform)rolltriangle.RenderTransform).Angle = MathHelper.ToDegrees(e.SensorReading.Attitude.Roll);
                ((PlaneProjection)Rectangle.Projection).RotationX = MathHelper.ToDegrees(e.SensorReading.Attitude.Pitch);
                ((PlaneProjection)Rectangle.Projection).RotationY = MathHelper.ToDegrees(-e.SensorReading.Attitude.Roll);
                ((PlaneProjection)Rectangle.Projection).RotationZ = MathHelper.ToDegrees(-e.SensorReading.Attitude.Yaw);
            });
        }
    }
}