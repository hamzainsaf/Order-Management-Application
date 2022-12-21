using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cp3_Project
{
    public partial class Deactivate : Form
    {
        MyConnection db = new MyConnection();
        public Deactivate()
        {
            InitializeComponent();
            FILLDGV();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            userName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            
        }
        private void FILLDGV()
        {
            db.con.Open();
            string query = "Select * From tb1_userdata";
            SqlDataAdapter da = new SqlDataAdapter(query, db.con);
          
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            db.con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            db.con.Open();
            string newqty = "0";
            if (userName.Text == "Admin")
            {
                MessageBox.Show("Can not Dectivate Admin");
            }
            else
            {
                string query = "UPDATE tb1_userdata set Type = " + newqty + " where Name = '" + userName.Text + "';";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.ExecuteNonQuery();
                
            }
            db.con.Close();
            FILLDGV();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            db.con.Open();
            string newqty = "1";
            if (userName.Text == "Admin")
            {
                MessageBox.Show("It is Set as Admin");
            }
            else
            {
                string query = "UPDATE tb1_userdata set Type = " + newqty + " where Name = '" + userName.Text + "';";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.ExecuteNonQuery();
               
            }
            db.con.Close();
            FILLDGV();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }
    }
}
