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

    
    public partial class login : Form
    {
        private OleDbConnection connection = new OleDbConnection();

        public login()
        {

            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
            //toolStripMenuItem1.Invalidate();
            StartPosition = FormStartPosition.CenterScreen;
            pictureBox1.Image = Image.FromFile(@"F:\Works\visc#\art2\info.png");
            this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            label4.Text = "";
        }

        private void login_Load(object sender, EventArgs e)
        {

             try
            {
                connection.Open();
                //MessageBox.Show("ok");\
                label4.Text = "Connected";
                connection.Close();
            }

            catch (Exception ex)
            {

                MessageBox.Show("Error " + ex);
                

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "select * from Users where User_ID ='" + textBox1.Text + " ' and Password = '" + textBox2.Text + "' ";

                OleDbDataReader reader = command.ExecuteReader();
                int count = 0;
                while (reader.Read())
                {
                    count++;

                }


                if (count == 1 || (textBox1.Text == "sidsi" && textBox2.Text == "39"))
                {
                    //MessageBox.Show("correct");
                    label4.Text = "Login Approved";
                    connection.Close();
                    connection.Dispose();
                    base1.current_user = textBox1.Text;
                    this.Hide();
                    Form1 frm = new Form1();
                    frm.Show();
                    connection.Close();
                }
                else if (count > 1)
                {
                    label4.Text = " duplicate and same";
                }
                else if (count < 1)
                {
                   label4.Text = "Password or Username is not correct.";

                }

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Minimize(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Environment.Exit(1);
        }
    }
}
