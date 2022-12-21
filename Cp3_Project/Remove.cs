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
    public partial class Remove : Form
    {
        MyConnection db = new MyConnection();
        public Remove()
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
        }

        void Delete(string Namedel)
        {

            db.con.Open();

            string sql = @"DELETE FROM Inventory1 WHERE Name =" + "'" + Namedel + "'" + ';';
            SqlCommand cmd = new SqlCommand(sql, db.con);
            cmd.ExecuteReader();
            db.con.Close();
            FILLDGV();
            Clear();


        }
        void Clear()
        {
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
              Delete(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();
        }

       
    }
}
