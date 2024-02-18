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
    public partial class UC_employees : UserControl
    {
        SqlConnection conn;
        public UC_employees()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void UC_employees_Load(object sender, EventArgs e)
        {
            conn = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            string cmd = "Select * from users";
            SqlCommand sqlCommand = new SqlCommand(cmd, conn);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();

            sqlCommandBuilder.DataAdapter = sqlDataAdapter;
            sqlDataAdapter.SelectCommand = sqlCommand;

            DataSet dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet, "users");
            dataGridView1.DataSource = dataSet.Tables["users"];
        }
    }
}
