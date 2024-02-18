using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GMS
{
    public partial class EmployeeForm : Form
    {
        private Timer timer;
        public EmployeeForm()
        {
            InitializeComponent();
            timer = new Timer();
            timer.Interval = 1000; 
            timer.Tick += Timer_Tick; 
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Update the label's text with the current time
            label5.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void vehicle_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = vehicle_btn.Height;
            SidePanel.Top = vehicle_btn.Top;

            
            SidePanel.Invalidate();
            Emp_Vehicle emvh = new Emp_Vehicle();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(emvh);
            emvh.Dock = DockStyle.Fill;
            emvh.BringToFront();
            emvh.Show();
        }

        private void spares_btn_Click(object sender, EventArgs e)
        {
            SidePanel.Height = spares_btn.Height;
            SidePanel.Top = spares_btn.Top;
            SidePanel.Invalidate();
            Emp_Spares emsp = new Emp_Spares();
            if (panel1.Controls.Count > 0)
            {
                panel1.Controls.Clear();
            }
            panel1.Controls.Add(emsp);
            emsp.Dock = DockStyle.Fill;
            emsp.BringToFront();
            emsp.Show();
        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            totalcars();
            totalspare();
        }
        private void totalcars()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Count (v_number) From vehicles";
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            lbl_cars.Text = rows_count.ToString();
        }

        private void totalspare()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Count (spares_id) From spares";
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            lbl_spare.Text = rows_count.ToString();
        }
    }
}
