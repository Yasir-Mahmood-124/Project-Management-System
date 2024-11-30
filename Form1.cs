using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mid_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
          //  label1.Text = "Manage Students";
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // label1.Text = "Manage Advisors";
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // label1.Text = "Manage Projects";
        }

        private void button4_Click(object sender, EventArgs e)
        {
           // label1.Text = "Manage Student Group";
        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  label1.Text = "Assignment of Projects";
        }

        private void button6_Click(object sender, EventArgs e)
        {
           // label1.Text = "Manage Evaluation";
        }

        private void button7_Click(object sender, EventArgs e)
        {
           // label1.Text = "Mark the Evaluation";
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            label1.Text = "Manage Students";
            pictureBox1.Visible = false;
            userControl11.Visible = true;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Manage Advisors";
            userControl11.Visible = false;
            userControl21.Visible = true;
            pictureBox1.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Manage Projects";
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = true;
            pictureBox1.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;

        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Group of Students";
            userControl11.Visible = false;
            userControl21.Visible = false;
            pictureBox1.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = true;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Assignment of Projects";
            userControl11.Visible = false;
            userControl21.Visible = false;
            pictureBox1.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = true;
            userControl71.Visible = false;
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Manage Evaluation";
            userControl11.Visible = false;
            userControl21.Visible = false;
            pictureBox1.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = true;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            label1.Text = "Mark the Evaluation";
            userControl11.Visible = false;
            userControl21.Visible = false;
            pictureBox1.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            label1.Text = "Dash Board";
            userControl11.Visible = false;
            userControl21.Visible = false;
            pictureBox1.Visible = true;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void userControl11_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = false;
        }

        private void userControl31_Load(object sender, EventArgs e)
        {

        }

        private void userControl41_Load(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {
            label1.Text = "Assignment of Advisors";
            pictureBox1.Visible = false;
            userControl11.Visible = false;
            userControl21.Visible = false;
            userControl31.Visible = false;
            userControl41.Visible = false;
            userControl51.Visible = false;
            userControl61.Visible = false;
            userControl71.Visible = true;
        }
    }
}
