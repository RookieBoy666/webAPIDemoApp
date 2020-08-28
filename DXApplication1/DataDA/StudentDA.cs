using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using webApiDemoApp.DBFile;

namespace webApiDemoApp.DataDA
{
 public   class StudentDA
    {
        public  static DataTable getStudents(string id)
        {
            DataTable dt = new DataTable();

            string sql = @"select * from Student 

 WHERE Id='" + id + @"' ";
               dt = DBConn.GetLocalStudent(sql);



            return dt;
        }
    }
}
