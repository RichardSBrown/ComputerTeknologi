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
using System.Net;

namespace UpOrDownFiles
{
    public partial class UserInterface : Form
    {
        public string Filename;
        // This is where files you upload end up aka. The fileserver
        public string RootFolder = @"C:\Users\Richard Brown Thomse\Documents\ComputerTeknologi\Filer\";
        // This is the place where the files you downloaded end up
        public string DonwloadFolder = @"C:\Users\Richard Brown Thomse\Documents\ComputerTeknologi\Downloadede filer\";
        // Status to declare if it a down or upload. FALSE is upload and TRUE is download
        public bool status;

        public UserInterface()
        {
            InitializeComponent();
            FillTheData();
            
        }

        private void butUpload_Click(object sender, EventArgs e)
        {
            // Status = false witch means we are uploading something
            status = false;
            // Added this Upload to the log table in the database
            AddToLog();
            // Makes a new FileDialog so the user can choose the file they want to upload
            OpenFileDialog UserFile = new OpenFileDialog();
            // Multiselect declare if you can choose more then one thing a time, we have it false here witch means you can't
            UserFile.Multiselect = false;
            // The Interface for the file chooser
            UserFile.ShowDialog();
            // ???
            UserFile.Filter = "*.jpg|*.docx";

            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();
            // The place where all the files go, normaly you would have a server for it

            string sql = "";

            string FileType = Path.GetExtension(UserFile.FileName);

            string dest = "";

            bool ReadyToSend = false;
            
            if (FileType == ".JPG")
            {
                // Combine the path i want and the path the file are in
                dest = Path.Combine(RootFolder + "Billeder", Path.GetFileName(UserFile.FileName));
                // Inserts the Url and other things into the database
                sql = "INSERT INTO `files`( `Uploader`, `FileName` ,`Url`) VALUES ('" + LogInForm.LoggedUserName + "' , '" + Path.GetFileName(UserFile.FileName) + "' , 'Billeder')";
                ReadyToSend = true;
            }
            else if (FileType == ".txt" || FileType == ".docx")
            {
                // Combine the path i want and the path the file are in
                dest = Path.Combine(RootFolder + "Dokumenter", Path.GetFileName(UserFile.FileName));
                // Inserts the Url and other things into the database
                sql = "INSERT INTO `files`( `Uploader`, `FileName` ,`Url`) VALUES ('" + LogInForm.LoggedUserName + "' , '" + Path.GetFileName(UserFile.FileName) + "' , 'Dokumenter')";
                ReadyToSend = true;
            }
            
            if (ReadyToSend == true)
            {
                // Connects the sql qurry and the data so it's ready to send
                MySqlCommand AddToDataBase = new MySqlCommand(sql, database);
                // Sends to the database and are rdy to receive a input from the data base
                MySqlDataReader reader = AddToDataBase.ExecuteReader();
                try
                {
                    // Copys the file from where it is right now til where you want to be
                    File.Copy(UserFile.FileName, dest);
                    // Make sure the data grid reloads so you can see the file you just downloaded or uploaded
                    FillTheData();
                }
                catch
                {
                    MessageBox.Show("File already exists, please change the name of the file and try again");
                }
            }
        }

        private void butDownload_Click(object sender, EventArgs e)
        {

            // Gets the value of cells[1] from the row the user selected
            Filename = dataGridView1.CurrentRow.Cells[1].Value.ToString();


            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();

            string URLFolder = "";
            int Downloads = 0;

            // Prepade the SQL qurry so we can get the URL from the file the user wantes
            string sql = "SELECT `Url` , `Downloads` FROM `files` WHERE FileName = '" + Filename + "'";
            // Connects the sql qurry and the data so it's ready to send
            MySqlCommand findTheURL = new MySqlCommand(sql, database);
            // Sends to the database and are rdy to receive a input from the data base
            MySqlDataReader reader = findTheURL.ExecuteReader();
            
            // It reades the input from the database
            if (reader.Read())
            {
                // The input from the database get put in to URLFile, so we can use it later
                URLFolder = reader.GetString("Url");
                Downloads = reader.GetInt32("Downloads");
            }
            else
            {
                // If we get down here, the user had selected a file that does not exist
                MessageBox.Show("Something went wrong plz try again");
            }
            // Combines the rootfolder, urlfolder and filename, you get the full Url so the program knows where the file is and where it is
            string FullURL = Path.Combine(RootFolder, URLFolder, Filename);
            // Add one to downloads, so you can see how many downloads the file have
            Downloads++;

            // Close the reader so we can make a new up to update the downloader
            reader.Close();

            // Added this download to the database
            AddToLog();
            WebClient webClient = new WebClient();
            // Download a file first Where does it get it from, then where does it put it.
            webClient.DownloadFile(FullURL, DonwloadFolder + Filename);

            // Now that we got the file down on the PC we need to make sure we send back that we downloaded the file
            sql = "UPDATE `files` SET `Downloads`= '" + Downloads + "' WHERE FileName = '" + Filename + "'";
            // Connects the sql qurry and the data so it's ready to send
            MySqlCommand UpdateaDownloads = new MySqlCommand(sql, database);
            // Sends to the database and are rdy to receive a input from the data base
            MySqlDataReader Updatereader = UpdateaDownloads.ExecuteReader();


            // Make sure the data grid reloads so you can see the file you just downloaded or uploaded
            FillTheData();
        }

        void AddToLog()
        {
            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();

            string sql = "";

            // If the status is false it means the user uploaded something
            if (status == false)
            {
                sql = "INSERT INTO `log`( `UserName`, `Status`) VALUES ('" + LogInForm.LoggedUserName + "', 'Upload')";
            }

            // If the status is true it means the user downloaded something
            else if (status == true)
            {
                sql = "INSERT INTO `log`( `UserName`, `Status`) VALUES ('" + LogInForm.LoggedUserName + "', 'Download'";
            }
            
            // If we get into this else stament we are fucked, it means the status did not get a value but somehow ended up here
            else
            {
                MessageBox.Show("Something went super wrong, please try again");
            }

            // Connects the sql qurry and the data so it's ready to send
            MySqlCommand AddToLog = new MySqlCommand(sql, database);
            // Sends to the database and are rdy to receive a input from the data base
            MySqlDataReader reader = AddToLog.ExecuteReader();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void FillTheData()
        {
            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();

            // A Sql qurry that get the Uploader, Url And how many downloads the file had
            string sql = "SELECT Uploader , FileName , Downloads FROM files WHERE 1";

            // mySqlDataAdapter is the interface between the Data set and the database itself (Link: https://dev.mysql.com/doc/connector-net/en/connector-net-tutorials-data-adapter.html)
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, database);
            // New Dataset, we'll  use it later for the gridview
            DataSet DS = new DataSet();
            // Comepines the adapter and dataset, and fills the adapter with data from the dataset
            mySqlDataAdapter.Fill(DS);
            // DataSource tell the dataGridView where it gets the data from
            dataGridView1.DataSource = DS.Tables[0];
        }

        private void butShowLog_Click(object sender, EventArgs e)
        {
            // Makes a now log form
            LogForm TheLog = new LogForm();
            // Makes this form invisible
            this.Visible = false;
            // Shows the new form
            TheLog.ShowDialog();
            // Shuts down the form we have open atm (UserInterface.cs) 
            this.Close();
        }
    }
}
