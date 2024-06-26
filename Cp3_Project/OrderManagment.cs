﻿  using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.IO;

namespace Cp3_Project
{
    public partial class OrderManagment : Form
    {
        DataTable table = new DataTable();
        string id = Signin.SetValueForText1;
        string tablename = "Inventory1";

        MyConnection db = new MyConnection();
        public OrderManagment()
        {
            InitializeComponent();
            FILLDGV(tablename);
            table.Columns.Add("Name");
            table.Columns.Add("Unit Price");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Date");
            table.Columns.Add("Total");

        }
        
        #region
        // Visulaising the Data
        public void FILLDGV(string tablename)
        {
            
            db.con.Open();
            string query = "Select * From "+ tablename;
            SqlDataAdapter da = new SqlDataAdapter(query, db.con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            db.con.Close();



        }
        string value = "";
        private void getid()
        {

            string query = "SELECT MAX(id) FROM tb3_orders";

            db.con.Open();

            using (SqlCommand command = new SqlCommand(query, db.con))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        value = reader.GetValue(0).ToString();

                    }

                }
            }



        }
        #endregion


        int qty;
        int flag = 0;
        int total;
        int sum = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {


                if (dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() != "")
                {
                    proName.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                    pri_ce.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    qty = Convert.ToInt16(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString());
                    flag = 1;
                }
                else
                {
                    MessageBox.Show("Empty Row selected");
                }
            }

            

        }
        
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

            if (Convert.ToInt16(numericUpDown1.Value) > qty)
            {
                MessageBox.Show("Not enough in stock");
                clear();
                return;

            }
            else
            {
                total = Convert.ToInt16(numericUpDown1.Value) * Convert.ToInt16(pri_ce.Text);
                Tot.Text = total.ToString();

            }
        }
            void clear()
            {
                numericUpDown1.Value = 0;
            }
        

            private void AddToOrder_Click(object sender, EventArgs e)
            {
            

                if (numericUpDown1.Value == 0)
                {
                    MessageBox.Show("Enter the quantity of the product");
                }
                else if (flag == 0)
                {
                    MessageBox.Show("Select the product");
                }
                else
                {


                    table.Rows.Add(proName.Text, pri_ce.Text, Tot.Text, numericUpDown1.Value.ToString(), DateTime.Today.ToString("dd/MM/yyyy"));
                    dataGridView2.DataSource = table;
                    flag = 0;
                    total = Convert.ToInt16(numericUpDown1.Value) * Convert.ToInt16(pri_ce.Text);

                
            }

            sum = sum + total;

            Total_sum.Text = sum.ToString();
            
            updateproduct();
            


            
           

        }
       
    
        #region
        void updateproduct()
        {
            db.con.Open();
            int newqty = qty - Convert.ToInt16(numericUpDown1.Value);
            if (newqty < 0)
            {
                MessageBox.Show("Operation Failed");
            }
            else
            {
                string query = "UPDATE Inventory1 set Availability = " + newqty + " where Name = '" + proName.Text + "';";
                SqlCommand cmd = new SqlCommand(query, db.con);
                cmd.ExecuteNonQuery();
                db.con.Close();
                FILLDGV(tablename);
            }
        }
        void savorder()
        {
            if (Total_sum.Text == "")
            {
                MessageBox.Show("Add to  orders First");
}
            else
            {
                db.con.Open();
                SqlCommand cmd = new SqlCommand("addorders", db.con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@date", DateTime.Now);
                cmd.Parameters.AddWithValue("@username", id.Trim());
                cmd.Parameters.AddWithValue("@totalprice", Total_sum.Text.Trim());


                cmd.ExecuteNonQuery();
                MessageBox.Show("Order Added");
                db.con.Close();
                DataRow row = table.NewRow();

                row["Total"] = sum;
                table.Rows.Add(row);
                getid();
                save_csv();
            }
            

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            savorder();
            db.con.Close();
            numericUpDown1.Value = 0;
            pri_ce.Text = "";
            Tot.Text = "";
        }


        void save_csv()
        {
            string ordername = value.Trim()+"-" + DateTime.Now.ToString("yyyyMMdd");
         //  string filePath = "C:\\Users\\48512\\source\\repos\\Order-Management-Application\\Cp3_Project\\Orders\\Orders" + ordername + ".csv";
            string path = Application.StartupPath+"\\Orders\\Order"+ordername+".csv";
            using (StreamWriter writer = File.CreateText(path))
          

            {
               
                foreach (DataColumn column in table.Columns)
                {
                    writer.Write(column.ColumnName + ",");
                }
                writer.WriteLine();

                
                foreach (DataRow row in table.Rows)
                {
                    foreach (var value in row.ItemArray)
                    {
                        writer.Write(value + ",");
                    }
                    writer.WriteLine();
                }

                writer.Close();
            }

        }

     

      
        private void button2_Click(object sender, EventArgs e)
        {
           
            this.Close();

        }
        private void OMClosing(Object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);

        }

        #endregion

       
    }
}

    

