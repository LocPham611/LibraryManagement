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
    public partial class Reader_BorrowingHistory : Form
    {
        //string connectstring = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectstring = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        private readonly string ReaderID; // ReaderID của tài khoản đăng nhập
        public Reader_BorrowingHistory(string ReaderID)
        {
            InitializeComponent();
            this.ReaderID = ReaderID;
        }

        private void Reader_BorrowingHistory_Load(object sender, EventArgs e)
        {
            LoadBorrowingHistory();
        }
        private void LoadBorrowingHistory()
        {
            // Kết nối cơ sở dữ liệu và truy xuất BorrowingReceiptDetails dựa vào ReaderID
            using (SqlConnection conn = new SqlConnection(connectstring))
            {
                dGVBorrowReturnCheck.Columns.Clear();
                try
                {
                    conn.Open();

                    string query = @"
                SELECT 
                    br.BorrowingReceiptID,
                    br.BorrowingDate,
                    br.ReturnDate,
                    br.ExtensionOption,
                    br.ExtensionDaysNumber,
                    STRING_AGG(b.BookID, ', ') AS BorrowedBookID,
                    STRING_AGG(b.BookTitle, ', ') AS BorrowedBooks,
                    br.BorrowingReceiptStatus
                FROM 
                    BorrowingReceiptDetails br
                LEFT JOIN 
                    BorrowedBooks bb ON br.BorrowingReceiptID = bb.BorrowingReceiptID
                LEFT JOIN 
                    BookDetails b ON bb.BorrowedBookID = b.BookID
                WHERE ReaderID = @ReaderID
                GROUP BY 
                    br.BorrowingReceiptID, 
                    br.BorrowingDate, 
                    br.ReturnDate, 
                    br.ExtensionOption, 
                    br.ExtensionDaysNumber, 
                    br.BorrowingReceiptStatus;";
                    

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@ReaderID", ReaderID); // Truyền tham số ReaderID

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    if (dt.Rows.Count == 0)
                    {
                        MessageBox.Show("No borrowing history found for this account.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        dGVBorrowReturnCheck.DataSource = dt;
                    }
                }
                catch (SqlException ex)
                {
                    MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dGVBorrowReturnCheck_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
