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
    public partial class Form5 : Form
    {
        public static string global1, global2 , id;
        public Form5(string value1 , string value2 , string value3 , string value4 , string value5 , string value6 , string value7 , string value8)
        {
            InitializeComponent();
            textBox2.Text = value1;
            textBox3.Text = value2;
            textBox4.Text = value3;
            textBox5.Text = value4;
            textBox6.Text = value5;
            comboBox1.Text = value6;
            comboBox2.Text = value7;
            textBox7.Text = value8;

            global1 = value6;
            global2 = value7;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from Person where FirstName = @FirstName", con);
            cmd3.Parameters.AddWithValue("@FirstName", value1);
            object result = cmd3.ExecuteScalar();
            id = result.ToString();

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Designation = global2;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Advisor SET  Designation = @Designation , Salary = @Salary WHERE id = @id", con);
            
            
            if(comboBox2.Text == "Professor")
            {
                cmd.Parameters.AddWithValue("@Designation", 6);
            }

            else if(comboBox2.Text == "Associate Professor")
            {
                cmd.Parameters.AddWithValue("@Designation", 7);
            }

            else if(comboBox2.Text == "Assisstant Professor")
            {
                cmd.Parameters.AddWithValue("@Designation", 8);
            }

            else if(comboBox2.Text == "Lecturer")
            {
                cmd.Parameters.AddWithValue("@Designation", 9);
            }
            
            else
            {
                cmd.Parameters.AddWithValue("@Designation", 10);
            }
            cmd.Parameters.AddWithValue("@Salary", textBox7.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            
            string Gender = global1;
            SqlCommand cmd1 = new SqlCommand("UPDATE Person SET  FirstName = @FirstName , LastName = @LastName , Contact = @Contact , Email = @Email , DateOfBirth = @DateOfBirth , Gender = @Gender  WHERE id = @id", con);
            cmd1.Parameters.AddWithValue("@FirstName", textBox2.Text);
            cmd1.Parameters.AddWithValue("@LastName", textBox3.Text);
            cmd1.Parameters.AddWithValue("@Contact", textBox4.Text);
            cmd1.Parameters.AddWithValue("@Email", textBox5.Text);
            cmd1.Parameters.AddWithValue("@DateOfBirth", textBox6.Text);
            cmd1.Parameters.AddWithValue("@id", id);

            if (comboBox1.Text == "Male")
            {
                cmd1.Parameters.AddWithValue("@Gender", 1);

            }

            else
            {
                cmd1.Parameters.AddWithValue("@Gender", 2);
            }

            cmd1.ExecuteNonQuery();

            MessageBox.Show("Editted Successfully");
            this.Hide();
        }
    }
}
