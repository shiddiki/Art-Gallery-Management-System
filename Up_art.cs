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
    public partial class Up_art : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public static string fpath= @"C:\Users\sid\Pictures\", oldFile="",newFile="";
       
        public Up_art()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void Up_art_Load(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = " select * from Painting";
                command1.CommandText = query;

                OleDbDataAdapter da1 = new OleDbDataAdapter(command1);
                 DataTable dt1 = new DataTable();

                da1.Fill(dt1);
                dataGridView1.DataSource = dt1;
                //dataGridView1.Columns["Artist_ID"].DataPropertyName = "ID";
                // dataGridView1.Columns["myColumn"].DefaultCellStyle.BackColor = Color.Red;

                


                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            DataGridViewCell cel = null;
            foreach (DataGridViewCell selectedCell in dataGridView1.SelectedCells)
            {
                cel = selectedCell;
                break;

            }
            if (cel != null) //find out row
            {

                DataGridViewRow row = cel.OwningRow;

                textBox1.Text = row.Cells[0].Value.ToString();
                textBox2.Text = row.Cells[1].Value.ToString();
                oldFile = fpath + textBox2.Text + ".jpg";
                textBox3.Text = row.Cells[2].Value.ToString();
                textBox4.Text = row.Cells[3].Value.ToString();
                textBox5.Text = row.Cells[4].Value.ToString();
                textBox6.Text = row.Cells[5].Value.ToString();
                textBox7.Text = row.Cells[6].Value.ToString();

            }
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.ForeColor = Color.LawnGreen;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.ForeColor = Color.PaleGreen;
        }

        private void label8_Click(object sender, EventArgs e)
        {
            connection.Close();
            try
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = connection;
                string query = "update Painting set Title ='" + textBox2.Text + "' ,Art_Year ='" + textBox3.Text + "' ,Artist_Name ='" + textBox4.Text + "',Price ='" + textBox5.Text + "',Exhibition_At ='" + textBox6.Text + "',Status='"+textBox7.Text+"' where ID =" + textBox1.Text + " ";
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("Editing Successful!");
                connection.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("error " + ex);
            }

            newFile = fpath + textBox2.Text + ".jpg";
            if(oldFile!=newFile)
            {
                try { rename(); }
                catch
                {
                    MessageBox.Show("Cant rename!!");
                }
            
            }

            //refresshing
            refreshdata();




        }

        public void rename()
        {int ii;
            if (System.IO.File.Exists(oldFile))
                 ii=1000;
            if (System.IO.File.Exists(newFile))
                ii = 99;

            if (System.IO.File.Exists(oldFile)) 
            System.IO.File.Move(oldFile,newFile);
        }

        public void refreshdata()
        {
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();

            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = " select * from Painting";
                command1.CommandText = query;

                OleDbDataAdapter da2 = new OleDbDataAdapter(command1);
                DataTable dt1 = new DataTable();

                da2.Fill(dt1);
                dataGridView1.DataSource = dt1;
                //dataGridView1.Columns["Artist_ID"].DataPropertyName = "ID";
                // dataGridView1.Columns["myColumn"].DefaultCellStyle.BackColor = Color.Red;

                


                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

        
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
