using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL_APP
{
    public static class Global
    {
        public static SqlDataAdapter adapter = new SqlDataAdapter();
        public static DataBase dataBase = new DataBase();
        public static Point CurrentWindowPosition = new Point(81, 75);
        public static bool IsFormMoved = false;
        
        public static SqlCommand executeSqlCommand (string quertystring)
        {
            return new SqlCommand(quertystring, Global.dataBase.getConnection());

        }
    }
}
