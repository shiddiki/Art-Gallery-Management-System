using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace art2
{
    public partial class registration : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public registration()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void usc4_Load(object sender, EventArgs e)
        {
            label10.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int suu = 0;
            if (textBox2.Text != textBox3.Text)
            {
                label10.Text = "Password mismatched!";
                textBox2.Text = textBox3.Text = "";
            }
            else
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Users ([User_ID],[Password],[First_Name],[Last_Name],[Email_Address],[Address],[Contact_Number]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + " ','" + textBox8.Text + " ') ";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Registration Successful!!");
                    suu = 1;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("error " + ex);
                }
            }
            if (suu == 1)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Employee ([First_Name],[Last_Name],[Email_Address],[Contact_Number],[Address]) values('" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox8.Text + " ','" + textBox7.Text + " ') ";

                    command.ExecuteNonQuery();
                    MessageBox.Show("Employee Database Update Successful!!");
                    suu = 1;
                    suu = 2;
                    connection.Close();
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("error " + ex);
                }
            
            
            }

            if (suu == 2)
            {
                textBox1.Text = textBox2.Text = textBox3.Text = textBox4.Text = textBox5.Text = textBox6.Text = textBox7.Text = textBox8.Text = "";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
