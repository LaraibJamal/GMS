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
    public partial class Emp_Vehicle : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        public Emp_Vehicle()
        {
            InitializeComponent();
        }

        private void Emp_Vehicle_Load(object sender, EventArgs e)
        {
            showData();
        }

        private void showData()
        {
            try
            {
                conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");

                string cmd = "Select * from vehicles";
                SqlCommand sqlCommand = new SqlCommand(cmd, conn);
                SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

                sqlCommandBuilder.DataAdapter = sqlDataAdapter;
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataSet dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "vehicles");
                dataGridView1.DataSource = dataSet.Tables["vehicles"];

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("select * from vehicles where v_number='" + textBox1.Text + "'", conn);
                dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Vehicle with this number already exist please try another ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into vehicles (v_number, v_brand,v_model,v_color,owner_name,date_in) VALUES (@v_number, @v_brand,@v_model,@v_color,@owner_name,@date_in)", conn);
                    cmd.Parameters.AddWithValue("v_number", textBox1.Text);
                    cmd.Parameters.AddWithValue("v_brand", textBox2.Text);
                    cmd.Parameters.AddWithValue("v_model", textBox3.Text);
                    cmd.Parameters.AddWithValue("v_color", textBox4.Text);
                    cmd.Parameters.AddWithValue("owner_name", textBox5.Text);
                    cmd.Parameters.AddWithValue("date_in", dateTimePicker1.Text);
                    //cmd.Parameters.AddWithValue("date_out", dateTimePicker2.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Your data is added .", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query3 = "Delete from vehicles Where v_number = '" + int.Parse(textBox1.Text) + "' ";
                SqlCommand cmd = new SqlCommand(query3, conn);
                cmd.ExecuteNonQuery();
                string query4 = "Select max(v_number) from vehicles";
                SqlCommand cmd2 = new SqlCommand(query4, conn);
                SqlDataReader da = cmd2.ExecuteReader();
                if (da.Read())
                {
                    MessageBox.Show("Car Information Deleted Successfully ...!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Car Information Deleted Unsuccessfully ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
