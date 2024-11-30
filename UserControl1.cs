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
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            this.Hide();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          //  Form3 f = new Form3();
           // this.Hide();
          //  f.ShowDialog();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            // this.Hide();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["RegistrationNo"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Student WHERE RegistrationNo = @RegistrationNo", con);
                cmd.Parameters.AddWithValue("@RegistrationNo", value);
                cmd.ExecuteNonQuery();

                value = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                SqlCommand cmd2 = new SqlCommand("DELETE FROM Person WHERE FirstName = @FirstName", con);
                cmd2.Parameters.AddWithValue("@FirstName", value);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("Successfully Deleted.");

               
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                string value1 = dataGridView1.Rows[e.RowIndex].Cells["RegistrationNo"].Value.ToString();
                string value2 = dataGridView1.Rows[e.RowIndex].Cells["FirstName"].Value.ToString();
                string value3 = dataGridView1.Rows[e.RowIndex].Cells["LastName"].Value.ToString();
                string value4 = dataGridView1.Rows[e.RowIndex].Cells["Contact"].Value.ToString();
                string value5 = dataGridView1.Rows[e.RowIndex].Cells["Email"].Value.ToString();
                string value6 = dataGridView1.Rows[e.RowIndex].Cells["DateOfBirth"].Value.ToString();
                string value7 = dataGridView1.Rows[e.RowIndex].Cells["Gender"].Value.ToString();
                
                Form3 f = new Form3(value1 , value2 , value3 , value4 , value5 , value6 , value7);
                // this.Hide();
                f.ShowDialog();
            }
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select RegistrationNo , FirstName , LastName , Contact , Email , DateOfBirth , Value as Gender from Person , Student , Lookup where Person.ID = Student.ID and person.Gender = Lookup.ID", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            
            DataTable dt = new DataTable();
           
            da.Fill(dt);
           
            dataGridView1.DataSource = dt;
           
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
