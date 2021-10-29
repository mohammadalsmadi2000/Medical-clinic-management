using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Data.SqlClient;

namespace Project_2
{
    public partial class Form1 : Form
    {
        
        public static int table=0;
        public static string col;
        public Form1()
        {
            InitializeComponent();
            customizeDesing();
        }
        public void StartForm()
        {
            Application.Run(new Form4());
        }

        private void panelSlideMenu_Paint(object sender, PaintEventArgs e)
        {

        }
        private void customizeDesing()
        {
            
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
          
           
        }
        private void hideSubMenu()
        {
            if (panel1.Visible == true)
                panel1.Visible = false;
           if (panel2.Visible== true)
                panel2.Visible = false;
            if (panel3.Visible == true)
                panel3.Visible = false;
          

        }
        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                hideSubMenu();
                subMenu.Visible = true;

            }
            else
                subMenu.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showSubMenu(panel1);
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
             table = 1;
             col = "insert";
            openChildForm(new Form2());
           
            hideSubMenu();
        }

        private void MedicineButoon_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void Patient_MedicineButoon_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            table = 1;
            col = "UpDate";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            table = 1;
            col = "Delete";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        }

        private void button14_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
          
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel5.Controls.Add(childForm);
            panel5.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
          
        }

        private void button8_Click(object sender, EventArgs e)
        {
            table = 2;
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
           
           
        }

        private void metroLink1_Click(object sender, EventArgs e)
        {

        }

        private void button10_Click(object sender, EventArgs e)
        {
            showSubMenu(panel2);
        
        }

        private void button17_Click(object sender, EventArgs e)
        {
            showSubMenu(panel3);
            
        }

        private void button8_Click_1(object sender, EventArgs e)
        {
            table = 2;
            col = "UpDate";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button9_Click_1(object sender, EventArgs e)
        {
            table = 2;
            col = "insert";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            table = 3;
            col = "insert";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button14_Click_1(object sender, EventArgs e)
        {
            table = 3;
            col = "UpDate";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            openChildForm(new Form3());
            hideSubMenu();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            table = 1;
            col = "show";
            openChildForm(new Form5());
            hideSubMenu();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            table = 2;
            col = "Delete";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            table = 2;
            col = "show";
            openChildForm(new Form5());
            hideSubMenu();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            table = 3;
            col = "Delete";
            openChildForm(new Form2());
            hideSubMenu();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            table = 3;
            col = "show";
            openChildForm(new Form5());
            hideSubMenu();
        }
    }
}
