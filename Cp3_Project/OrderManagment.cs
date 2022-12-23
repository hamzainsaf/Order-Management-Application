using System;
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

        MyConnection db = new MyConnection();
        public OrderManagment()
        {
            InitializeComponent();
            FILLDGV();
            table.Columns.Add("Name");
            table.Columns.Add("Unit Price");
            table.Columns.Add("Price");
            table.Columns.Add("Quantity");
            table.Columns.Add("Date");
            table.Columns.Add("Total");
        }
        
        #region
        // Visulaising the Data
        private void FILLDGV()
        {
            db.con.Open();
            string query = "Select * From Inventory1";
            SqlDataAdapter da = new SqlDataAdapter(query, db.con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var dt = new DataSet();
            da.Fill(dt);
            dataGridView1.DataSource = dt.Tables[0];
            db.con.Close();



        }
        #endregion


        int qty;
        int flag = 0;
        int total;
        int sum = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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


                    table.Rows.Add(proName.Text, pri_ce.Text, Tot.Text, numericUpDown1.Value.ToString(), DateTime.Today.ToString("ddMMyyyy"));
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
                FILLDGV();
            }
        }
        void savorder()
        {
            db.con.Open();
            SqlCommand cmd = new SqlCommand("addorders", db.con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.Date);
            cmd.Parameters.AddWithValue("@username", id.Trim());
            cmd.Parameters.AddWithValue("@totalprice", Tot.Text.Trim());


            cmd.ExecuteNonQuery();
            MessageBox.Show("Order Added");
            db.con.Close();
            DataRow row = table.NewRow();
            row["Total"] = sum;
            table.Rows.Add(row);
            save_csv();

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            savorder();
        }


        void save_csv()
        {
            string ordername = id.Trim() + DateTime.Now.ToString("yyyyMMdd_HHmmss");
            string filePath = "C:\\Users\\48512\\source\\repos\\Cp3_Project\\Cp3_Project\\Orders\\" + ordername + ".csv";
            using (StreamWriter writer = File.CreateText(filePath))
            
            {
               
                foreach (DataColumn column in table.Columns)
                {
                    writer.Write(column.ColumnName + ",");
                }
                writer.WriteLine();

                // Write the data rows to the file
                foreach (DataRow row in table.Rows)
                {
                    foreach (var value in row.ItemArray)
                    {
                        writer.Write(value + ",");
                    }
                    writer.WriteLine();
                }

                // Close the StreamWriter object and save the data
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

    

