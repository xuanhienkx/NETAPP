﻿using System;
using System.Windows;
using System.Windows.Media.Animation;
using MahApps.Metro.Controls;

namespace CS.UI.Controls
{
    public class RevealPanel : System.Windows.Controls.Decorator
    {
        #region Constructors

        static RevealPanel()
        {
            ClipToBoundsProperty.OverrideMetadata(typeof(RevealPanel), new FrameworkPropertyMetadata(true));
        }

        #endregion

        #region Public Properties

        /// <summary>
        ///     Whether the child is expanded or not.
        ///     Note that an animation may be in progress when the value changes.
        ///     This is not meant to be used with AnimationProgress and can overwrite any 
        ///     animation or values in that property.
        /// </summary>
        public bool IsExpanded
        {
            get => (bool)GetValue(IsExpandedProperty);
            set => SetValue(IsExpandedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsExpanded.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsExpandedProperty =
            DependencyProperty.Register("IsExpanded", typeof(bool), typeof(RevealPanel), new UIPropertyMetadata(false, OnIsExpandedChanged));

        private static void OnIsExpandedChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            ((RevealPanel)sender).SetupAnimation((bool)e.NewValue);
        }

        /// <summary>
        ///     The duration in milliseconds of the reveal animation.
        ///     Will apply to the next animation that occurs (not to currently running animations).
        /// </summary>
        public double Duration
        {
            get => (double)GetValue(DurationProperty);
            set => SetValue(DurationProperty, value);
        }

        // Using a DependencyProperty as the backing store for Duration.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(double), typeof(RevealPanel), new UIPropertyMetadata(250.0));

        public HorizontalRevealMode HorizontalReveal
        {
            get => (HorizontalRevealMode)GetValue(HorizontalRevealProperty);
            set => SetValue(HorizontalRevealProperty, value);
        }

        // Using a DependencyProperty as the backing store for HorizontalReveal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HorizontalRevealProperty =
            DependencyProperty.Register("HorizontalReveal", typeof(HorizontalRevealMode), typeof(RevealPanel), new UIPropertyMetadata(HorizontalRevealMode.None));

        public VerticalRevealMode VerticalReveal
        {
            get => (VerticalRevealMode)GetValue(VerticalRevealProperty);
            set => SetValue(VerticalRevealProperty, value);
        }

        // Using a DependencyProperty as the backing store for VerticalReveal.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty VerticalRevealProperty =
            DependencyProperty.Register("VerticalReveal", typeof(VerticalRevealMode), typeof(RevealPanel), new UIPropertyMetadata(VerticalRevealMode.FromTopToBottom));

        /// <summary>
        ///     Value between 0 and 1 (inclusive) to move the reveal along.
        ///     This is not meant to be used with IsExpanded.
        /// </summary>
        public double AnimationProgress
        {
            get => (double)GetValue(AnimationProgressProperty);
            set => SetValue(AnimationProgressProperty, value);
        }

        // Using a DependencyProperty as the backing store for AnimationProgress.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AnimationProgressProperty =
            DependencyProperty.Register("AnimationProgress", typeof(double), typeof(RevealPanel), new FrameworkPropertyMetadata(0.0, FrameworkPropertyMetadataOptions.AffectsMeasure, null, OnCoerceAnimationProgress));

        private static object OnCoerceAnimationProgress(DependencyObject d, object baseValue)
        {
            var num = (double)baseValue;
            if (num < 0.0)
            {
                return 0.0;
            }
            else if (num > 1.0)
            {
                return 1.0;
            }

            return baseValue;
        }

        #endregion

        #region Implementation

        protected override Size MeasureOverride(Size constraint)
        {
            var child = Child;
            if (child != null)
            {
                var parent = child.GetParentObject().GetParentObject() as UIElement;
                child.Measure(constraint);

                var percent = AnimationProgress;
                var width = CalculateWidth(child.DesiredSize.Width, percent, HorizontalReveal);
                var height = CalculateHeight(child.DesiredSize.Height, percent, VerticalReveal);
                return new Size(width, height);
            }

            return new Size();
        }

        protected override Size ArrangeOverride(Size arrangeSize)
        {
            var child = Child;
            if (child != null)
            {
                var percent = AnimationProgress;
                var horizontalReveal = HorizontalReveal;
                var verticalReveal = VerticalReveal;

                var parent = child.GetParentObject().GetParentObject() as UIElement;

                var childWidth = parent.DesiredSize.Width; //child.DesiredSize.Width;
                var childHeight = child.DesiredSize.Height;
                var x = CalculateLeft(childWidth, percent, horizontalReveal);
                var y = CalculateTop(childHeight, percent, verticalReveal);

                child.Arrange(new Rect(x, y, childWidth, childHeight));

                childWidth = child.RenderSize.Width;
                childHeight = child.RenderSize.Height;
                var width = CalculateWidth(childWidth, percent, horizontalReveal);
                var height = CalculateHeight(childHeight, percent, verticalReveal);
                return new Size(width, height);
            }

            return new Size();
        }

        private static double CalculateLeft(double width, double percent, HorizontalRevealMode reveal)
        {
            if (reveal == HorizontalRevealMode.FromRightToLeft)
            {
                return (percent - 1.0) * width;
            }
            else if (reveal == HorizontalRevealMode.FromCenterToEdge)
            {
                return (percent - 1.0) * width * 0.5;
            }
            else
            {
                return 0.0;
            }
        }

        private static double CalculateTop(double height, double percent, VerticalRevealMode reveal)
        {
            if (reveal == VerticalRevealMode.FromBottomToTop)
            {
                return (percent - 1.0) * height;
            }
            else if (reveal == VerticalRevealMode.FromCenterToEdge)
            {
                return (percent - 1.0) * height * 0.5;
            }
            else
            {
                return 0.0;
            }
        }

        private static double CalculateWidth(double originalWidth, double percent, HorizontalRevealMode reveal)
        {
            return originalWidth;
            //if (reveal == HorizontalRevealMode.None)
            //{
            //    return originalWidth;
            //}
            //else
            //{
            //    return originalWidth * percent;
            //}
        }

        private static double CalculateHeight(double originalHeight, double percent, VerticalRevealMode reveal)
        {
            if (reveal == VerticalRevealMode.None)
            {
                return originalHeight;
            }
            else
            {
                return originalHeight * percent;
            }
        }

        private void SetupAnimation(bool isExpanded)
        {
            // Adjust the time if the animation is already in progress
            var currentProgress = AnimationProgress;
            if (isExpanded)
            {
                currentProgress = 1.0 - currentProgress;
            }

            var animation = new DoubleAnimation
            {
                To = isExpanded ? 1.0 : 0.0,
                Duration = TimeSpan.FromMilliseconds(Duration * currentProgress),
                FillBehavior = FillBehavior.HoldEnd
            };

            BeginAnimation(AnimationProgressProperty, animation);
        }

        #endregion
    }

    public enum HorizontalRevealMode
    {
        /// <summary>
        ///     No horizontal reveal animation.
        /// </summary>
        None,

        /// <summary>
        ///     Reveal from the left to the right.
        /// </summary>
        FromLeftToRight,

        /// <summary>
        ///     Reveal from the right to the left.
        /// </summary>
        FromRightToLeft,

        /// <summary>
        ///     Reveal from the center to the bounding edge.
        /// </summary>
        FromCenterToEdge,
    }

    public enum VerticalRevealMode
    {
        /// <summary>
        ///     No vertical reveal animation.
        /// </summary>
        None,

        /// <summary>
        ///     Reveal from top to bottom.
        /// </summary>
        FromTopToBottom,

        /// <summary>
        ///     Reveal from bottom to top.
        /// </summary>
        FromBottomToTop,

        /// <summary>
        ///     Reveal from the center to the bounding edge.
        /// </summary>
        FromCenterToEdge,
    }
}
