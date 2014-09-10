using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace TeraLauncher
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        public static Main Form;
        public static FormThread msg;

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form = new Main();
            msg = new FormThread();
            Application.Run(Form);
        }
    }
}
