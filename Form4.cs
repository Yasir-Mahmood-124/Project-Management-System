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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || comboBox1.Text == "" || comboBox2.Text == "")
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

                SqlCommand cmd2 = new SqlCommand("Insert into Advisor values (@ID , @Designation , @Salary)", con);
                cmd2.Parameters.AddWithValue("@ID", id);
                
                if(comboBox2.Text == "Professor")
                {
                    cmd2.Parameters.AddWithValue("@Designation", 6);
                }
                
                else if(comboBox2.Text == "Associate Professor")
                {
                    cmd2.Parameters.AddWithValue("@Designation", 7);
                }
                
                else if(comboBox2.Text == "Assisstant Professor")
                {
                    cmd2.Parameters.AddWithValue("@Designation", 8);
                }
                
                else if(comboBox2.Text == "Lecturer")
                {
                    cmd2.Parameters.AddWithValue("@Designation", 9);
                }
                
                else if(comboBox2.Text == "Industry Professional")
                {
                    cmd2.Parameters.AddWithValue("@Designation", 10);
                }
                
                cmd2.Parameters.AddWithValue("@Salary", textBox7.Text);

                cmd2.ExecuteNonQuery();


                MessageBox.Show("Saved Successfully");
                this.Hide();
            }
        }
    }
}
