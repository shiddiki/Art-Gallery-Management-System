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
    public partial class Add_art : UserControl
    {
        public static string photo_name = "",new_name="",prevous_name="";
        private OleDbConnection connection = new OleDbConnection();
        public Add_art()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void Add_art_Load(object sender, EventArgs e)
        {
            label8.Text = "";
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Blue;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.ForeColor = Color.Azure;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            label8.Text = "";

            try{
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Multiselect = false;
                //openFileDialog.Filter = "JPEG|*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    photo_name = openFileDialog.FileNames[0];

                }
                int i = photo_name.Length - 1, j = 0;
                while (photo_name[i] != '\\')
                    i--; j++;
                i = i + 1;
                new_name = photo_name.Substring(i, photo_name.Length - i - 4);


                textBox1.Text = new_name;
            }
            catch{}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (prevous_name != new_name)
            {
                try
                {
                    connection.Open();
                    OleDbCommand command = new OleDbCommand();
                    command.Connection = connection;
                    command.CommandText = "insert into Painting ([Title],[Art_Year],[Artist_Name],[Price],[Exhibition_At],[Status]) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "','" + textBox6.Text + " ') ";

                    command.ExecuteNonQuery();
                    label8.Text = "Art Database Updated!!";
                    connection.Close();
                    prevous_name = new_name;
                }
                catch (Exception ex)
                {
                    connection.Close();
                    MessageBox.Show("error " + ex);
                }
            }
            else
            {
                label8.Text = "Add new item.";
            }

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
