using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryDal
{
    public class DbHelper
    {
        public static SqlConnection GetConnection()
        {
            SqlConnection conn = new SqlConnection("Data Source=HADIA\\SQLEXPRESS;Initial Catalog=BEMP;Integrated Security=True;Persist Security Info=False;Pooling=False;Multiple Active Result Sets=False;Encrypt=True;Trust Server Certificate=True;Command Timeout=0");
            return conn;
        }
    }
}