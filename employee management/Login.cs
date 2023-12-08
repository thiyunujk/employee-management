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
using System.Runtime.InteropServices;

namespace employee_management
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=JK;Initial Catalog=employee;Integrated Security=True");
        private void button2_Click(object sender, EventArgs e)
        {
           con.Open();

           string username = tb_username.Text;
           string password = tb_password.Text;

           string query_select = "SELECT * FROM login WHERE username = '" + username + "' AND password = '" + password + "'";
           SqlCommand cmnd = new SqlCommand(query_select, con);
           SqlDataReader row = cmnd.ExecuteReader();

           if (row.HasRows)
           {
               this.Hide();
               Homepage homepage = new Homepage();
               homepage.Show();
                
                
             
           }
           else
           {
               MessageBox.Show("Invalid Login Credintials, Please ckeck Username & Password and try again!", "Invalid Login details", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tb_password.Clear();
            tb_username.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Are you sure, do you really want to exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void tb_username_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

