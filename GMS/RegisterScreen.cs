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
using System.Data.SqlClient;
using System.Collections;
using System.Xml.Linq;
using System.Data.Common;

namespace GMS
{
    public partial class Register : Form
    {

        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        public Register()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
            conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            conn.Open();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "" && txtpassword.Text !="" && txtComPassword.Text != "")
            {
                if (txtpassword.Text == txtComPassword.Text)
                {
                    cmd = new SqlCommand("select * from users where username='" + txtUsername.Text + "'", conn);
                    dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Username Already exist please try another ", "Error", 
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();                                               
                        cmd = new SqlCommand("insert into users (username, password) VALUES" +
                            " (@username, @password)", conn);
                        cmd.Parameters.AddWithValue("username", txtUsername.Text);
                        cmd.Parameters.AddWithValue("password",txtpassword.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Your Account is created . Please login now.", "Done", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        LoginForm lg = new LoginForm();
                        lg.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("Please enter both password same ", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void checkbxShowPas_CheckedChanged(object sender, EventArgs e)
        {
            if (checkbxShowPas.Checked)
            {
                txtpassword.PasswordChar = '\0';
                txtComPassword.PasswordChar = '\0';
            }
            else
            {
                txtpassword.PasswordChar = '*';
                txtComPassword.PasswordChar = '*';
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtpassword.Text = "";
            txtComPassword.Text = "";
            txtUsername.Focus();
        }

        private void label7_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
                
        }

        private void label8_Click(object sender, EventArgs e)
        {
            //this.Hide();
            //Login lg = new Login();
            //lg.ShowDialog();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
