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
    public partial class UC_analytics : UserControl
    {
        Connection conn = new Connection();
        public UC_analytics()
        {
            InitializeComponent();
        }

        private void UC_analytics_Load(object sender, EventArgs e)
        {
            totalcars();
            totalemployee();
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

        private void totalemployee()
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True");
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Select Count (username) From users";
            Int32 rows_count = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            lbl_employee.Text = rows_count.ToString();

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
