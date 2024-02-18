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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GMS
{
    public partial class UC_spares : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        public UC_spares()
        {
            InitializeComponent();
        }

        private void UC_spares_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            string cmd = "Select * from spares";
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlCommandBuilder.DataAdapter = sqlDataAdapter;
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "spares");
            dataGridView1.DataSource = dataSet.Tables["spares"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                conn.Open();
                //dr.Close();
                cmd = new SqlCommand("insert into spares (part_name, part_quantity,part_price) " +
                    "VALUES (@part_name, @part_quantity,@part_price)", conn);
                cmd.Parameters.AddWithValue("part_name", textBox1.Text);
                cmd.Parameters.AddWithValue("part_quantity", textBox2.Text);
                cmd.Parameters.AddWithValue("part_price", textBox3.Text);
                
                cmd.ExecuteNonQuery();
                MessageBox.Show("Your data is added .", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                showData();                
            }
            else
            {
                MessageBox.Show("Please enter value in all field.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("Please, Enter part name.", "Try Again", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Focus();
                }
                else if (textBox2.Text == "")
                {
                    MessageBox.Show("Please, Enter part quantity.", "Try Again", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Focus();
                }
                else if (textBox3.Text == "")
                {
                    MessageBox.Show("Please, Enter part price.", "Try Again", 
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox3.Focus();
                }                
                else
                {

                    conn.Open();
                    string query1 = "UPDATE spares SET part_name = '" + textBox1.Text + "', " +
                        "part_quantity = '" + textBox2.Text + "', part_price = '" + textBox3.Text + "' " +
                        "WHERE spares.spares_id = spares_id";


                    SqlCommand cmd = new SqlCommand(query1, conn);
                    cmd.ExecuteNonQuery();
                    string query2 = "Select max(spares_id) from spares";
                    SqlCommand cmd2 = new SqlCommand(query2, conn);
                    SqlDataReader da = cmd2.ExecuteReader();
                    if (da.Read())
                    {
                        MessageBox.Show("Spares Information Updated Successfully ...!", "Thank You", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        showData();
                    }
                    else
                    {
                        MessageBox.Show("Spares Information Updated Unsuccessfully ...!", "Try Again", 
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query3 = "Delete from spares Where spares.spares_id = spares_id ";
                SqlCommand cmd = new SqlCommand(query3, conn);
                cmd.ExecuteNonQuery();
                string query4 = "Select max(spares_id) from spares";
                SqlCommand cmd2 = new SqlCommand(query4, conn);
                SqlDataReader da = cmd2.ExecuteReader();
                if (da.Read())
                {
                    MessageBox.Show("Spares Information Deleted Successfully ...!", "Thank You",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Spares Information Deleted Unsuccessfully ...!", "Try Again",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
