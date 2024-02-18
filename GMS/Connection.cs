using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
using System.Collections;
using System.Windows.Forms;

namespace GMS
{
    
    class Connection
    {
        public string MyConnection()
        {
            string con = @"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True";
            return con;
        }
        public static readonly string con_string = @"Data Source=DESKTOP-NPFR55U;Initial Catalog=GMS;Integrated Security=True";
        public static SqlConnection con = new SqlConnection(con_string);


        //Method for CURD Operation!
        public static int SQL(string qry, Hashtable ht)
        {
            int res = 0;
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;

                foreach (DictionaryEntry item in ht)
                {
                    cmd.Parameters.AddWithValue(item.Key.ToString(), item.Value);
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                res = cmd.ExecuteNonQuery();
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();
            }


            return res;
        }
        //For loading Data from Database
        public static void LoadData(string qry, DataGridView gv, ListBox lb)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(qry, con);
                cmd.CommandType = CommandType.Text;
                SqlDataAdapter sd = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sd.Fill(dt);

                for (int i = 0; i < lb.Items.Count; i++)
                {
                    string colName1 = ((DataGridViewColumn)lb.Items[i]).Name;
                    gv.Columns[colName1].DataPropertyName = dt.Columns[i].ToString();
                }
                gv.DataSource = dt;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                con.Close();

            }
        }
    }
}

