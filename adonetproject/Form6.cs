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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            #region Connected metodu Insert Using
            //CRUD 

          
      using (SqlConnection con = new SqlConnection(DALC.GetConnectionString()))
            {
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


              

            }


            #endregion



        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {

        }
    }
}
