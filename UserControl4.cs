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
    public partial class UserControl4 : UserControl
    {
        public UserControl4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            f.Show();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Name , TotalMarks , TotalWeightage  from Evaluation ", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Evaluation WHERE Name = @Name", con);
                cmd.Parameters.AddWithValue("@Name", value);
                cmd.ExecuteNonQuery();

               
                MessageBox.Show("Successfully Deleted.");


            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                string value1 = dataGridView1.Rows[e.RowIndex].Cells["Name"].Value.ToString();
                string value2 = dataGridView1.Rows[e.RowIndex].Cells["TotalMarks"].Value.ToString();
                string value3 = dataGridView1.Rows[e.RowIndex].Cells["TotalWeightage"].Value.ToString();
                

                Form9 f = new Form9(value1 , value2 , value3);
                // this.Hide();
                f.ShowDialog();
            }
        }
    }
}
