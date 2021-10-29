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
namespace Project_2
{
    public partial class Form5 : Form
    {
        SqlConnection cnn = new SqlConnection();
        SqlDataReader myreader;
        SqlConnectionStringBuilder s = new SqlConnectionStringBuilder(
            "Data Source = DESKTOP-1LBIJ12\\DB2018980093; Initial Catalog = Hospital;Integrated Security=True;Pooling=False");
        public Form5()
        {
            InitializeComponent();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            String strsql = "";
            cnn.ConnectionString = s.ConnectionString;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();




            if (Form1.table == 1)
            {

                dataGridView1.Columns.Add("ssn", "Ssn");
                dataGridView1.Columns.Add("fname", "First name");
                dataGridView1.Columns.Add("mname", "Middle name");
                dataGridView1.Columns.Add("lname", "Last name");
                dataGridView1.Columns.Add("bdate", "BDATE");
                dataGridView1.Columns.Add("sex", "Sex");
                strsql = "Select * From Patient ";
                SqlCommand cmd = new SqlCommand(strsql, cnn);
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    dataGridView1.Rows.Add(myreader["PatientId"].ToString(),
                    myreader["Fname"].ToString(),
                    myreader["Mname"].ToString(),
                    myreader["Lname"].ToString(),
                    myreader["Bdate"].ToString(),
                    myreader["Sex"].ToString()
                    );
                }

            }
            else if (Form1.table == 2)
            {
                dataGridView1.Columns.Add("MNO", "MNO");
                dataGridView1.Columns.Add("Name", "Name");
                dataGridView1.Columns.Add("Price", "Price");

                strsql = "Select * From Medicine ";
                SqlCommand cmd = new SqlCommand(strsql, cnn);
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    dataGridView1.Rows.Add(myreader["MNO"].ToString(),
                    myreader["Name"].ToString(),
                    myreader["Price"].ToString()
                    );
                }
            }
            else
            {
                dataGridView1.Columns.Add("PatientId", "PatientId");
                dataGridView1.Columns.Add("MNO", "MNO");
                dataGridView1.Columns.Add("VisitDate", "VisitDate");

                strsql = "Select * From Patient_Medicine ";
                SqlCommand cmd = new SqlCommand(strsql, cnn);
                myreader = cmd.ExecuteReader();
                while (myreader.Read())
                {
                    dataGridView1.Rows.Add(myreader["PatientId"].ToString(),
                    myreader["MNO"].ToString(),
                    myreader["VisitDate"].ToString());
                }
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }



        }
    }
}
