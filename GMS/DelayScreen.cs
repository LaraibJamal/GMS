using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS
{
    public partial class DelayScreen : Form
    {
        private Timer timer;
        public DelayScreen()
        {
            InitializeComponent();
            InitializeTimer();
        }
        private void InitializeTimer()
        {
            timer = new Timer();
            timer.Interval = 5000;
            timer.Tick += Timer_Tick;
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Stop();
            this.Hide();
            AdminForm ad = new AdminForm();
            ad.ShowDialog();
            
        }
        private void DelayScreen_Load(object sender, EventArgs e)
        {
            timer.Start();            
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
