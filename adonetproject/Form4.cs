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

namespace adonetproject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        public DataTable GetDep()
        {
          
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from DEPARTMENT", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);
            con.Close();
            return dt;
           

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            DataTable dt = GetDep();

            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "DEPARTMENT_NAME";
            comboBox1.ValueMember = "ID";

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("INSERT INTO PERSONAL" +
                "VALUES (@ad,@soyad,@dogumyeri,@dogumtarixi,@mob,@dep)", con);

            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@dogumyeri", textBox3.Text);
            cmd.Parameters.AddWithValue("@mob", textBox4.Text);
            cmd.Parameters.AddWithValue("@dogumtarixi", dateTimePicker1.Text);//Value.ToString("yyyy-MM-dd"));
            cmd.Parameters.AddWithValue("@dep", comboBox1.SelectedValue);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
              int say =  cmd.ExecuteNonQuery();
                MessageBox.Show("Success"+say);
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
