using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.IO;

namespace UpOrDownFiles
{
    public partial class UserInterface : Form
    {
        public UserInterface()
        {
            InitializeComponent();
        }

        private void butChoose_Click(object sender, EventArgs e)
        {
            // Makes a new FileDialog so the user can choose the file they want to upload
            OpenFileDialog UserFile = new OpenFileDialog();
            // Multiselect declare if you can choose more then one thing a time, we have it false here witch means you can't
            UserFile.Multiselect = false;
            // The Interface for the file chooser
            UserFile.ShowDialog();
            // ???
            UserFile.Filter = "*.jpg|*.docx";
            // In the textbox you can see the patch to the file
            textBox1.Text = UserFile.FileName;

            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();
            // The place where all the files go, normaly you would have a server for it
            string FileFolder = @"C:\Users\Richard Brown Thomse\Documents\ComputerTeknologi\Filer";











            // Combine the path i want and the path the file are in
            string dest = Path.Combine(FileFolder, Path.GetFileName(UserFile.FileName));
            // Copys the file from where it is right now till where you want to be
            File.Copy(UserFile.FileName, dest);
        }


    }
}
