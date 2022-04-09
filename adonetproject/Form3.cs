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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        string ad;
        private void Form3_Load(object sender, EventArgs e)
        {
            //#region connected get reader
            //SqlConnection con = new SqlConnection();
            //con = new SqlConnection(DALC.GetConnectionString());
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd = new SqlCommand("Select * from Customer", con);
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}

            //SqlDataReader dr = cmd.ExecuteReader();

            //DataTable dt = new DataTable();

            //dt.Load(dr);

            //dataGridView1.DataSource = dt;

            //con.Close();
            //#endregion connected 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection();
            con = new SqlConnection(DALC.GetConnectionString());
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select * from Customer where Identitypincode = '" + textBox5.Text + "' ", con);

            SqlDataReader dr = cmd.ExecuteReader();

            
            while (dr.Read())
            {
                textBox1.Text = dr["NAME"].ToString();
                textBox2.Text = dr.GetString(2);
                textBox3.Text = dr.GetString(3);

                textBox4.Text = dr["Identityno"].ToString();

                if (dr.GetString(4) == "M")
                {
                    checkBox1.Checked = true;

                }
                else if (dr.GetString(4) == "F")
                {
                    checkBox2.Checked = true;
                }

                dateTimePicker1.Text = dr["Birthdate"].ToString();
            }


            con.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con = new SqlConnection("Data Source=HP-PC\\SQLEXPRESS; Initial Catalog=main; Integrated Security=true");
            con.Open();
            SqlCommand cmd = new SqlCommand();
            cmd = new SqlCommand("Select count(*) from Customer where id = 4", con);

           // SqlDataReader dr = cmd.ExecuteReader();
            var result =  cmd.ExecuteScalar();

          
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            #region connected get
            SqlConnection con = new SqlConnection();
            con = new SqlConnection("Data Source=User-PC\\SQLEXPRESS; Initial Catalog=OrientDB; Integrated Security=true");
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

        private void button4_Click(object sender, EventArgs e)
        {
            DataGridViewRow grid = dataGridView1.SelectedRows[0];

            int id = (int)grid.Cells["ID"].Value;
            MessageBox.Show(id.ToString());

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataGridViewCell grid = dataGridView1.SelectedCells[0];

            string id = grid.Value.ToString();
            MessageBox.Show(id);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            DataGridViewRow Row = dataGridView1.CurrentRow;
            int id = (int)Row.Cells["ID"].Value;
            MessageBox.Show(id.ToString());
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALC.GetCustomer();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //int i = 0;
   
            //SqlConnection con = new SqlConnection();
            //con = new SqlConnection(DALC.GetConnectionString());
            //con.Open();
            //SqlCommand cmd = new SqlCommand();
            //cmd = new SqlCommand("Select * from Customer", con);
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}

            //SqlDataReader dr = cmd.ExecuteReader();

           
            //dataGridView1.MultiSelect = true;
            //while (dr.Read())
            //{
            //    if (dr["NAME"].ToString() == textBox5.Text)
            //    {
            //        dataGridView1.Rows[i].Selected = true;

            //    }
            //    i++;
            //}

            //    con.Close();
        

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
