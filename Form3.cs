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
    public partial class Form3 : Form
    {
        public static string global1, global2;
        public static int id;
        public Form3(string value1 , string value2 , string value3 , string value4 , string value5 , string value6 , string value7)
        {
            InitializeComponent();
            textBox1.Text = value1;
            textBox2.Text = value2;
            textBox3.Text = value3;
            textBox4.Text = value4;
            textBox5.Text = value5;
            textBox6.Text = value6;
            comboBox1.Text = value7;


            global1 = value1;
            global2 = value7;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from Student where RegistrationNo = @RegistrationNo", con);
            cmd3.Parameters.AddWithValue("@RegistrationNo", value1);
            object result = cmd3.ExecuteScalar();
            id = int.Parse(result.ToString());


        }

        private void button2_Click(object sender, EventArgs e)
        {
            string RegistrationNo = global1;
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("UPDATE Student SET  RegistrationNo = @RegistrationNo WHERE id = @id", con);
            cmd.Parameters.AddWithValue("@RegistrationNo", textBox1.Text);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            string Gender = global2;
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

        private void Form3_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }
    }
}
