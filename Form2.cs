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
using Tulpep.NotificationWindow;

namespace Project_2
{
    
    public partial class Form2 : Form
    {
        SqlConnection cnn = new SqlConnection();
        SqlDataReader myreader;
        SqlConnectionStringBuilder s = new SqlConnectionStringBuilder(
            "Data Source = DESKTOP-1LBIJ12\\DB2018980093; Initial Catalog = Hospital;Integrated Security=True;Pooling=False");
        List<String> arr = new List<string>();
        List<String> arr2 = new List<string>();

        private static string Sex;
        private void insert(List<String> arr,String table)
        {
            
            cnn.ConnectionString = s.ConnectionString;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            
            String strsql = "insert into " + table + " values (";
            String values = "";
            foreach (String s in arr)
            {
                values += s;
            }
            values += ");";
            strsql += values;
            SqlCommand cmd = new SqlCommand(strsql, cnn);
            int r = cmd.ExecuteNonQuery();
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            notification("insert");
        }
        private void notification(string s)
        {
            PopupNotifier popup = new PopupNotifier();
            popup.Image = Properties.Resources.business_application_addthedatabase_add_insert_database_db_2313__1_;
            popup.TitleText = s;
            popup.ContentText = "DONE___(^_^)";
            popup.Popup();
        }

        public Form2()
        {
            InitializeComponent();

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            switchScreen(Form1.table, Form1.col);


        }
        private void switchScreen(int screen,string operation)
        {
            if (operation == "show")
            {
                panel3.Visible = true;
            }
            if (operation == "insert")
            {
                panel2.Visible = false;
                button1.Visible = false;
                button2.Visible = false;
                INSERT.Visible = true;

            }
            else if(operation=="UpDate"){
                button2.Visible = false;
                INSERT.Visible = false;
                panel2.Visible = true;
                button1.Visible=true;
                PNO.Enabled = false;
                pictureBox1.Image = Properties.Resources.update;
            }
            else 
            {
                button2.Visible = true;
                INSERT.Visible = false;
                panel2.Visible = true;
                button1.Visible = false;
            }
            if (screen == 2)
            {
                metroLabel1.Text = "MNO";
                metroLabel2.Text = "NAME";
                metroLabel3.Text = "PRICE";
                metroLabel4.Visible = false;
                metroLabel5.Visible = false;
                metroLabel6.Visible = false;
                LNAME.Visible = false;
                BDATE.Visible = false;
                BDATE.Visible = false;
                panel1.Visible = false;
                textBox5.PlaceholderText = "ex : 101";
                metroLabel7.Text = "Please search for MNO :";
            }
            else if (screen == 3)
            {
                if (operation == "UpDate")
                    FNAME.Enabled = false;
                metroLabel2.Text = "MNO";
                metroLabel3.Text = "VisitDate";
                metroLabel4.Visible = false;
                metroLabel5.Visible = false;
                metroLabel6.Visible = false;
                LNAME.Visible = false;
                BDATE.Visible = false;
                BDATE.Visible = false;
                panel1.Visible = false;
            }
            if (screen == 1 && operation == "insert")
            {
                
                label1.Text = "This Table Is [Patient] The Operation Is Insert";
                
            }
            else if (screen== 1 && operation == "UpDate")
            {
                
                label1.Text = "This Table Is [Patient] The Operation Is UpDate";
            }
            else if (screen == 2 && operation == "UpDate")
            {
                
                label1.Text = "This Table Is [Medicin] The Operation Is UpDate";
            }
            else if (screen == 2 && operation == "insert")
            {
                label1.Text = "This Table Is [Medicin] The Operation Is insert";
            }else if (screen == 3 && operation == "insert")
            {
                label1.Text = "This Table Is [Patient_Medicine] The Operation Is insert";
            }
            else if (screen == 3 && operation == "UpDate")
            {
                label1.Text = "This Table Is [Patient_Medicine] The Operation Is UpDate";
            }else if (screen == 1 && operation == "Delete")
            {
                label1.Text = "This Table Is [Patient] The Operation Is Delete";
            }else if(screen==2&& operation == "Delete")
            {
                label1.Text = "This Table Is [Medicin] The Operation Is Delete";
            }
            else if (screen == 3 && operation == "insert")
            {
                label1.Text = "This Table Is [Patient_Medicine] The Operation Is insert";
            }
            else if (screen == 3 && operation == "Delete")
            {
                label1.Text = "This Table Is [Patient_Medicine] The Operation Is Delete";
            }
        }
      

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        
        private void Search(int table)
        {
            if (table == 1)
                SearchPID();
            else if (table == 2)
                SearchMNO();
            else SearchpIdExtra();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            insertTable(Form1.table);
          
        }
        

