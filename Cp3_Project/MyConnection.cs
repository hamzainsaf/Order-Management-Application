using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;

namespace Cp3_Project
{
     class MyConnection
    {
        public SqlConnection con;
        public MyConnection()
        {
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["CC"].ConnectionString);
        }
        public static string type;
    }
}
