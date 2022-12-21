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
    public partial class Signin : Form
    {
        MyConnection db = new MyConnection();
        public static string SetValueForText1 = "";
        public Signin()
        {
            InitializeComponent();
            db.con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SignUp S = new SignUp();
            S.Show();
            this.Hide();
        }

         
            


    private void button1_Click(object sender, EventArgs e)
        {
            signin();
        }
        void signin()
        {

            {
                SqlCommand cmd = new SqlCommand("sp_userdata", db.con);
                cmd.CommandType = CommandType.StoredProcedure;
                db.con.Open();
                cmd.Parameters.AddWithValue("@username", textBox1.Text);
                cmd.Parameters.AddWithValue("@upass", textBox2.Text);
                SqlDataReader rd = cmd.ExecuteReader();
                try
                {

                    if (rd.HasRows)
                    {
                        {
                            rd.Read();
                            if (rd[4].ToString() == "0")
                            {
                                MessageBox.Show("Can not sign in");
                                db.con.Close();
                                Clear();
                                return;
                            }
                            else if (rd[4].ToString() == "Admin")
                            {
                                MyConnection.type = "A";
                            }
                            else if (rd[4].ToString() == "1" || rd[4].ToString() == "")
                            {
                                MyConnection.type = "U";
                            }
                            SetValueForText1 = textBox1.Text;
                            Dashboard d = new Dashboard();
                            d.Show();
                            Clear();
                            db.con.Close();
                            this.Hide();




                        }
                    }

                    else
                    {

                        MessageBox.Show("Login Unsucessful");
                        db.con.Close();
                        Clear();
                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.ToString());
                }

            }
        }

        private void Signin_FormClosing(Object sender, FormClosingEventArgs e)
        { 
             Environment.Exit(0);
        
        }
        void Clear()
        {
            textBox1.Text = textBox2.Text = "";
        }
    }
}
