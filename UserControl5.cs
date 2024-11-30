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
    public partial class UserControl5 : UserControl
    {
        public UserControl5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Visible = true;
            dateTimePicker1.Visible = true;
            


          
            string value = dateTimePicker1.Text;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd2 = new SqlCommand("Insert into [Group] values (@Created_On)", con);
            cmd2.Parameters.AddWithValue("@Created_On", value);
            cmd2.ExecuteNonQuery();

            MessageBox.Show("Saved Successfully");
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            //dataGridView1.ReadOnly = true;
            
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Created_On from [Group]", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Created_On"].DefaultCellStyle.ForeColor = Color.Black;

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["Created_On"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Group] WHERE Created_On = @Created_On", con);
                cmd.Parameters.AddWithValue("@Created_On", value);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = null;
                MessageBox.Show("Successfully Deleted.");


            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select Id From [Group]", con);
            SqlDataReader reader = cmd.ExecuteReader();
            // Create list to store retrieved data
            List<object> dataList = new List<object>();
            // Loop through reader and add retrieved data to list
            while (reader.Read())
            {
                // Retrieve data from reader
                object data = reader["Id"]; // ider apnay column ka name likha bs
                // Add data to list
                dataList.Add(data);
            }
            // Close reader and connection
            reader.Close();
            
            comboBox1.DataSource = dataList;
        }

        private void UserControl5_Load(object sender, EventArgs e)
        {
            
        }

        private void comboBox2_MouseClick(object sender, MouseEventArgs e)
        {
            
        }

        private void comboBox3_MouseClick(object sender, MouseEventArgs e)
        {

        }

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd2 = new SqlCommand("Select Id From Student", con);
            SqlDataReader reader2 = cmd2.ExecuteReader();
            // Create list to store retrieved data
            List<object> dataList2 = new List<object>();
            // Loop through reader and add retrieved data to list
            while (reader2.Read())
            {
                // Retrieve data from reader
                object data2 = reader2["Id"]; // ider apnay column ka name likha bs
                // Add data to list
                dataList2.Add(data2);
            }
            // Close reader and connection
            reader2.Close();
            
            comboBox2.DataSource = dataList2;
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                
                string value = dataGridView1.Rows[e.RowIndex].Cells["Created_On"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM [Group] WHERE Created_On = @Created_On", con);
                cmd.Parameters.AddWithValue("@Created_On", value);
                cmd.ExecuteNonQuery();

                dataGridView1.DataSource = null;
                MessageBox.Show("Successfully Deleted.");


            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker1.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            
            else if(comboBox3.Text != "Active" && comboBox3.Text != "In Active")
            {
                MessageBox.Show("Selected Status is not valid");
            }
            
            else
            {
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd2 = new SqlCommand("Insert into GroupStudent values (@GroupID , @StudentID , @Status , @AssignmentDate)", con);
                cmd2.Parameters.AddWithValue("@GroupID", comboBox1.Text);
                cmd2.Parameters.AddWithValue("@StudentID", comboBox2.Text);
                
                if(comboBox3.Text == "Active")
                {
                    cmd2.Parameters.AddWithValue("@Status", 3);
                }

                else if(comboBox3.Text == "In Active")
                {
                    cmd2.Parameters.AddWithValue("@Status", 4);
                }
                
                cmd2.Parameters.AddWithValue("@AssignmentDate", dateTimePicker1.Text);

                cmd2.ExecuteNonQuery();


                MessageBox.Show("Saved Successfully");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

                comboBox3.SelectedIndex = -1;
                //dateTimePicker1.SelectedIndex = -1;





            }
        }
    }
}