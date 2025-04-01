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
using Microsoft.Win32;
using LibraryManagement.Models;

namespace LibraryManagement
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            RegisterForm register = new RegisterForm();
            register.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReaderRegisterDB"].ConnectionString;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(*) " +
                               "FROM ReaderDetails " +
                               "WHERE ReaderEmail = @Email AND ReaderPassword = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", txtEmail.Text);
                command.Parameters.AddWithValue("@Password", txtPassword.Text);

                int result = (int)command.ExecuteScalar();

                if (result > 0)
                {
                    if (txtEmail.Text.Trim().ToLower() == "li" && txtPassword.Text == "123")
                    {
                        Librarian_Home librarianHome = new Librarian_Home(txtEmail.Text);
                        librarianHome.Show();
                        this.Hide();
                    }
                    else
                    {
                        Reader_Home readerHome = new Reader_Home(txtEmail.Text);
                        readerHome.Show();
                        this.Hide();
                    }
                }
                else
                {
                    MessageBox.Show("Invalid or wrong Email/Password", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
