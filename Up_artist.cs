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
    public partial class Up_artist : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public Up_artist()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void Up_artist_Load(object sender, EventArgs e)
        {
            //textBox1.Enabled = false;
            dataGridView1.Refresh();
            dataGridView1.Update();
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = " select * from Artists";
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
                    textBox3.Text = row.Cells[2].Value.ToString();
                    textBox4.Text = row.Cells[3].Value.ToString();
                    textBox5.Text = row.Cells[4].Value.ToString();
                    textBox6.Text = row.Cells[5].Value.ToString();

                    

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
                string query = "update Artists set Artist_Name ='" + textBox2.Text + "' ,Webpage ='" + textBox3.Text + "' ,Age ='" + textBox4.Text + "',Style_of_art ='" + textBox5.Text + "',Address ='" + textBox6.Text + "' where ID =" + textBox1.Text + " ";
                command.CommandText = query;

                command.ExecuteNonQuery();
                MessageBox.Show("done editing");
                
                connection.Close();
                
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("error " + ex);
            }

            refreshdata();
            
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
                string query = " select * from Artists";
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

    }
}
