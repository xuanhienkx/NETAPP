using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HOGW_PT_Dealer
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new frmMainPT());
            //Application.Run(new PTLiveBoard());
        }
        //declare and initialize the public static clsSettings object
        public static clsSettings sets = new clsSettings();

        /// <summary>
        /// Returns the settings file path
        /// </summary>
        /// <returns></returns>
        public static string GetSettingPath()
        {
            //Loai bo .EXE sau excutable path va them vao settings.xml
            return Application.ExecutablePath.Remove(Application.ExecutablePath.Length-4) + "_Settings.xml";
            //return Application.ExecutablePath + ".config";
        }

    }
}
