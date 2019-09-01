using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace PasswordGenerator
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ClassLibraryDetails classLibrary = new ClassLibraryDetails();
            //Console.WriteLine(Environment.NewLine + classLibrary.CLVersion());

            Assembly assembly = Assembly.GetExecutingAssembly();
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(assembly.Location);
            Console.WriteLine(versionInfo.ProductName + " v" + versionInfo.FileVersion); 

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FrmMain());            
        }
    }
}
