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
        /// Remeber to read readme.md before you start the program!
        /// </summary>
        [STAThread]
        static void Main()
        {
            // First start up the LoginForm so the user can login
            Application.Run(new LogInForm());
            // Then after the user have loged in it opens up the UserInterface
            Application.Run(new UserInterface());
        }
    }
}
