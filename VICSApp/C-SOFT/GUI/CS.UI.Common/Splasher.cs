using System;
using System.Windows;
using CS.Common.Std.Extensions;

namespace CS.UI.Common
{
    /// <summary>
    /// Helper to show or close given splash window
    /// </summary>
    public static class Splasher
    {
        /// <summary>
        /// 
        /// </summary>
        private static Window mSplash;

        /// <summary>
        /// Get or set the splash screen window
        /// </summary>
        public static Window Splash
        {
            get => mSplash;
            set => mSplash = value;
        }

        /// <summary>
        /// Show splash screen
        /// </summary>
        public static void ShowSplash()
        {
            mSplash?.Show();
        }
        /// <summary>
        /// Close splash screen
        /// </summary>
        public static void CloseSplash()
        {
            if (mSplash == null)
                return;

            mSplash.Close();
            mSplash = null;
        }
    }
}
