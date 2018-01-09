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
using System.IO;

namespace art2
{
    public partial class art_works : UserControl
    {

        public static int count,loaded=0,pageno=0;
        public static string[] pics = new string[100];
        public static string[] pric = new string[100];
        
        private OleDbConnection connection = new OleDbConnection();
        public art_works()
        {
            InitializeComponent();
            connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=F:\Works\visc#\art2\LIB.accdb;Persist Security Info=False;";
            
        }

        private void usc1_Load(object sender, EventArgs e)
        {
            pageno = 0;
            loaded = 0;
            Array.Clear(pics, 0, 99);

            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = " select count(*) from Painting";
                command1.CommandText = query;

                OleDbDataAdapter da1 = new OleDbDataAdapter(command1);
                DataTable dt1 = new DataTable();

                 count = (int)command1.ExecuteScalar();

               // MessageBox.Show(count.ToString());
                //da1.Fill(dt1);
                //dataGridView1.DataSource = dt1;
                //dataGridView1.Columns["myColumn"].DefaultCellStyle.BackColor = Color.Red;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

   ///
            ///photoes
            try
            {
                connection.Open();
                string[] tasks;
                string sql = "SELECT Title FROM Painting";
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<object[]> list = new List<object[]>();
                        if (dataReader.HasRows)
                        {
                            int i = 0;
                            object[] oarray = new object[100];
                            while (dataReader.Read())
                            {
                                
                                list.Add(oarray);
                                //for (int i = 0; i < dataReader.FieldCount; i++)
                                {
                                    
                                    oarray[i] = dataReader[0];
                                    pics[i] += oarray[i];
                                    i++;
                                    
                                }
                            }
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

            ///price
            ///
            ///photoes
            try
            {
                connection.Open();
                string[] tasks;
                string sql = "SELECT Price,Status FROM Painting";
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<object[]> list = new List<object[]>();
                        if (dataReader.HasRows)
                        {
                            int i = 0;
                            object[] oarray2 = new object[100];
                            while (dataReader.Read())
                            {

                                list.Add(oarray2);
                                //for (int i = 0; i < dataReader.FieldCount; i++)
                                {

                                    oarray2[i] = dataReader[0];

                                    if (dataReader[1].ToString() == "Available")
                                        pric[i] = oarray2[i].ToString();
                                    else
                                        pric[i] = "Sold";
                                    i++;

                                }
                            }
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }



            loadpicture();

        }

        void refresh_art()
        {
            Array.Clear(pics, 0, pics.Length);
            ///photoes
            try
            {
                connection.Open();
                string[] tasks;
                string sql = "SELECT Title FROM Painting";
                using (OleDbCommand cmd = new OleDbCommand(sql, connection))
                {
                    using (OleDbDataReader dataReader = cmd.ExecuteReader())
                    {
                        List<object[]> list = new List<object[]>();
                        if (dataReader.HasRows)
                        {
                            int i = 0;
                            object[] oarray = new object[100];
                            while (dataReader.Read())
                            {

                                list.Add(oarray);
                                //for (int i = 0; i < dataReader.FieldCount; i++)
                                {

                                    oarray[i] = dataReader[0];
                                    pics[i] += oarray[i];
                                    i++;

                                }
                            }
                        }
                    }
                }
                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }

        
        
        }

        void make_null()
        {
            pictureBox1.Image = null; pictureBox2.Image = null; pictureBox3.Image = null; pictureBox4.Image = null; pictureBox5.Image = null; pictureBox6.Image = null; pictureBox7.Image = null; pictureBox8.Image = null; pictureBox9.Image = null; pictureBox10.Image = null;
            label1.Text = "price";
        }
        
        void loadpicture()
        {
            int aa = pageno + 1;
            this.label11.Text = "Page :" +aa.ToString();
            make_null();
            string path = @"C:\Users\UAE\Pictures\";
            PictureBox[] boxes = {pictureBox1,pictureBox2,pictureBox3,pictureBox4,pictureBox5,pictureBox6,pictureBox7,pictureBox8,pictureBox9,pictureBox10};
            Label[] lb = { label1, label2, label3, label4, label5, label6, label7, label8, label9, label10 ,label12,label13,label14,label15,label16,label17,label18,label19,label20,label21};
            for (int y = 0; y < 10; y++)
                lb[y].Text = "Title";
            for (int y = 10; y < 20; y++)
                lb[y].Text = "Price";

            if (count <= 10)
                this.button2.Invalidate();
           

            if(pageno==0)
            {
                for(int i=0;loaded<count && i<10;i++)
                {
                    boxes[i].ImageLocation = path+pics[i]+".jpg";
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    lb[i].Text = pics[i];
                    lb[i + 10].Text = pric[i];
                loaded++;

                if (pric[i] == "Sold" || pric[i] == "sold")
                    boxes[i].Enabled = false;
                else
                    boxes[i].Enabled = true;

                }
        
                }


            if (pageno == 1)
            {
                for (int i = 0,j=10; loaded < count && i < 10; i++,j++)
                {
                    boxes[i].ImageLocation = path + pics[j] + ".jpg";
                    this.pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    lb[i].Text = pics[j];
                    lb[i + 10].Text = pric[j];
                    loaded++;
                    if (pric[j] == "Sold" || pric[j] == "sold")
                        boxes[i].Enabled = false;
                    else
                        boxes[i].Enabled = true;
                }

            }

            for (int i = 11,j=0; i < 20; i++)
            {
                
            }

            }



        private void label1_Click(object sender, EventArgs e)
        {

        }
        Form1 fm1;

        // UserControl1 code
        public event EventHandler SomethingHappened;
        public void button1_Click(object sender, EventArgs e)
        {
            if (SomethingHappened ==null) // notify listeners, if any
                SomethingHappened(sender, EventArgs.Empty);
            //var handler = SomethingHappened;

           // this.fm1.u1tou3();
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //this.dataGridView1.Rows.Clear();
            try
            {
                connection.Open();
                OleDbCommand command1 = new OleDbCommand();
                command1.Connection = connection;
                string query = " select * from Student";
                command1.CommandText = query;

                OleDbDataAdapter da1 = new OleDbDataAdapter(command1);
                DataTable dt1 = new DataTable();

                da1.Fill(dt1);
                //dataGridView1.DataSource = dt1;
                //dataGridView1.Columns["myColumn"].DefaultCellStyle.BackColor = Color.Red;

                connection.Close();
            }
            catch (Exception ex)
            {
                connection.Close();
                MessageBox.Show("error " + ex);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            base1.selected_art = label2.Text;
            base1.sel_art_price = label13.Text;
            
            label11.Text = label2.Text + " is selected.";

            if (pictureBox2.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            base1.selected_art = label1.Text;
            base1.sel_art_price = label12.Text;
            
            label11.Text = label1.Text + " is selected.";
            if (pictureBox1.Enabled == false)
                label11.Text = "";
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            base1.selected_art = label3.Text;
            base1.sel_art_price = label14.Text;
            label11.Text = label3.Text + " is selected.";
            if (pictureBox3.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            base1.selected_art = label4.Text;
            base1.sel_art_price = label15.Text;
            label11.Text = label4.Text + " is selected.";
            if (pictureBox4.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            base1.selected_art = label5.Text;
            base1.sel_art_price = label16.Text;
            label11.Text = label5.Text + " is selected.";
            if (pictureBox5.Enabled == false)
                label11.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(loaded<count)
            {
                pageno++;
                make_null();
                loadpicture();
            }
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (loaded > 10)
            {
                loaded = loaded-(10+loaded % 10);
                pageno--;
                make_null();
                loadpicture();
            }
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            base1.selected_art = label6.Text;
            base1.sel_art_price = label17.Text;
            label11.Text = label6.Text + " is selected.";
            if (pictureBox6.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            base1.selected_art = label7.Text;
            base1.sel_art_price = label18.Text;
            label11.Text = label7.Text + " is selected.";
            if (pictureBox7.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            base1.selected_art = label8.Text;
            base1.sel_art_price = label19.Text;
            label11.Text = label8.Text + " is selected.";
            if (pictureBox8.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            base1.selected_art = label9.Text;
            base1.sel_art_price = label20.Text;
            label11.Text = label9.Text + " is selected.";
            if (pictureBox9.Enabled == false)
                label11.Text = "";
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            base1.selected_art = label10.Text;
            base1.sel_art_price = label21.Text;
            label11.Text = label10.Text + " is selected.";
            if (pictureBox10.Enabled == false)
                label11.Text = "";
        }

       
    }
}
