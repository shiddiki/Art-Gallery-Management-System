using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace art2
{
    public partial class Form1 : Form
    {
        public static int nowon = 0;

        public Form1()
        {
            InitializeComponent();
            //this.usc11.ParentForm = this;
            StartPosition = FormStartPosition.CenterScreen;
            if (base1.current_user == "Admin")
                label4.Enabled = true;
            else
                label4.Enabled = false;

        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x10) // WM_CLOSE
            {
                // Process the form closing. Call the base method if required,
                // and return from the function if not.
                // For examplF:
                
                    //this.Close();
                    Environment.Exit(1);
                    Application.Exit();


                
            }
            base.WndProc(ref m);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.usc11.SomethingHappened += usc1_SomethingHappened;
            ToolStripManager.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            art_works c1 = new art_works();
            panel1.Controls.Clear();
            c1.Visible = true;
            c1.Dock = DockStyle.Fill;
            panel1.Controls.Add(c1);
            nowon = 1;
            
            
        }


        
       // usc2 mc2 = new usc2();
       // usc3 mc3 = new usc3();
       // usc4 mc4 = new usc4();
       // usc5 mc5 = new usc5();
       // usc6 mc6 = new usc6();
        
        Add_art mc8 = new Add_art();
        Up_artist mc9 = new Up_artist();
        Up_art mc10 = new Up_art();
        help mc11 = new help();
        //Form1 fm = new Form1();
        
      // usc3 control1 = new usc3();
    
 
        // MainForm code
private void SomethingHappened(object sender, EventArgs e)
{
    usc3 control2 = (usc3)sender;
    //sender.SomethingHappened -= UserControl1_SomethingHappened;

    //usc3 control2 = new usc3();
    control2.Dock = DockStyle.Fill;
    panel1.Controls.Clear();
    panel1.Controls.Add(control2);
}

public void u1tou3()
{
    
   // mc3.Visible = true;
}

        /// <summary>
        /// coloring menu
        /// </summary>
public class CustomColorTable : ProfessionalColorTable
{

    

    public override Color ImageMarginGradientBegin
    {
        get
        {
            return Color.MidnightBlue;
        }
    }

    public override Color ImageMarginGradientMiddle
    {
        get
        {
            return Color.MidnightBlue;
        }
    }

    public override Color ImageMarginGradientEnd
    {
        get
        {
            return Color.MidnightBlue;
        }
    }

    public override Color ToolStripDropDownBackground
    {
        get
        {
            return Color.MidnightBlue;
        }
    }
}





        private void u1ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
           
        }

        private void u2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
           
        }


        private void usercontrol3()
        { }

       
        private void usc1_SomethingHappened(object sender, EventArgs e)
        {
            MessageBox.Show("ok");
            throw new NotImplementedException();
        }

        private void SomethingHappend(object sender, EventArgs e)
        { 
        }

        private void usc11_Load(object sender, EventArgs e)
        {

        }

       

       private void panel1_MouseDown_1(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
               // ReleaseCapture();
               // SendMessage(Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }

        
        private void changeUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            logout lg = new logout();
            lg.StartPosition = FormStartPosition.CenterScreen;
            lg.ShowDialog();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            
        }

        private void cancelRegistrationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cancel_R cr = new Cancel_R();
            cr.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ret = MessageBox.Show("Do you really want to Close the Application?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ret == System.Windows.Forms.DialogResult.No)
                return;
            else
            {
                //this.Close();
                Application.Exit();


            }
        }

        private void sellArtWorkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Update();

            sell_art_work mc7 = new sell_art_work();
            panel1.Controls.Clear();
            mc7.Visible = true;
            mc7.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc7);
            
        }

        private void galleryInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            mc8.Visible = true;
            mc8.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc8);
            //mc1.Visible = false;
        }

        private void artistsDatabseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            mc9.Visible = true;
            mc9.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc9);
        }

        private void artWorkDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            mc10.Visible = true;
            mc10.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc10);
        }

        private void galleryDatabaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            usc6 mc6 = new usc6();
            panel1.Controls.Clear();
            mc6.Visible = true;
            mc6.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc6);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            mc11.Visible = true;
            mc11.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc11);
        }

        /// <summary>
        /// lower desk
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label1_Click(object sender, EventArgs e)
        {
            art_works mc1 = new art_works();
            panel1.Controls.Clear();
            mc1.Visible = true;
            mc1.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc1);
            nowon = 1;
             label2.ForeColor = SystemColors.ControlDark; label3.ForeColor = SystemColors.ControlDark; label4.ForeColor = SystemColors.ControlDark; label5.ForeColor = SystemColors.ControlDark; label6.ForeColor = SystemColors.ControlDark;
              label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular); label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular); label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular); label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular); label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }

        /// <summary>
        /// artists
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void label2_Click(object sender, EventArgs e)
        {
            usc2 mc2 = new usc2();
            panel1.Controls.Clear();
            mc2.Visible = true;
            mc2.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc2);
            nowon = 2;
            label1.ForeColor = SystemColors.ControlDark;  label3.ForeColor = SystemColors.ControlDark; label4.ForeColor = SystemColors.ControlDark; label5.ForeColor = SystemColors.ControlDark; label6.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular);  label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular); label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular); label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular); label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }
        private void label3_Click(object sender, EventArgs e)
        {
            usc3 mc3 = new usc3();
            panel1.Controls.Clear();
            mc3.Visible = true;
            mc3.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc3);
            nowon = 3;
            label1.ForeColor = SystemColors.ControlDark; label2.ForeColor = SystemColors.ControlDark;  label4.ForeColor = SystemColors.ControlDark; label5.ForeColor = SystemColors.ControlDark; label6.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular); label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular); label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular); label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular); label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }
        private void label4_Click(object sender, EventArgs e)
        {
            registration mc4 = new registration();
            panel1.Controls.Clear();
            mc4.Visible = true;
            mc4.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc4);
            nowon = 4;
            label1.ForeColor = SystemColors.ControlDark; label2.ForeColor = SystemColors.ControlDark; label3.ForeColor = SystemColors.ControlDark; label5.ForeColor = SystemColors.ControlDark; label6.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular); label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular); label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular);  label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular); label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }

        private void label5_Click(object sender, EventArgs e)
        {
            usc6 mc6 = new usc6();
            panel1.Controls.Clear();
            mc6.Visible = true;
            mc6.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc6);
            nowon = 6;
            label1.ForeColor = SystemColors.ControlDark; label2.ForeColor = SystemColors.ControlDark; label3.ForeColor = SystemColors.ControlDark; label4.ForeColor = SystemColors.ControlDark;  label6.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular); label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular); label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular); label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular);  label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }

        private void label6_Click(object sender, EventArgs e)
        {
            usc5 mc5 = new usc5();
            panel1.Controls.Clear();
            mc5.Visible = true;
            mc5.Dock = DockStyle.Fill;
            panel1.Controls.Add(mc5);
            nowon = 5;
            label1.ForeColor = SystemColors.ControlDark; label2.ForeColor = SystemColors.ControlDark; label3.ForeColor = SystemColors.ControlDark; label4.ForeColor = SystemColors.ControlDark; label5.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular); label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular); label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular); label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular); label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular);
        }


        private void label1_MouseEnter(object sender, EventArgs e)
        {
            
        }

        private void label1_MouseEnter_1(object sender, EventArgs e)
        {
            
            label1.ForeColor = Color.White;
            label1.Font = new Font(label1.Font.Name, 26, FontStyle.Regular);
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 1)
            { label1.ForeColor = SystemColors.ControlDark;
            label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular);
            }
        }

        private void label2_MouseEnter(object sender, EventArgs e)
        {
            
            label2.ForeColor = Color.White;
            label2.Font = new Font(label2.Font.Name, 26, FontStyle.Regular);
        }

        private void label2_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 2)
            { label2.ForeColor = SystemColors.ControlDark;
            label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular);
            }
        }

        private void label3_MouseEnter(object sender, EventArgs e)
        {
           
            label3.ForeColor = Color.White;
            label3.Font = new Font(label3.Font.Name, 26, FontStyle.Regular);
        }

        private void label3_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 3)
            { label3.ForeColor = SystemColors.ControlDark;
            label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular);
            }
        }

        private void label4_MouseEnter(object sender, EventArgs e)
        {
            
            label4.ForeColor = Color.White;
            label4.Font = new Font(label4.Font.Name, 26, FontStyle.Regular);
        }

        private void label4_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 4)
            { label4.ForeColor = SystemColors.ControlDark;
            label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular);
            
            }
        }

        private void label6_MouseEnter(object sender, EventArgs e)
        {
            
            label6.ForeColor = Color.White;
            label6.Font = new Font(label6.Font.Name, 26, FontStyle.Regular);
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 5)
            {label6.ForeColor = SystemColors.ControlDark;
        label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);}
        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
           
            label5.ForeColor = Color.White;
            label5.Font = new Font(label5.Font.Name, 26, FontStyle.Regular);
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            if (nowon != 6)
            { label5.ForeColor = SystemColors.ControlDark;
            label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular);
            }
        }

        private void refToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void dataSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }




        private void fix()
        {
            label1.ForeColor = SystemColors.ControlDark; label1.Font = new Font(label1.Font.Name, 24, FontStyle.Regular);
            label2.ForeColor = SystemColors.ControlDark; label2.Font = new Font(label2.Font.Name, 24, FontStyle.Regular);
            label3.ForeColor = SystemColors.ControlDark; label3.Font = new Font(label3.Font.Name, 24, FontStyle.Regular);
            label4.ForeColor = SystemColors.ControlDark; label4.Font = new Font(label4.Font.Name, 24, FontStyle.Regular);
            label5.ForeColor = SystemColors.ControlDark; label5.Font = new Font(label5.Font.Name, 24, FontStyle.Regular);
            label6.ForeColor = SystemColors.ControlDark; label6.Font = new Font(label6.Font.Name, 24, FontStyle.Regular);
        
        }
        

        

        

        

       
        
    }
}
