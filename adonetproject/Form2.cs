using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace adonetproject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            #region disconnected metodu insert
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
             
            string cins = "";
            if (checkBox1.Checked == true)
            {
                cins = "M";
            }
            else if (checkBox2.Checked == true)
            {

                cins = "F";
            }
            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter = new SqlDataAdapter("INSERT INTO Customer (Name,Surname,Birthplace,Gender,Identityno,Identitypincode,Birthdate) VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + cins + "', '" + textBox4.Text + "','" + textBox5.Text + "','" + dateTimePicker1.Text + "')", con);

           // DataSet dataset = new DataSet();

            DataTable datatable = new DataTable();

            adapter.Fill(datatable);
            MessageBox.Show("insert edildi");
            #endregion 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            #region disconnected get
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter = new SqlDataAdapter("Select * from Customer", con);
            DataTable datatable = new DataTable();
            adapter.Fill(datatable);
            dataGridView1.DataSource = datatable;
            #endregion
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string path = "G:\\metn.txt";
            //string text;
            //text = File.ReadAllText(path);
            //int d = text

            //textBox6.Text = text;
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel4_Click(object sender, EventArgs e)
        {
            #region disconnected get
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());

            SqlDataAdapter adapter = new SqlDataAdapter();

            adapter = new SqlDataAdapter("Select * from Customer", con);

            DataTable datatable = new DataTable();
            adapter.Fill(datatable);

            dataGridView1.DataSource = datatable;

            #endregion
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
