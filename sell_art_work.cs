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
    public partial class sell_art_work : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public sell_art_work()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void usc7_Load(object sender, EventArgs e)
        {
            if (base1.selected_art.Length == 0)
                label14.Text = "Select Art form Art Works.";
            else
            {
                label11.Text = base1.selected_art;
                label13.Text = base1.sel_art_price;
                textBox5.Text = base1.selected_art;
                textBox6.Text = base1.sel_art_price;
                label14.Text = "One Art is selected.";
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //updtae sales table

            if (base1.selected_art.Length == 0)
                return;

            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                command.CommandText = "insert into Sales ([Customer_Name],[Contact_Number],[Address],[Email_Address],[Art_Bought],[Price],[Date_Bought]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + " ','" + textBox7.Text + "') ";

                command.ExecuteNonQuery();
                MessageBox.Show("Successful!!");
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

            //update painting tabel
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update Painting set [Status] = 'Sold' where [Title] = '" + textBox5.Text + "' ";
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("done editing");
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error " + ex);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            textBox7.Text = dateTimePicker1.Value.Date.ToString();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
