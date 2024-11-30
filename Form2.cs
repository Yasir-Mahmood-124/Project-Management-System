using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("Please fill all the fields.");
            }
            
            else
            {
                int id;
               
               var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("Insert into Person values(@FirstName , @LastName , @Contact , @Email , @DateOfBirth , @Gender)", con);
                cmd.Parameters.AddWithValue("@Firstname", textBox2.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox3.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox4.Text);
                cmd.Parameters.AddWithValue("@Email", textBox5.Text);
                cmd.Parameters.AddWithValue("@DateOfBirth", textBox6.Text);

                if (comboBox1.Text == "Male")
                {
                    cmd.Parameters.AddWithValue("@Gender", 1);
                }

                else
                {
                    cmd.Parameters.AddWithValue("@Gender", 2);
                }

			     cmd.ExecuteNonQuery();

                SqlCommand cmd3 = new SqlCommand("Select MAX(ID) from Person", con);
                object result = cmd3.ExecuteScalar();
                id = int.Parse(result.ToString());
               


                SqlCommand cmd2 = new SqlCommand("Insert into Student values (@ID , @RegistrationNo)", con);
                cmd2.Parameters.AddWithValue("@ID", id);
                cmd2.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);

                cmd2.ExecuteNonQuery();
               
                
                MessageBox.Show("Saved Successfully");
                this.Hide();
            }
        }
    }
}
