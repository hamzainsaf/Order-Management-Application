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
    public partial class Order : Form
    {
        DataTable table = new DataTable();
        MyConnection db = new MyConnection();

        public Order()
        {
            InitializeComponent();
            FILLDGV();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }
        private void FILLDGV()
        {
            db.con.Open();
            string query = "Select * From tb3_orders";
            SqlDataAdapter da = new SqlDataAdapter(query, db.con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);

            var dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            db.con.Close();



        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            this.Close();
            
        }
    }
}
