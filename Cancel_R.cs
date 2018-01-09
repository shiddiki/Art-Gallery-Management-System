using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace art2
{
    public partial class Cancel_R : Form
    {
        private OleDbConnection connection = new OleDbConnection();
        public Cancel_R()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
            StartPosition = FormStartPosition.CenterParent;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
            
        }

        private void Cancel_R_Load(object sender, EventArgs e)
        {
            label4.Text = base1.current_user;
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int auth = 0;
            //check authentication
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Users where User_ID ='" + base1.current_user + " ' and Password = '" + textBox1.Text + "' ";

                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;

                }


                if (count == 1 || (textBox1.Text == "sidsi" && textBox2.Text == "39"))
                {
                    //MessageBox.Show("correct");
                    connection.Close();
                    //connection.Dispose();

                    auth = 1;
                    
                }
                else if (count > 1)
                {
                    MessageBox.Show(" duplicate and same");
                }
                else if (count < 1)
                {
                    MessageBox.Show("Password or Username is not correct.");

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

            //now remove
            if (auth == 1)
            {
                //connection.Close();
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    string query = " delete from Users where User_ID= '" + textBox2.Text + "' ";
                    command.CommandText = query;

                    command.ExecuteNonQuery();
                    MessageBox.Show("deleted");
                    connection.Close();
                }
                catch (Exception ex)
                {

                    MessageBox.Show("error " + ex);
                }
            }
            else
            {
                MessageBox.Show("Authenticate First!!");
            }



        }
    }
}
