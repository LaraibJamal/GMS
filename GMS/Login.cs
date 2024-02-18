using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace GMS
{
    
public partial class Login : Form
{
        SqlCommand cmd;
        SqlConnection conn;
        SqlDataReader dr;
        
        public Login()
        {
        InitializeComponent();
        txtpassword.PasswordChar = '*';
        }

    private void panel1_Paint(object sender, PaintEventArgs e)
    {

    }

    private void Login_Load(object sender, EventArgs e)
    {
        panel1.BackColor = Color.FromArgb(100, 0, 0, 0);
        conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
        conn.Open();    
    }

    private void button1_Click(object sender, EventArgs e)
    {
            if (txtUsername.Text != "" && txtpassword.Text != "")
            {
                cmd = 
                    new SqlCommand("select * from users where username='" + 
                    txtUsername.Text + "' and password='" + txtpassword.Text + "'", conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    if (txtUsername.Text == "admin" && txtpassword.Text == "admin")
                    {
                        this.Hide();
                        DelayScreen ds = new DelayScreen();
                        ds.ShowDialog();
                    }
                    else
                    {
                        this.Hide();
                        DelayScreen ds = new DelayScreen();
                        EmployeeForm ep = new EmployeeForm();
                        ep.ShowDialog();
                    }
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("No Account avilable with this username and password ", "Error", 
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
        //if (checkbxShowPas.Checked)
        //{
        //    txtpassword.PasswordChar = '\0';
        //}
        //else
        //{

        //    txtpassword.PasswordChar = '*';
        //}
        txtpassword.PasswordChar = checkbxShowPas.Checked ? '\0' : '*';
    }

    private void label7_Click(object sender, EventArgs e)
    {
        this.Hide();
        Register rg = new Register();
        rg.ShowDialog();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        txtUsername.Text = "";
        txtpassword.Text = "";
        txtUsername.Focus();
    }

    private void txtpassword_TextChanged(object sender, EventArgs e)
    {

    }

    private void label8_Click(object sender, EventArgs e)
    {

    }

    private void button3_Click(object sender, EventArgs e)
    {
        Application.Exit();
    }
}
    
}
