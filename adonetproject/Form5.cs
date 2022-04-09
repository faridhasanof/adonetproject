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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }
       
        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = DALC.GetCustomer();
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DataTable dt = DALC.GetCustomer();

            DALC.ExportToExcel(dt, null);
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
