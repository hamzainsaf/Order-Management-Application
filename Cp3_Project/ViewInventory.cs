using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Cp3_Project
{
    public partial class ViewInventory : Form
    {
        
        MyConnection db = new MyConnection();
        public ViewInventory()
        {
            InitializeComponent();
            FILLDGV();
        }

        
        private void FILLDGV()
        {
            db.con.Open();
            string query = "Select * From Inventory1";
            SqlDataAdapter da = new SqlDataAdapter(query, db.con);
            //cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            db.con.Close();
             


        }
        int qty;
        int qtydel;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                qty = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                qtydel = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
            else
            {

                MessageBox.Show("Empty row selected");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Add_to_Inventory A1 = new Add_to_Inventory();
            A1.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }

        void Delete(string Namedel)
        {
            
            db.con.Open();
            
            {
                string sql1 = @"DELETE FROM Inventory1 WHERE Name =" + "'" + Namedel + "'" + ';';
                SqlCommand cmd = new SqlCommand(sql1, db.con);
                cmd.ExecuteReader();

                db.con.Close();
                Clear();
            }
            

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() != "")
            {
                string del = textBox1.Text.Trim();
                updatedelproduct();
                
                Clear();
                FILLDGV();
            }
            else
            { MessageBox.Show("Nothing Deleted"); }
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        void Clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            numericUpDown1.Value = 0;
            numericdel.Value = 0;
        }
        void updateproduct()
        {
            db.con.Open();
            string sql = "SELECT COUNT(*) from Inventory1 where Name like '" + textBox1.Text.Trim() + "'";
            SqlCommand cmd1 = new SqlCommand(sql, db.con);
            int namedel = (int)cmd1.ExecuteScalar();

            int newqty = qty + Convert.ToInt16(numericUpDown1.Value);
            if (namedel == 0)
            {
                MessageBox.Show("Product does not exist ");
                db.con.Close();
                Clear();
            }
            
            if (newqty <= 0)
            {
                MessageBox.Show("Add more than 0");
            }
            else
            {
                string query = "UPDATE Inventory1 set Availability = " + newqty + " where Name = '" + textBox2.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show(Convert.ToInt16(numericUpDown1.Value) + " " + textBox2.Text + " Added");
                FILLDGV();
            }
        }
        void updatedelproduct()
        {
            db.con.Open();
            string sql = "SELECT COUNT(*) from Inventory1 where Name like '" + textBox1.Text.Trim() + "'";
            SqlCommand cmd1 = new SqlCommand(sql, db.con);
            int namedel = (int)cmd1.ExecuteScalar();

            int newqty = qtydel - Convert.ToInt16(numericdel.Value);
            if (namedel == 0)
            {
                MessageBox.Show("Product does not exist ");
                db.con.Close();
                Clear();
            }


            else if (newqty <= 0)
            {
                MessageBox.Show("Can not be less than 0");
            }
           
            
            else
            {
                string query = "UPDATE Inventory1 set Availability = " + newqty + " where Name = '" + textBox1.Text.Trim() + "';";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.ExecuteNonQuery();
                db.con.Close();
                MessageBox.Show(Convert.ToInt16(numericdel.Value) + " " + textBox1.Text + " Deleted");
                FILLDGV();
            }
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            updateproduct();
           
            Clear();
        }

        private void numericdel_ValueChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
