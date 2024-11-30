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

namespace Mid_Project
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }

            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Insert into Evaluation values (@Name , @TotalMarks , @TotalWeightage)", con);
                cmd2.Parameters.AddWithValue("@Name", textBox1.Text);
                cmd2.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox2.Text));
                cmd2.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox2.Text));

                cmd2.ExecuteNonQuery();


                MessageBox.Show("Saved Successfully");
                this.Hide();
            }
        }
    }
}
