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
    public partial class UserControl6 : UserControl
    {
        public UserControl6()
        {
            InitializeComponent();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_Click(object sender, EventArgs e)
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
           
            comboBox1.DataSource = dataList;
        }

        private void comboBox2_Click(object sender, EventArgs e)
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
            
            comboBox2.DataSource = dataList;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.Text == "" || comboBox2.Text == "" || dateTimePicker2.Text == "")
            {
                MessageBox.Show("Please fill all the fields");
            }
            
            else
            {
                var con = Configuration.getInstance().getConnection();
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("Insert into GroupProject (ProjectId, GroupId, AssignmentDate) values (@ProjectId, @GroupId, @AssignmentDate)", con);
                cmd.Parameters.AddWithValue("@ProjectId", comboBox1.Text);
                cmd.Parameters.AddWithValue("@GroupId", comboBox2.Text);
                cmd.Parameters.AddWithValue("@AssignmentDate", dateTimePicker2.Text);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data Inserted Successfully");
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;

               

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select ProjectID , GroupID , AssignmentDate  from GroupProject", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["ProjectID"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM GroupProject WHERE ProjectID = @ProjectID", con);
                cmd.Parameters.AddWithValue("@ProjectID", value);
                cmd.ExecuteNonQuery();

               
                MessageBox.Show("Successfully Deleted.");
                dataGridView1.DataSource = null;


            }
        }
    }
}
