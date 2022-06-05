using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1labaa1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Rows.Clear();
         
           
            ServiceReference1.WebService1SoapClient ms = new ServiceReference1.WebService1SoapClient();
            string Id = "", Name = "", Amount = "", Price = "", Description = "";
            if (textBox1 != null) { Id = textBox1.Text; };
            if (textBox2 != null) { Name = textBox2.Text; };
            if (textBox3 != null) { Amount = textBox3.Text; };
            if (textBox4 != null) { Price = textBox4.Text; };
            if (textBox5 != null) { Description = textBox5.Text; };
            List <string> cl = new List<string>();

            cl = ms.GetListOfClothes(Id, Name, Amount, Price, Description);
 
        
          foreach (string s in cl)
           {
               
               dataGridView1.Rows.Add(s);
            }
          
      
              dataGridView1.Columns[0].Width = 500; 
          

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ms = new ServiceReference1.WebService1SoapClient();
            string Id = "", Name = "", Amount = "", Price = "", Description = "";
            if (textBox1 != null) { Id = textBox1.Text; };
            if (textBox2 != null) { Name = textBox2.Text; };
            if (textBox3 != null) { Amount = textBox3.Text; };
            if (textBox4 != null) { Price = textBox4.Text; };
            if (textBox5 != null) { Description = textBox5.Text; };

            int cl = ms.AddListOfClothes(Id, Name, Amount, Price, Description);
           if (cl == 0) MessageBox.Show(" Успешно!");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ms = new ServiceReference1.WebService1SoapClient();
            string Id = "", Name = "", Amount = "", Price = "", Description = "";
            if (textBox1 != null) { Id = textBox1.Text; };
            if (textBox2 != null) { Name = textBox2.Text; };
            if (textBox3 != null) { Amount = textBox3.Text; };
            if (textBox4 != null) { Price = textBox4.Text; };
            if (textBox5 != null) { Description = textBox5.Text; };

            int cl = ms.DeleteListOfClothes(Id, Name, Amount, Price, Description);
            if (cl == 0) MessageBox.Show(" Успешно!");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            ServiceReference1.WebService1SoapClient ms = new ServiceReference1.WebService1SoapClient();
            string Id = "", Name = "", Amount = "", Price = "", Description = "";
            if (textBox1 != null) { Id = textBox1.Text; };
            if (textBox2 != null) { Name = textBox2.Text; };
            if (textBox3 != null) { Amount = textBox3.Text; };
            if (textBox4 != null) { Price = textBox4.Text; };
            if (textBox5 != null) { Description = textBox5.Text; };

            int cl = ms.EditListOfClothes(Id, Name, Amount, Price, Description);
          if (cl==0)  MessageBox.Show(" Успешно!");
        }

       
    }
}
