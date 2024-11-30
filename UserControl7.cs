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
    public partial class UserControl7 : UserControl
    {
        public UserControl7()
        {
            InitializeComponent();
        }

        private void comboBox1_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select Id From Advisor", con);
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

        private void comboBox2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("Select Id From Project", con);
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
            
            comboBox2.DataSource = dataList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || comboBox3.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            
            else if(comboBox3.Text != "Main Advisor" && comboBox3.Text != "Co-Advisror" && comboBox3.Text != "Industry Advisor")
            {
                MessageBox.Show("Selected Role is Invalid");
            }
            
            else
            {
                var con = Configuration.getInstance().getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Insert into ProjectAdvisor (AdvisorID, ProjectID, AdvisorRole , AssignmentDate) values (@AdvisorID, @ProjectID, @AdvisorRole , @AssignmentDate)", con);
                cmd.Parameters.AddWithValue("@AdvisorID", comboBox1.Text);
                cmd.Parameters.AddWithValue("@ProjectID", comboBox2.Text);
                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker2.Text);
                
                if(comboBox3.Text == "Main Advisor")
                {
                    cmd.Parameters.AddWithValue("@AdvisorRole", 11);
                }

                else if(comboBox3.Text == "Co-Advisror")
                {
                    cmd.Parameters.AddWithValue("@AdvisorRole", 12);
                }

                else if (comboBox3.Text == "Industry Advisor")
                {
                    cmd.Parameters.AddWithValue("@AdvisorRole", 13);
                }

                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select * from ProjectAdvisor", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string value = dataGridView1.Rows[e.RowIndex].Cells["AdvisorID"].Value.ToString();
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("DELETE FROM ProjectAdvisor WHERE AdvisorID = @AdvisorID", con);
            cmd.Parameters.AddWithValue("@AdvisorID", value);
            cmd.ExecuteNonQuery();


            MessageBox.Show("Successfully Deleted.");
            dataGridView1.DataSource = null;

        }
    }
}
