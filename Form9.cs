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
    public partial class Form9 : Form
    {
        public static int id;
        public Form9(string value1 , string value2 , string value3)
        {
            InitializeComponent();
            textBox1.Text = value1;
            textBox2.Text = value2;
            textBox3.Text = value3;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from Evaluation where Name = @Name", con);
            cmd3.Parameters.AddWithValue("@Name", value1);
            object result = cmd3.ExecuteScalar();
            id = int.Parse(result.ToString());
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            WindowState= FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("UPDATE Evaluation SET  Name = @Name , TotalMarks = @TotalMarks , TotalWeightage = @TotalWeightage   WHERE id = @id", con);
            cmd1.Parameters.AddWithValue("@Name", textBox1.Text);
            cmd1.Parameters.AddWithValue("@TotalMarks", int.Parse(textBox2.Text));
            cmd1.Parameters.AddWithValue("@TotalWeightage", int.Parse(textBox3.Text));
            cmd1.Parameters.AddWithValue("@id", id);


            cmd1.ExecuteNonQuery();

            MessageBox.Show("Editted Successfully");
            this.Hide();
        }
    }
}
