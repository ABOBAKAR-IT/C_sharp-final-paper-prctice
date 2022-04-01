using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_sharp_final_paper_prctice
{
    public partial class Form1 : Form
    {
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            table.Columns.Add("Name");
            table.Columns.Add("Roll_No");
            table.Columns.Add("Class");
            table.Columns.Add("Gender");
            table.Columns.Add("Skills");
            dataGridView1.DataSource = table;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string rollno = textBox2.Text;
            string cls = textBox3.Text;
            string gender;
            if (radioButton1.Checked == true)
            {
                gender = "male";

            }
            else
            {
                gender = "female";
            }

            string skills = " ";
            if (checkBox1.Checked)
            {
                skills = checkBox1.Text;
            }
            if (checkBox2.Checked)
            {
                skills = skills + " " + checkBox2.Text;
            }
            if (checkBox3.Checked)
            {
                skills = skills + " " + checkBox3.Text;
            }
            MessageBox.Show(skills);


            DataRow row1 = table.NewRow();
            row1["Name"]= name;
            row1["Roll_No"] = rollno;
            row1["Class"] = cls;
            row1["Gender"] = gender;
            row1["Skills"] = skills;

            table.Rows.Add(row1);
            dataGridView1.Refresh();

        }
    }
}
