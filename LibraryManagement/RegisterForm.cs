using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class RegisterForm : Form
    {
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbxGender_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReaderRegisterDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string checkEmailQuery = "SELECT COUNT (*) " +
                                         "FROM ReaderDetails " +
                                         "WHERE ReaderEmail = @Email";
                SqlCommand checkEmailCommand = new SqlCommand(checkEmailQuery, connection);
                checkEmailCommand.Parameters.AddWithValue("@Email", txtEmail.Text);

                int emailExists = (int)checkEmailCommand.ExecuteScalar();

                if (emailExists > 0)
                {
                    MessageBox.Show("This Email already registered.");
                    return;
                }

                // Lấy ID lớn nhất hiện tại từ cơ sở dữ liệu
                string getMaxReaderIdQuery = "SELECT TOP 1 ReaderID FROM ReaderDetails ORDER BY ReaderID DESC";
                SqlCommand getMaxReaderIdCommand = new SqlCommand(getMaxReaderIdQuery, connection);

                string lastReaderId = (string)getMaxReaderIdCommand.ExecuteScalar();
                string newReaderId;

                // Nếu không có ID nào, bắt đầu từ "NDC250000"
                if (string.IsNullOrEmpty(lastReaderId))
                {
                    newReaderId = "NDC250000";
                }
                else
                {
                    // Lấy phần số từ ID cuối cùng, tăng lên 1
                    int numericPart = int.Parse(lastReaderId.Substring(3)); // Bỏ phần "NDC"
                    numericPart++;
                    newReaderId = "NDC" + numericPart.ToString("D6"); // Định dạng ID mới
                }

                // Thêm thông tin người đọc mới vào bảng
                string insertQuery = "INSERT INTO ReaderDetails (ReaderID, ReaderName, ReaderEmail, ReaderPassword, ReaderPhoneNumber, ReaderAddress, Gender, AccountStatus) " +
                             "VALUES (@ReaderID, @Name, @Email, @Password, @PhoneNumber, @Address, @Gender, @AccountStatus)";
                SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                insertCommand.Parameters.AddWithValue("@ReaderID", newReaderId);
                insertCommand.Parameters.AddWithValue("@Name", txtName.Text);
                insertCommand.Parameters.AddWithValue("@Email", txtEmail.Text);
                insertCommand.Parameters.AddWithValue("@Password", txtPassword.Text);
                insertCommand.Parameters.AddWithValue("@PhoneNumber", txtPhoneNumber.Text);
                insertCommand.Parameters.AddWithValue("@Address", txtAddress.Text);
                insertCommand.Parameters.AddWithValue("@Gender", cbxGender.SelectedItem.ToString());
                insertCommand.Parameters.AddWithValue("@AccountStatus", "Valid"); // Thêm trạng thái mặc định là "Valid"

                try
                {
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Registration successful! Your Reader ID is {newReaderId}");
                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            cbxGender.Items.Add("Male");
            cbxGender.Items.Add("Female");
            cbxGender.Items.Add("Other");
        }
    }
}
