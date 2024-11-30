using CRUD_Operations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Project
{
    public partial class UserControl3 : UserControl
    {
        public UserControl3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            f.ShowDialog();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Columns[e.ColumnIndex].Name == "Delete")
            {
                string value = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                var con = Configuration.getInstance().getConnection();
                SqlCommand cmd = new SqlCommand("DELETE FROM Project WHERE Description = @Description", con);
                cmd.Parameters.AddWithValue("@Description", value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Successfully Deleted.");
            }

            else if (dataGridView1.Columns[e.ColumnIndex].Name == "Edit")
            {
                string value1 = dataGridView1.Rows[e.RowIndex].Cells["Description"].Value.ToString();
                string value2 = dataGridView1.Rows[e.RowIndex].Cells["Title"].Value.ToString();
                Form7 f = new Form7(value1 , value2);
                f.ShowDialog();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = true;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd = new SqlCommand("Select Description , Title from project", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);

            DataTable dt = new DataTable();

            da.Fill(dt);

            dataGridView1.DataSource = dt;
        }
    }
}
