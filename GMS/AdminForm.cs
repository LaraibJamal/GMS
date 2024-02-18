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
    public partial class AdminForm : Form
    {
        private Timer timer;
        public AdminForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick; 
            timer.Start(); 
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            label6.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            SidePanel.Height = analytics_btn.Height;
            SidePanel.Top = analytics_btn.Top;
            SidePanel.Invalidate();
            UC_analytics al = new UC_analytics();
            if (panel1.Controls.Count>0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(al);
            al.Dock = DockStyle.Fill;
            al.BringToFront();
            al.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void vehicle_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = vehicle_btn.Height;
            SidePanel.Top = vehicle_btn.Top;
            SidePanel.Invalidate();
            UC_vehicle vc = new UC_vehicle();
            //vc.TopLevelControl = false;
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(vc);
            vc.Dock = DockStyle.Fill;
            vc.BringToFront();
            vc.Show();
        }

        private void spares_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = spares_btn.Height;
            SidePanel.Top = spares_btn.Top;
            SidePanel.Invalidate();
            UC_spares sc = new UC_spares();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(sc);
            sc.Dock = DockStyle.Fill;
            sc.BringToFront();
            sc.Show();
        }

        private void employess_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = employess_btn.Height;
            SidePanel.Top = employess_btn.Top;
            SidePanel.Invalidate();
            UC_employees ep = new UC_employees();            
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(ep);
            ep.Dock = DockStyle.Fill;
            ep.BringToFront();
            ep.Show();
        }

        private void billing_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = billing_btn.Height;
            SidePanel.Top = billing_btn.Top;
            SidePanel.Invalidate();
            UC_billings bp = new UC_billings();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(bp);
            bp.Dock = DockStyle.Fill;
            bp.BringToFront();
            bp.Show();
        }

        private void analytics_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = analytics_btn.Height;
            SidePanel.Top = analytics_btn.Top;
            UC_analytics al = new UC_analytics();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(al);
            al.Dock = DockStyle.Fill;
            al.BringToFront();
            al.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void SidePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
