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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        } 

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
           
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox2.Checked = false;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                checkBox1.Checked = false;
            }
        }

        private void toolStripLabel2_Click(object sender, EventArgs e)
        {

        }

        private void toolStripLabel3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
           // MessageBox.Show(dateTimePicker2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {

           

        }
        public void doldur()
        {
            #region connected get reader
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from Customer", con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();
            #endregion connected 
        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            #region Connected metodu Insert
            //CRUD create, read, update, delete
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());

            con.Open();

            SqlCommand cmd = new SqlCommand("INSERT INTO Customer (Name,Surname,Birthplace,Gender,Identityno,Identitypincode,Birthdate) " +
                "VALUES (@ad,@soyad,@dogumyeri,@cinsi,@serino,@pincode,@dogumtarixi)", con);


            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@dogumyeri", textBox3.Text);
            if (checkBox1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@cinsi", "M");
            }
            else if (checkBox2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@cinsi", "F");
            }
            cmd.Parameters.AddWithValue("@serino", textBox4.Text);
            cmd.Parameters.AddWithValue("@pincode", textBox5.Text);
            cmd.Parameters.AddWithValue("@dogumtarixi", dateTimePicker1.Text);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            try
            {
                cmd.ExecuteNonQuery();

                MessageBox.Show("Success");
            }
            catch (SqlException ex)
            {

                MessageBox.Show(ex.Message);
            }
            finally
            {
               
                con.Close();
                con.Dispose(); //garbage collector
            }
            //update, insert, delete - ExecuteNonQuery()

            //ExecuteScalar() - select
            //ExecuteReader() - select
            #endregion

            doldur();

        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            #region connected get reader
            SqlConnection con = new SqlConnection(DALC.GetConnectionString());
            
            con.Open();

            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from Customer", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();


            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();
            #endregion connected 
        }

        private void toolStripLabel8_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow Row = dataGridView1.CurrentRow;

           
            textBox1.Tag = Row.Cells["ID"].Value.ToString();

            textBox1.Text = Row.Cells["NAME"].Value.ToString();
            textBox2.Text = Row.Cells["SURNAME"].Value.ToString();
            textBox3.Text = Row.Cells["BIRTHPLACE"].Value.ToString();
            textBox4.Text = Row.Cells["IDENTITYNO"].Value.ToString();
            textBox5.Text = Row.Cells["IDENTITYPINCODE"].Value.ToString();
            dateTimePicker1.Text = Row.Cells["BIRTHDATE"].Value.ToString();
            if (Row.Cells["GENDER"].Value.ToString() == "M")
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox2.Checked = true;
            }

          
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

            #region Connected metodu Update

            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("UPDATE Customer SET  Name =@ad ,Surname = @soyad,Birthplace = @dogumyeri,Gender = @cinsi,Identityno = @serino,Identitypincode = @pincode,Birthdate = @dogumtarixi WHERE ID = @id ", con);

            cmd.Parameters.AddWithValue("@ad", textBox1.Text);
            cmd.Parameters.AddWithValue("@soyad", textBox2.Text);
            cmd.Parameters.AddWithValue("@dogumyeri", textBox3.Text);
            if (checkBox1.Checked == true)
            {
                cmd.Parameters.AddWithValue("@cinsi", "M");
            }
            else if (checkBox2.Checked == true)
            {
                cmd.Parameters.AddWithValue("@cinsi", "F");
            }
            cmd.Parameters.AddWithValue("@serino", textBox4.Text);
            cmd.Parameters.AddWithValue("@pincode", textBox5.Text);
            cmd.Parameters.AddWithValue("@dogumtarixi", dateTimePicker1.Text);
            cmd.Parameters.AddWithValue("@id", textBox1.Tag);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.ExecuteNonQuery();//update, insert, delete
            con.Close();
            //ExecuteScalar() - select
            //ExecuteReader - select
            MessageBox.Show("Update Edildi");

            doldur();
            #endregion 

           
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            #region Connected metodu Delete
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());

            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand(" DELETE  FROM Customer WHERE ID = @id ", con);
            cmd.Parameters.AddWithValue("@id", textBox1.Tag);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.ExecuteNonQuery();//update, insert, delete
            con.Close();
            //ExecuteScalar() - select
            //ExecuteReader - select
            MessageBox.Show("Silindi");
            doldur();
            #endregion 

           
        }

        private void toolStripButton4_Click_1(object sender, EventArgs e)
        {
            string name = textBox1.Text;

            #region connected get scalar
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select count(*) from Customer WHERE NAME = '"+name+"'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            string dr = cmd.ExecuteScalar().ToString();

            MessageBox.Show(dr);
            con.Close();
            #endregion 
        }

        private void Form1_Load(object sender, EventArgs e)
        {
         //   MessageBox.Show("KAMRAN HUSEYNOV");
          // doldur();
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            string name = textBox6.Text;

            #region connected get scalar
            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from Customer WHERE NAME like '" +'%'+ name +'%'+ "'", con);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();


            DataTable dt = new DataTable();

            dt.Load(dr);

            dataGridView1.DataSource = dt;

            con.Close();
            #endregion 
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
