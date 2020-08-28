using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace webApiDemoApp.DBFile
{
   public class DBConn
    {


        internal static DataTable GetLocalStudent(string sql)
        {
            DataTable da = new DataTable();
            try
            {
                string conn = "server=.;database=test;uid=sa;pwd=123456";
                SqlConnection sqlconn = new SqlConnection(conn);
                SqlCommand sqlcom = new SqlCommand(sql, sqlconn);
                SqlDataAdapter sD = new SqlDataAdapter(sqlcom);
             
                sD.Fill(da);
                sqlconn.Close();
            }
           catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            return da;
        }

     
    }
}
