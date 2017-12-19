using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UpOrDownFiles
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new LogInForm());
            Application.Run(new UserInterface());
         //   Application.EnableVisualStyles();
         //   Application.SetCompatibleTextRenderingDefault(false);
         //   Application.Run(new Form1());
        }
    }
}
