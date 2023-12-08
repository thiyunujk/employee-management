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

namespace employee_management
{
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection(@"Data Source=JK;Initial Catalog=employee;Integrated Security=True");

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var result = MessageBox.Show("Are you sure, do you really want to exit...?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else
            {
                this.Close();
            }

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            comboBox_empNo.Text = "";
            tb_firstName.Text = "";
            tb_lastName.Text = "";
            dateTimePicker.Format = DateTimePickerFormat.Custom;
            dateTimePicker.CustomFormat = "yyyy/MM/dd";
            DateTime thisDay = DateTime.Today;
            dateTimePicker.Text = thisDay.ToString();
            rb_female.Checked = false;
            rb_male.Checked = false;
            tb_address.Text = "";
            tb_email.Text = "";
            tb_mobilePhone.Text = "";
            tb_homePhone.Text = "";
            tb_depName.Text = "";
            tb_designation.Text = "";
            tb_empType.Text = "";

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Login obj = new Login();
            obj.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string empNo = comboBox_empNo.Text;
                string firstName = tb_firstName.Text;
                string lastName = tb_lastName.Text;
                DateTime dateOfBirth = dateTimePicker.Value;
                string gender;
                if (rb_male.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = tb_address.Text;
                string email = tb_email.Text;
                int mobilePhone = int.Parse(tb_mobilePhone.Text);
                int homePhone = int.Parse(tb_homePhone.Text);
                string departmentName = tb_depName.Text;
                string designation = tb_designation.Text;
                string employeeType = tb_empType.Text;
                string query_insert = "INSERT INTO employee (empNo, FirstName, LastName, DateOfBirth, Gender, Address, Email," +
                    " MobilePhone, HomePhone, DepartmentName, Designation, EmployeeType) VALUES (@EmpNo, @FirstName, @LastName, " +
                    "@DateOfBirth, @Gender, @Address, @Email, @MobilePhone, @HomePhone, @DepartmentName, " +
                    "@Designation, @EmployeeType)";


                con.Open();
                using (SqlCommand cmnd = new SqlCommand(query_insert, con))
                {
                    cmnd.Parameters.AddWithValue("@EmpNo", empNo);
                    cmnd.Parameters.AddWithValue("@FirstName", firstName);
                    cmnd.Parameters.AddWithValue("@LastName", lastName);
                    cmnd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmnd.Parameters.AddWithValue("@Gender", gender);
                    cmnd.Parameters.AddWithValue("@Address", address);
                    cmnd.Parameters.AddWithValue("@Email", email);
                    cmnd.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                    cmnd.Parameters.AddWithValue("@HomePhone", homePhone);
                    cmnd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmnd.Parameters.AddWithValue("@Designation", designation);
                    cmnd.Parameters.AddWithValue("@EmployeeType", employeeType);
                    cmnd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Record added Successfully!", "Registerd Employee!", MessageBoxButtons.OK, MessageBoxIcon.Information);



            }
            catch (SqlException ex)
            {
                string msg = "Insert Error: " + ex.Message;
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string no = comboBox_empNo.Text;
            if (no != "New Register")
            {
                string firstname = tb_firstName.Text;
                string lastname = tb_lastName.Text;
                DateTime dateOfBirth = dateTimePicker.Value;
                string gender;
                if (rb_male.Checked)
                {
                    gender = "Male";
                }
                else
                {
                    gender = "Female";
                }
                string address = tb_address.Text;
                string email = tb_email.Text;
                int mobilePhone = int.Parse(tb_mobilePhone.Text);
                int homePhone = int.Parse(tb_homePhone.Text);
                string departmentName = tb_depName.Text;
                string designation = tb_designation.Text;
                string employeeType = tb_empType.Text;

                string query_update = "UPDATE employee SET firstname = @FirstName, lastname = @LastName, dateOfBirth = @DateOfBirth, gender = @Gender, address = @Address, email = @Email, mobilePhone = @MobilePhone, " +
                    "homePhone = @HomePhone, departmentname = @DepartmentName, designation = @Designation, " +
                    "employeeType = @EmployeeType WHERE empNo = @No";

                con.Open();
                using (SqlCommand cmnd = new SqlCommand(query_update, con))
                {
                    cmnd.Parameters.AddWithValue("@FirstName", firstname);
                    cmnd.Parameters.AddWithValue("@LastName", lastname);
                    cmnd.Parameters.AddWithValue("@DateOfBirth", dateOfBirth);
                    cmnd.Parameters.AddWithValue("@Gender", gender);
                    cmnd.Parameters.AddWithValue("@Address", address);
                    cmnd.Parameters.AddWithValue("@Email", email);
                    cmnd.Parameters.AddWithValue("@MobilePhone", mobilePhone);
                    cmnd.Parameters.AddWithValue("@HomePhone", homePhone);
                    cmnd.Parameters.AddWithValue("@DepartmentName", departmentName);
                    cmnd.Parameters.AddWithValue("@Designation", designation);
                    cmnd.Parameters.AddWithValue("@EmployeeType", employeeType);
                    cmnd.Parameters.AddWithValue("@No", no);
                    cmnd.ExecuteNonQuery();
                }
                con.Close();
                MessageBox.Show("Record Update Successfully!", "Update Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
        }
        
        

        
        private void button4_Click(object sender, EventArgs e)
        {
            {
                var result = MessageBox.Show("Are you Sure, Do you really want to Delete this record...?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string no = comboBox_empNo.Text;

                    string query_insert = "DELETE FROM employee WHERE empNo =  " + no + "";
                    con.Open();
                    SqlCommand cmnd = new SqlCommand(query_insert, con);
                    cmnd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Record Deleted Successfully!", "Deleted Employee", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else if (result == DialogResult.Yes)
                {
                    this.Close();
                }
            }
        }
    }
}
