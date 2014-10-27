using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;
using Microsoft.Phone.Controls;
using GestureEventArgs = System.Windows.Input.GestureEventArgs;

namespace Animations
{
    public partial class StoryboardCode : PhoneApplicationPage
    {
        Storyboard PenduleStoryboard
        {
            get; set;
            
        }
        public StoryboardCode()
        {
            InitializeComponent();


            PenduleStoryboard = new Storyboard();

            DoubleAnimationUsingKeyFrames penduleCompositeRotationAnimation = new DoubleAnimationUsingKeyFrames();
            penduleCompositeRotationAnimation.KeyFrames.Add(new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(0)), 
                Value = 20
            });
            penduleCompositeRotationAnimation.KeyFrames.Add(new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(800)),
                Value = -20
            });
            penduleCompositeRotationAnimation.KeyFrames.Add(new EasingDoubleKeyFrame()
            {
                KeyTime = KeyTime.FromTimeSpan(TimeSpan.FromMilliseconds(1600)), 
                Value = 20
            });

            Storyboard.SetTarget(penduleCompositeRotationAnimation, canvas);
            Storyboard.SetTargetProperty(penduleCompositeRotationAnimation, new PropertyPath("(UIElement.RenderTransform).(CompositeTransform.Rotation)"));

            PenduleStoryboard.Children.Add(penduleCompositeRotationAnimation);
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