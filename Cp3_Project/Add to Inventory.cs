using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cp3_Project
{
    public partial class Add_to_Inventory : Form
    {
        MyConnection db = new MyConnection();
        public Add_to_Inventory()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && comboBox1.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                using (db.con)
                {
                    db.con.Open();
                    SqlCommand cmd = new SqlCommand("UserAddInventory", db.con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ProductName", textBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Catagory", comboBox1.Text.Trim());
                    cmd.Parameters.AddWithValue("@Price", textBox3.Text.Trim());
                    cmd.Parameters.AddWithValue("@Availability", textBox4.Text.Trim());
                  
                    
                    //int newqty = Convert.ToInt16(textBox4.Text);
                    //string query = "UPDATE Inventory1 set Availability = " + newqty + " where Name = '" + textBox1.Text + "';";
                    //SqlCommand cmd1 = new SqlCommand(query, db.con);
                    //cmd.ExecuteNonQuery();



                    cmd.ExecuteNonQuery();
                    db.con.Close();
                    MessageBox.Show("Product Added to Inventory");
                    Clear();
                    this.Hide();
                    ViewInventory V1 = new ViewInventory();
                    V1.Show();
                    
                }
            }
            else
            {
                MessageBox.Show("Fill in the details");
                Clear();
            }
        }
        void Clear()
        {
            textBox1.Text = comboBox1.Text = textBox3.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            ViewInventory V1 = new ViewInventory();
            V1.Show();
        }

        

        
    }
    
}
