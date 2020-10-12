using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityAccessQuery
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
            Application.Run(new MainForm());
        }

        // Gets the folder where the binary is executed in
        public static string GetStartupPath()
        {
            return Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + Path.DirectorySeparatorChar;
        }
        public static string GetLibraryPath() 
        {
            return $"{Program.GetStartupPath()}Library{Path.DirectorySeparatorChar}";
        }
        public static string[] GetLibraryFiles() 
        {
            return Directory.GetFiles(GetLibraryPath());
        }
    }
}
