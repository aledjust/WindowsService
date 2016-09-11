using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace GUIService
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
            //Application.Run(new Form1());

            // Show the system tray icon.					
            using (ProcessIcon pi = new ProcessIcon())
            {
                pi.Display();

                // Make sure the application runs with SingleApplication!
                if (SingleApplication.Run() == false)
                {
                    return;
                } 
               Application.Run();
                //Application.Run(new Dashboard());
            }
        }
    }
}
