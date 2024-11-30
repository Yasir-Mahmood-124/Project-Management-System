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
    public partial class UserControl2 : UserControl
    {
        public UserControl2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["Salary"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Advisor WHERE Salary = @Salary", con);
                cmd.Parameters.AddWithValue("@Salary", value);
                cmd.ExecuteNonQuery();
                
                value = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                SqlCommand cmd2 = new SqlCommand("DELETE FROM Person WHERE FirstName = @FirstName", con);
                cmd2.Parameters.AddWithValue("@FirstName", value);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted.");

            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                
                string value1 = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string value2 = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string value3 = dataGridView1.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                string value4 = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string value5 = dataGridView1.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
                string value6 = dataGridView1.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                string value7 = dataGridView1.Rows[e.RowIndex].Cells["Designation"].Value.ToString();
                string value8 = dataGridView1.Rows[e.RowIndex].Cells["Salary"].Value.ToString();
                Form5 f = new Form5(value1 , value2 , value3 , value4 , value5 , value6 , value7 , value8);
                f.ShowDialog();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
           // SqlCommand cmd1 = new SqlCommand("Select from (Select  FirstName,LastName, Contact, Email, DateofBirth, Value as Gender from Person Inner Join Lookup on Person.Gender = Lookup.Id))");
            SqlCommand cmd = new SqlCommand("Select FirstName , LastName , Contact , Email , DateOfBirth , Value as Gender , Value as Designation , Salary from Person , Advisor , Lookup where Person.ID = Advisor.ID and person.Gender = Lookup.ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
