using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using System.IO;
using System.Configuration.Provider;
using System.Reflection.Metadata;

namespace Cp3_Project
{
     class MyConnection
    {
        public SqlConnection con;
        public MyConnection()
        {
            //string path = @"C:\Users\48512\Desktop\ConnString1.txt";

            string path = Signin.pathApp+ "\\Connectionstring\\ConnString1.txt";
            StreamReader reader = new StreamReader(path);
           string nameS =  reader.ReadToEnd();
            string conS = "Data Source="+nameS.Trim() +  ";Initial Catalog=ProjectCp_db;Integrated Security=True";
          
          

            con = new SqlConnection(conS);
        // con = new SqlConnection(ConfigurationManager.ConnectionStrings["CC"].ConnectionString);
        }
        public static string type;
    }
}
