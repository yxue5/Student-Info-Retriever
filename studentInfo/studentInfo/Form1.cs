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

namespace studentInfo
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Server = TAKETWO\\SQLEXPRESS; Database = studentinfo; Trusted_Connection=True;");
        SqlCommand cmd;
        SqlDataReader dr;
        DataTable dt = new DataTable();

        public Form1()
        {
            InitializeComponent();
 
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("select * from info where name = '" + textBox1.Text + "' ", con);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                textBox2.Text = dr[1].ToString();
                textBox3.Text = dr[2].ToString();
            }
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into info values('" + textBox1.Text + "', " + textBox2.Text + ",'" + textBox3.Text + "')  ", con);
            cmd.ExecuteNonQuery();
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            MessageBox.Show("Data Inserted", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
