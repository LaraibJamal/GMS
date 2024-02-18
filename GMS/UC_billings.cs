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
    public partial class UC_billings : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        SqlDataReader dr;
        public UC_billings()
        {
            InitializeComponent();
        }

        private void UC_billings_Load(object sender, EventArgs e)
        {
            showData();
        }
        private void showData()
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            string cmd = "Select * from billing";
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlCommandBuilder.DataAdapter = sqlDataAdapter;
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "billing");
            dataGridView1.DataSource = dataSet.Tables["billing"];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "")
            {
                conn.Open();
                cmd = new SqlCommand("select * from billing where bill_id='" + int.Parse(textBox1.Text) + "'", conn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    MessageBox.Show("Bill with this number already exist please try another ", "Error", 
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    dr.Close();
                    cmd = new SqlCommand("insert into billing (bill_id, part_name,part_price,part_quantity," +
                        "total_price) VALUES (@bill_id, @part_name,@part_price,@part_quantity,@total_price)", conn);
                    cmd.Parameters.AddWithValue("bill_id", textBox1.Text);
                    cmd.Parameters.AddWithValue("part_name", textBox2.Text);
                    cmd.Parameters.AddWithValue("part_price", textBox3.Text);
                    cmd.Parameters.AddWithValue("part_quantity", textBox5.Text);
                    cmd.Parameters.AddWithValue("total_price", textBox4.Text);                    
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

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                conn.Open();
                string query3 = "Delete from billing Where bill_id = '" + int.Parse(textBox1.Text) + "' ";
                SqlCommand cmd = new SqlCommand(query3, conn);
                cmd.ExecuteNonQuery();
                string query4 = "Select max(bill_id) from billing";
                SqlCommand cmd2 = new SqlCommand(query4, conn);
                SqlDataReader da = cmd2.ExecuteReader();
                if (da.Read())
                {
                    MessageBox.Show("Information Deleted Successfully ...!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Information Deleted Unsuccessfully ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
