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
    public partial class LoginForm : Form
    {
        
        public LoginForm()
        {
            InitializeComponent();

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {
            //panel1.BackColor = Color.FromArgb(100, 0, 0, 0);

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Register rg = new Register();
            rg.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login lg = new Login();
            lg.ShowDialog();

        }

        //private void textBox2_TextChanged(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "Username") 
        //    {
        //        textBox2.Text = "";
        //        textBox2.ForeColor = Color.Black;

        //    }
        //}

        //private void textBox2_Leave(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "")
        //    {
        //        textBox2.Text = "Username";
        //        textBox2.ForeColor = Color.Silver;

        //    }
        //}

        //private void textBox1_TextChanged(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "Username")
        //    {
        //        textBox2.Text = "";
        //        textBox2.ForeColor = Color.Black;

        //    }
        //}

        //private void textBox1_Leave(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "")
        //    {
        //        textBox2.Text = "Password";
        //        textBox2.ForeColor = Color.Silver;

        //    }
        //}

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    if (textBox2.Text == "admin" && textBox1.Text == "admin")
        //    {
        //        this.Hide();
        //        //AdminForm ad = new AdminForm();
        //        //ad.ShowDialog();
        //        DelayScreen ds = new DelayScreen();
        //        ds.ShowDialog();
        //    }
        //    else if (textBox2.Text == "emp1" && textBox1.Text == "1234")
        //    {
        //        this.Hide();
        //        EmployeeForm ep = new EmployeeForm();
        //        ep.ShowDialog();
        //    }
        //    else
        //    {
        //        MessageBox.Show("Your Loggin Detail is Invalied ... !", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
        //    }
        //}
    }
}
