﻿using System;
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
    public partial class usc3 : UserControl
    {
        private OleDbConnection connection = new OleDbConnection();
        public usc3()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
           
        }

        private void usc3_Load(object sender, EventArgs e)
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

                DataGridViewColumn column = dataGridView1.Columns[0];
                column.Width = 70;
                column = dataGridView1.Columns[1];
                column.Width = 150;
                column = dataGridView1.Columns[2];
                column.Width = 100;
                column = dataGridView1.Columns[3];
                column.Width = 200;
                column = dataGridView1.Columns[4];
                column.Width = 150;
                column = dataGridView1.Columns[5];
                column.Width = 100;
                column = dataGridView1.Columns[6];
                column.Width = 100;



                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }
        }
        

        

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }
}
