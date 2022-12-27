using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Cp3_Project
{
    public partial class Dashboard : Form
    {
        Signin f = new Signin();
        MyConnection db = new MyConnection();

        public Dashboard()
        {
            InitializeComponent();
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            this.Close();
         
            Application.OpenForms[0].Show();
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewInventory V1 = new ViewInventory();
             V1.ShowDialog();
            
        }

     private void button4_Click(object sender, EventArgs e)

       {
           OrderManagment AO1 = new OrderManagment();
            
          AO1.ShowDialog();
            

      }

        private void button3_Click(object sender, EventArgs e)
        {
            Order o1 = new Order();
            
            o1.ShowDialog();
            
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            if (MyConnection.type == "A")
            {
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
                button4.Visible = true;
                button6.Visible = true;


            }
            else if (MyConnection.type == "U")
            {
                button1.Enabled = true;
                button2.Text = "N/a";
                button3.Text = "N/a";
                button2.Enabled = false;
                button3.Enabled = false;
                button4.Enabled = true;
                button6.Enabled = false;
                button7.Enabled = false;
                button6.Text = "N/a";
                button7.Text = "N/a";



            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Deactivate de1 = new Deactivate();
            
                de1.ShowDialog();
                
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Remove r1 = new Remove();
            r1.ShowDialog();
             
        }
      


    }
}
