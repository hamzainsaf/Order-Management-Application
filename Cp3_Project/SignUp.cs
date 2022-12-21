using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;


namespace Cp3_Project
{
    public partial class SignUp : Form
    {
        Signin s1 = new Signin();
        MyConnection db = new MyConnection();
        public SignUp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            signup();
        }
        void  Clear()
        {
            textBox1.Text = textBox2.Text = textBox3.Text = "";
        }
        void check()
        {
            string Name = textBox2.Text;
            db.con.Open();

            string sql = "SELECT COUNT(*) from tb1_userdata where username like '" + Name+"'";
            SqlCommand cmd = new SqlCommand(sql, db.con);
            int userCount = (int)cmd.ExecuteScalar();
            if (userCount > 0)
            {
                MessageBox.Show("User exists");
                return;
            }
                db.con.Close();
           
            Clear();
          


        }
        void signup()
        {
            string Name = textBox2.Text;
            db.con.Open();
            string sql = "SELECT COUNT(*) from tb1_userdata where username like '" + Name + "'";
            SqlCommand cmd1 = new SqlCommand(sql, db.con);
            int userCount = (int)cmd1.ExecuteScalar();
            if (userCount > 0)
            {
                MessageBox.Show("User exists");
                db.con.Close();
                Clear();
            }

            else if (textBox1.Text.Contains(" ") && textBox2.Text.Contains(" ") && textBox3.Text.Contains(" "))
            {
                MessageBox.Show("Can not Have space");
                Clear();
            
            }


            else if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                db.con.Close();
                db.con.Open();
                SqlCommand cmd2 = new SqlCommand("userdataADD", db.con);
                cmd2.CommandType = CommandType.StoredProcedure;
                string usr = textBox2.Text.Trim();


                cmd2.Parameters.AddWithValue("@name", textBox1.Text.Trim());
                cmd2.Parameters.AddWithValue("@username", usr);
                cmd2.Parameters.AddWithValue("@password", textBox3.Text.Trim());

                cmd2.ExecuteNonQuery();
                MessageBox.Show("Sign Up Successfull");
                db.con.Close();

                Clear();
                Signin f = new Signin();
                f.Show();
                this.Close();


            }
            else
            {
                MessageBox.Show("Fill in the Sign Up form");
                Clear();
            }


        }
       

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.OpenForms[0].Show();
            
        }
    }
}
