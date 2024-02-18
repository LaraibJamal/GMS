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
    public partial class Emp_Spares : UserControl
    {
        SqlConnection conn;
        SqlCommand cmd;
        public Emp_Spares()
        {
            InitializeComponent();
        }

        private void Emp_Spares_Load(object sender, EventArgs e)
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
                cmd = new SqlCommand("insert into spares (part_name, part_quantity,part_price) VALUES (@part_name, @part_quantity,@part_price)", conn);
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
                    MessageBox.Show("Spares Information Deleted Successfully ...!", "Thank You", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    showData();
                }
                else
                {
                    MessageBox.Show("Spares Information Deleted Unsuccessfully ...!", "Try Again", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
