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
    public partial class LogInForm : Form
    {
        public LogInForm()
        {
            InitializeComponent();
            // Everytime a key is pressed it checks what key it was, if it was 13(Enter) it goes on with the login
            this.TxtPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(CheckKeys);
        }

        private void Butexe_Click(object sender, EventArgs e)
        {
            UserCheck();
        }

        public static string LoggedUserName;

        void UserCheck()
        {
            int RowCount = 0;
            
            // This is the info of the database that we are gonna login to
            string databasePatch = "Server=Localhost;Database=filedatabase;UID=root; Pwd=;";
            // Makes the connection to the database
            MySqlConnection database = new MySqlConnection(databasePatch);
            // Opens the connection
            database.Open();

            // Find the row in the database where username and password = to what the user's input is, in order to check if there is such a user
            string sql = "SELECT UserName,Password FROM users WHERE UserName = '" + this.TxtUserName.Text + "' AND Password = '" + this.TxtPassword.Text + "'";
            // Connects the sql qurry and the data so it's ready to send
            MySqlCommand UserCheck = new MySqlCommand(sql, database);
            // Sends to the database and are rdy to receive a input from the data base
            MySqlDataReader reader = UserCheck.ExecuteReader();

            // While is reads all the outputs the rowcount goes up, to count how many rows there is
            while (reader.Read())
            {
                RowCount++;
            }

            // If it only finds one row, there is no problem the user exist and is the only one, therefor he/she can log on
            if (RowCount == 1)
            {
                LoggedUserName = TxtUserName.Text;
                // Closes this form and goes back to main
                this.Close();
            }

            // If the rowcount is bigger then 1 it means there is 2 or more users with the same username and password, and there may not log in before this is solved
            else if (RowCount > 1)
            {
                MessageBox.Show("Error code: x2");
            }

            // If the rowcount is 0 it means the user's username or password is wrong
            else
            {
                MessageBox.Show("Wrong username or password");
                TxtPassword.Text = "";
            }
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                e.Handled = true;
                UserCheck();
            }
        }

        private void CheckKeys(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            // Ketchar(13) = Enter key
            if (e.KeyChar == (char)13)
            {
                // Then Enter key was pressed, and therefor go on with the usercheck
                UserCheck();
            }
        }
    }
}