        private void timer1_Tick(object sender, EventArgs e)
        {
          
            
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Search(Form1.table);
        }
        private void insertTable(int t)
        {
            arr.Clear();
            if (t == 1)//patient
            {
                if (metroRadioButton1.Checked == true) Sex = "F"; else Sex = "M";
                arr.Add("" + PNO.Text + ",");
                arr.Add("'" + FNAME.Text + "'" + ",");
                arr.Add("'" + MNAME.Text + "'" + ",");
                arr.Add("'" + LNAME.Text + "'" + ",");
                arr.Add("'" + Sex + "'" + ",");
                arr.Add("'" + BDATE.Text + "'");
                insert(arr, "patient");
            }else if (t == 2)//medicine
            {
                arr.Add("" + PNO.Text + ",");
                arr.Add("'" + FNAME.Text + "'" + ",");
                arr.Add("" + float.Parse( MNAME.Text) + "" );
                insert(arr, "Medicine");
            }else if (t == 3)//patient_medicine
            {
                
                cnn.ConnectionString = s.ConnectionString;
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                string strsql = "SELECT PatientID FROM Patient WHERE PatientID  = " + PNO.Text;

                SqlCommand cmd = new SqlCommand(strsql, cnn);

                object result = cmd.ExecuteScalar();


                if (result != null)
                {
                    
                }
                else
                {
                    MessageBox.Show("There is no Patient with this PatientID in the table\n Please enter another PatientID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                string strsqls = "SELECT MNO  FROM Medicine WHERE MNO = " + FNAME.Text;

                SqlCommand cmds = new SqlCommand(strsqls, cnn);

                object results = cmds.ExecuteScalar();


                if (results != null)
                {
                   
                    

                }
                else
                {
                    MessageBox.Show("There is no Medicine with this MNO in the table\n Please enter another MNO", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
                if (result != null && results != null)
                {
                    arr.Add("" + PNO.Text + ",");
                    arr.Add("" + FNAME.Text + "" + ",");
                    arr.Add("'" + MNAME.Text+ "'");
                    insert(arr, "Patient_Medicine");
                }

                
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SearchPID()
        {
            cnn.ConnectionString = s.ConnectionString;

            if (textBox5.Text.Length == 4)
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                string strsql = "SELECT PatientID , Fname , Mname , Lname , Sex , Bdate FROM Patient WHERE PatientID  = " + textBox5.Text;

                SqlCommand cmd = new SqlCommand(strsql, cnn);

                object result = cmd.ExecuteScalar();


                if (result != null)
                {
                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    PNO.Text = myreader["PatientID"].ToString();
                    FNAME.Text = myreader["Fname"].ToString();
                    MNAME.Text = myreader["Mname"].ToString();
                    LNAME.Text = myreader["Lname"].ToString();
                    if (myreader["Sex"].ToString() == "F") metroRadioButton1.Checked = true; else metroRadioButton2.Checked = true;
                    BDATE.Text = myreader["Bdate"].ToString();
                    BDATE.Text = BDATE.Text.Substring(0, BDATE.Text.IndexOf(' ') + 1);



                }
                else
                {
                    MessageBox.Show("There is no Patient with this PatientID in the table\n Please enter another PatientID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid PatientID that consists exactly of 4 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchMNO()
        {
            cnn.ConnectionString = s.ConnectionString;

            if (textBox5.Text.Length == 3)
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                string strsql = "SELECT MNO , Name , Price FROM Medicine WHERE MNO = " + textBox5.Text;

                SqlCommand cmd = new SqlCommand(strsql, cnn);

                object result = cmd.ExecuteScalar();


                if (result != null)
                {
                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    PNO.Text = myreader["MNO"].ToString();
                    FNAME.Text = myreader["NAME"].ToString();
                    MNAME.Text = myreader["PRICE"].ToString();

                }
                else
                {
                    MessageBox.Show("There is no Medicine with this MNO in the table\n Please enter another MNO", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid MNO that consists exactly of 3 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void SearchpIdExtra() {


            cnn.ConnectionString = s.ConnectionString;

            if (textBox5.Text.Length == 4)
            {
                if (cnn.State == ConnectionState.Closed)
                    cnn.Open();

                string strsql = "SELECT PatientID ,MNO ,VisitDate FROM Patient_Medicine WHERE PatientID  = " + textBox5.Text;

                SqlCommand cmd = new SqlCommand(strsql, cnn);

                object result = cmd.ExecuteScalar();


                if (result != null)
                {
                    myreader = cmd.ExecuteReader();
                    myreader.Read();

                    PNO.Text = myreader["PatientID"].ToString();
                    FNAME.Text = myreader["MNO"].ToString();
                    MNAME.Text = myreader["VisitDate"].ToString();
                    MNAME.Text = MNAME.Text.Substring(0, MNAME.Text.IndexOf(' ') + 1);
                }
                else
                {
                    MessageBox.Show("There is no Patient with this PatientID in the table\n Please enter another PatientID", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                if (cnn.State == ConnectionState.Open)
                    cnn.Close();
            }
            else
            {
                MessageBox.Show("Please enter valid PatientID that consists exactly of 4 numbers", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void update(String table, List<String> arr2,  String pno, String p)
        {
            cnn.ConnectionString = s.ConnectionString;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            String strsql = " update " + table + " set ";
            String val = "";
            String con = " WHERE " + p + " = " + pno;
            foreach (String pair in arr2)
            {
                val += pair + ", ";
            }
            strsql += val;
            strsql=strsql.Substring(0, strsql.Length - 2);
            strsql += con;
            
            SqlCommand cmd = new SqlCommand(strsql, cnn);
            int r = cmd.ExecuteNonQuery();
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            arr2.Clear();
            if (Form1.table == 1) {
                arr2.Add(" Fname = " +"'"+ FNAME.Text + "'");
                arr2.Add(" Mname = "+"'"+ MNAME.Text + "'");
                arr2.Add(" Lname = " + "'" +LNAME.Text + "'");
                if (metroRadioButton1.Checked == true) Sex = "F"; else Sex = "M";
                arr2.Add(" Sex = "+"'" + Sex + "'" );
                arr2.Add(" Bdate = "+"'"+ BDATE.Text+"'");
                
                update("Patient",arr2, textBox5.Text, "PatientID");
            }else if (Form1.table == 2)
            {
                arr2.Add(" Name = " + "'" + FNAME.Text + "'");
                arr2.Add(" Price = " +  float.Parse(MNAME.Text));
               

                update("Medicine", arr2, textBox5.Text, "MNO");
            }
            else
            {
                arr2.Add(" VisitDate = " + "'" + MNAME.Text + "'");
                

                update("Patient_Medicine", arr2, textBox5.Text, "PatientID");
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if(Form1.table==1)
            delete("PatientID", textBox5.Text, "Patient");
            else if (Form1.table == 2)
            {
                delete("MNO", textBox5.Text, "Medicine");
            }
            else
            {
                delete("PatientID", textBox5.Text, "Patient_Medicine");
            }


            FNAME.Text = "";
            MNAME.Text = "";
            FNAME.Text = "";
            PNO.Text = "";
            BDATE.Text = "";
            textBox5.Text = "";
            LNAME.Text = "";
            metroRadioButton1.Checked = false;
            metroRadioButton2.Checked = false;
        }
        private void delete(String p, String pno, String table)
        {
            cnn.ConnectionString = s.ConnectionString;
            if (cnn.State == ConnectionState.Closed)
                cnn.Open();
            String strsql = "delete from " + table + " where " + p + "=" + pno;
            SqlCommand cmd = new SqlCommand(strsql, cnn);
            int r = cmd.ExecuteNonQuery();
            if (cnn.State == ConnectionState.Open)
                cnn.Close();
            notification("DELETE");
        }
    }
}
