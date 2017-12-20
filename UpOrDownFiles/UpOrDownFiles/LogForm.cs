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

namespace UpOrDownFiles
{
    public partial class LogForm : Form
    {
        public LogForm()
        {
            InitializeComponent();
            FillTheData();
        }

        private void butBack_Click(object sender, EventArgs e)
        {
            // Makes a now log form
            UserInterface userInterface = new UserInterface();
            // Makes this form invisible
            this.Visible = false;
            // Shows the new form
            userInterface.ShowDialog();
            // Shuts down the form we have open atm (UserInterface.cs) 
            this.Close();
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
            string sql = "SELECT UserName , Status , Created FROM log ORDER BY `log`.`Created` DESC";

            // Dunno ???
            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter(sql, database);
            // Dunno ???
            DataSet DS = new DataSet();
            // Dunno ???
            mySqlDataAdapter.Fill(DS);
            // Dunno ???
            dataGridView1.DataSource = DS.Tables[0];
        }
    }
}
