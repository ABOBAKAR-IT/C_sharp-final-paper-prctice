using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace C_sharp_final_paper_prctice
{
    public partial class Form1 : Form
    {
        SqlConnection connection;
        SqlCommand command;
      
        string db_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
        DataTable table = new DataTable();

        public Form1()
        {
            InitializeComponent();
            this.connection = new SqlConnection(db_connection);
            table.Columns.Add("Name");
            table.Columns.Add("Roll_No");
            table.Columns.Add("Class");
            table.Columns.Add("Gender");
            table.Columns.Add("Skills");
            dataGridView1.DataSource = table;
            read_data_from_database();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }

        private void Button1_Click(object sender, EventArgs e)    //**** Add Button Code ****
        {
            write_data_in_database();
            table.Rows.Clear();
            read_data_from_database();

        }

        private void Button2_Click(object sender, EventArgs e) //*** update button code ***
        {
            update_data_in_database();
            table.Rows.Clear();
            read_data_from_database();

        }

        private void Button3_Click(object sender, EventArgs e) //*** delete button code
        {
            delete_data_in_database();
            skills_delete(textBox2.Text);
            table.Rows.Clear();
            read_data_from_database();
        }


        private void write_data_in_database()
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


            // MessageBox.Show(skills);

            try
            {
                string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
                connection = new SqlConnection(str_connection);
                connection.Open();
                string sql = $"INSERT INTO std_table (Name,Roll_No,Cls,Gender) values ('{name}','{rollno}','{cls}','{gender}')";
                command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record add");

                connection.Close();
                string skills = " ";
                if (checkBox1.Checked)
                {
                    skills_add(checkBox1.Text, textBox2.Text);
                }
                if (checkBox2.Checked)
                {
                    skills_add(checkBox2.Text, textBox2.Text);
                }
                if (checkBox3.Checked)
                {
                    skills_add(checkBox3.Text, textBox2.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

        }
        private void skills_add(string skills, string rollno)
        {
            try
            {

                string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
                connection = new SqlConnection(str_connection);
                connection.Open();
                string sql = $"insert into skills(skills,roll) values ('{skills}','{rollno}')";
                command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record add");

                connection.Close();
            }
            catch(Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }
        private void skills_delete(string rollno)
        {
            try
            {

                string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
                connection = new SqlConnection(str_connection);
                connection.Open();
                string sql = $"delete skills where roll='{rollno}'";
                command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record add");

                connection.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }



        private void read_data_from_database()
        {

            string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
            connection = new SqlConnection(str_connection);
            connection.Open();
            string sql = $"select * from std_table  full join skills on Roll_No=roll";
            command = new SqlCommand(sql, connection);
            SqlDataReader dataReader;
            dataReader= command.ExecuteReader();
            while (dataReader.Read())
            {
                DataRow row = this.table.NewRow();
                row["Name"] = dataReader.GetValue(0);
                row["Roll_No"] = dataReader.GetValue(1);
                row["Class"] = dataReader.GetValue(2);
                row["Gender"] = dataReader.GetValue(3);
                row["Skills"] = dataReader.GetValue(5);

                this.table.Rows.Add(row);
            }
            dataGridView1.Refresh();
            connection.Close();
        }
        private void update_data_in_database()
        {
            try
            {
                string gender;
                if (radioButton1.Checked == true)
                {
                    gender = "male";

                }
                else
                {
                    gender = "female";
                }
                string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
                connection = new SqlConnection(str_connection);
                connection.Open();
                string sql = $"update std_table set Name='{textBox1.Text}',Roll_No='{textBox2.Text}',Cls='{textBox3.Text}',Gender='{gender}' where Roll_No='{textBox2.Text}' ";
                command = new SqlCommand(sql, connection);
                SqlDataAdapter adapter = new SqlDataAdapter();
                adapter.InsertCommand = command;
                MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record add");

                connection.Close();
                string skills = " ";
                skills_delete(textBox2.Text);
                if (checkBox1.Checked)
                {
                    skills_add(checkBox1.Text, textBox2.Text);
                }
                if (checkBox2.Checked)
                {
                    skills_add(checkBox2.Text, textBox2.Text);
                }
                if (checkBox3.Checked)
                {
                    skills_add(checkBox3.Text, textBox2.Text);
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);

            }
        }
        private void delete_data_in_database()
        {
            string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
            connection = new SqlConnection(str_connection);
            connection.Open();
            string sql = $"DELETE std_table where Roll_No='{textBox2.Text}' ";
            command = new SqlCommand(sql, connection);
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.InsertCommand = command;
            MessageBox.Show(adapter.InsertCommand.ExecuteNonQuery().ToString() + "  Record Delete");

            connection.Close();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                table.Rows.Clear();

                read_data_from_database();
            }
            else
            {
                table.Rows.Clear();
                string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
                connection = new SqlConnection(str_connection);
                connection.Open();
                string sql = $"select * from std_table  full join skills on Roll_No=Roll where Roll_No='{textBox2.Text}'";
                command = new SqlCommand(sql, connection);
                SqlDataReader dataReader;
                dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    DataRow row = this.table.NewRow();
                    row["Name"] = dataReader.GetValue(0);
                    row["Roll_No"] = dataReader.GetValue(1);
                    row["Class"] = dataReader.GetValue(2);
                    row["Gender"] = dataReader.GetValue(3);
                    row["Skills"] = dataReader.GetValue(5);

                    this.table.Rows.Add(row);
                }
                dataGridView1.Refresh();
                connection.Close();
            }
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Enter a Roll No");
            }
            else{

                Form2 frm = new Form2(textBox2.Text);
                frm.Show();
                this.Hide();



            }


        }
    }
}
