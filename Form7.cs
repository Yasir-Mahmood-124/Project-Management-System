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
    public partial class Form7 : Form
    {
        public static string global;
        public static int id;
        public Form7(string value1 , string value2)
        {
            InitializeComponent();
            textBox5.Text = value1;
            textBox6.Text = value2;

            global = value1;

            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd3 = new SqlCommand("Select ID from Project where Description = @Description", con);
            cmd3.Parameters.AddWithValue("@Description", value1);
            object result = cmd3.ExecuteScalar();
            id = int.Parse(result.ToString());
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // string Gender = global1;
            var con = Configuration.getInstance().getConnection();
            SqlCommand cmd1 = new SqlCommand("UPDATE Project SET  Description = @Description , Title = @Title   WHERE id = @id", con);
            cmd1.Parameters.AddWithValue("@Description", textBox5.Text);
            cmd1.Parameters.AddWithValue("@Title", textBox6.Text);
            cmd1.Parameters.AddWithValue("@id", id);


            cmd1.ExecuteNonQuery();

            MessageBox.Show("Editted Successfully");
            this.Hide();
        }
    }
}
