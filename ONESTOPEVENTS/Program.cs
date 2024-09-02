/*
George Coetzee  - 41885694
Ethan Wagner - 40903656
Konrad Theron - 43340067
Wiid de Wet - 43700292
Romarno Basson – 45401004
Kyle Engelbrecht – 45535728
Jandre Smit - 47065486
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ONESTOPEVENTS
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Homepage());
        }
    }
}
