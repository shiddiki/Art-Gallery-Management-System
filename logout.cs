using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace art2
{
    public partial class logout : Form
    {
        public static int cnt=0;

        public logout()
        {
            InitializeComponent();
        }

        private void logout_Load(object sender, EventArgs e)
        {
            cnt = 0;
            timer1.Start();

        }

        private void hid()
        {


            this.Refresh();
           // System.Threading.Thread.Sleep(2000);
            
        
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            cnt++;
            if(cnt==5)
            {
                this.Hide();
                this.Dispose();
            login lgn = new login();
            lgn.StartPosition = FormStartPosition.CenterScreen;
            lgn.ShowDialog();}
        }
    }
}
