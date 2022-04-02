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
using Microsoft.Reporting.WinForms;

namespace C_sharp_final_paper_prctice
{
    public partial class Form2 : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string roll;
        public Form2(string roll)
        {
            this.roll = roll;
            InitializeComponent();
            show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void show()
        {
            string str_connection = @"Data Source=RANA-ABOBAKAR\SQLEXPRESS;Initial Catalog=students;Integrated Security=true";
            connection = new SqlConnection(str_connection);
            connection.Open();
            string sql = $"select Name,Roll_No,Cls,Gender,Skills from std_table  full join skills on Roll_No=Roll where Roll_No='{roll}'";
            command = new SqlCommand(sql, connection);
            SqlDataAdapter dataReader = new SqlDataAdapter(sql, connection);
            DataSet1 ds = new DataSet1();
            dataReader.Fill(ds, "DataTable1");
            //  this.connection.Open();
            ReportDataSource dataSource = new ReportDataSource("DataSet_report", ds.Tables[0]);

            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(dataSource);
            this.reportViewer1.RefreshReport();
        }
    }
}
