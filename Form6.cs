using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Mid_Project
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form6_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox5.Text == "" || textBox6.Text == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }

            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Insert into Project values (@Description , @title)", con);
                cmd2.Parameters.AddWithValue("@Description", textBox5.Text);
                cmd2.Parameters.AddWithValue("@title", textBox6.Text);

                cmd2.ExecuteNonQuery();


                MessageBox.Show("Saved Successfully");
                this.Hide();
            }
        }
    }
}
