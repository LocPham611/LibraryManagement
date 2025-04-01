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
    public partial class Librarian_BorrowingList : Form
    {
        //string connectionString = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectionString = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        SqlConnection connection;

        public Librarian_BorrowingList()
        {
            InitializeComponent();
        }

        private void Librarian_BorrowingList_Load(object sender, EventArgs e)
        {
            // Tải dữ liệu danh sách mượn sách
            LoadBorrowingList();
            dGVBorrowingReceiptsList.CellValueChanged += dGVBorrowingReceiptsList_CellValueChanged;

        }


        private void LoadBorrowingList()
        {            
            // Xóa các cột cũ nếu có
            dGVBorrowingReceiptsList.Columns.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT 
                                br.BorrowingReceiptID,
                                br.ReaderID,
                                br.ReaderName,
                                br.BorrowingDate,
                                br.ReturnDate,
                                STRING_AGG(b.BookID, ', ') AS BorrowedBookID,
                                STRING_AGG(b.BookTitle, ', ') AS BorrowedBooks,
                                br.ExtensionOption,
                                br.ExtensionDaysNumber,
                                br.BorrowingReceiptStatus
                            FROM 
                                BorrowingReceiptDetails br
                            LEFT JOIN 
                                BorrowedBooks bb ON br.BorrowingReceiptID = bb.BorrowingReceiptID
                            LEFT JOIN 
                                BookDetails b ON bb.BorrowedBookID = b.BookID
                            GROUP BY 
                                br.BorrowingReceiptID, 
                                br.ReaderID, 
                                br.ReaderName, 
                                br.BorrowingDate, 
                                br.ReturnDate, 
                                br.ExtensionOption, 
                                br.ExtensionDaysNumber, 
                                br.BorrowingReceiptStatus;";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    dGVBorrowingReceiptsList.DataSource = dt;
                    
                    // Xóa cột PaymentStatus cũ và thêm mới bằng ComboBoxColumn
                    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                    comboBoxColumn.Name = "BorrowingReceiptStatus";
                    comboBoxColumn.HeaderText = "Borrowing Receipt Status";
                    comboBoxColumn.DataSource = new string[] 
                    { 
                        "Pending", "Borrowed", "Returned", "Canceled", "Lated" 
                    }; // Giá trị trong ComboBox
                    comboBoxColumn.DataPropertyName = "BorrowingReceiptStatus"; // Gắn với dữ liệu trong DataTable
                    comboBoxColumn.FlatStyle = FlatStyle.Flat;

                    dGVBorrowingReceiptsList.Columns.Remove("BorrowingReceiptStatus");
                    dGVBorrowingReceiptsList.Columns.Add(comboBoxColumn); // Thêm cột ComboBox mới

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void dGVBorrowingReceiptsList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVBorrowingReceiptsList.Columns[e.ColumnIndex].Name == "BorrowingReceiptStatus")
            {
                // Lấy FineReceiptID và PaymentStatus mới
                string borrowingReceiptID = dGVBorrowingReceiptsList.Rows[e.RowIndex].Cells["BorrowingReceiptID"].Value.ToString();
                string borrowingReceiptStatus = dGVBorrowingReceiptsList.Rows[e.RowIndex].Cells["BorrowingReceiptStatus"].Value.ToString();

                // Cập nhật thông tin vào cơ sở dữ liệu
                UpdateBorrowingStatus(borrowingReceiptID, borrowingReceiptStatus);
            }
        }

        private void UpdateBorrowingStatus(string borrowingReceiptID, string borrowingReceiptStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE BorrowingReceiptDetails SET BorrowingReceiptStatus = @BorrowingReceiptStatus WHERE BorrowingReceiptID = @BorrowingReceiptID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BorrowingReceiptID", borrowingReceiptID);
                        cmd.Parameters.AddWithValue("@BorrowingReceiptStatus", borrowingReceiptStatus);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Borrowing Receipt Status updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating Borrowing Receipt Status: " + ex.Message);
            }
        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                StringBuilder query = new StringBuilder(@"SELECT 
                                br.BorrowingReceiptID,
                                br.ReaderID,
                                br.ReaderName,
                                br.BorrowingDate,
                                br.ReturnDate,
                                STRING_AGG(b.BookID, ', ') AS BorrowedBookID,
                                STRING_AGG(b.BookTitle, ', ') AS BorrowedBooks,
                                br.ExtensionOption,
                                br.ExtensionDaysNumber,
                                br.BorrowingReceiptStatus
                            FROM 
                                BorrowingReceiptDetails br
                            LEFT JOIN 
                                BorrowedBooks bb ON br.BorrowingReceiptID = bb.BorrowingReceiptID
                            LEFT JOIN 
                                BookDetails b ON bb.BorrowedBookID = b.BookID
                            WHERE 1=1");

                // Danh sách điều kiện lọc
                List<string> statusConditions = new List<string>();
                List<string> extensionConditions = new List<string>();
                
                // Lọc theo trạng thái mượn
                if (chkbPending.Checked)
                    statusConditions.Add("BorrowingReceiptStatus = 'Pending'");
                if (chkbBorrowed.Checked)
                    statusConditions.Add("BorrowingReceiptStatus = 'Borrowed'");
                if (chkbReturned.Checked)
                    statusConditions.Add("BorrowingReceiptStatus = 'Returned'");
                if (chkbCanceled.Checked)
                    statusConditions.Add("BorrowingReceiptStatus = 'Canceled'");
                if (chkbLated.Checked)
                    statusConditions.Add("BorrowingReceiptStatus = 'Lated'");
                

                // Lọc theo gia hạn
                if (chkbYes.Checked)
                    extensionConditions.Add("ExtensionOption = 'Yes'");
                if (chkbNo.Checked)
                    extensionConditions.Add("ExtensionOption = 'No'");

                // Nếu có điều kiện trạng thái mượn, nối vào query
                if (statusConditions.Count > 0)
                    query.Append(" AND (" + string.Join(" OR ", statusConditions) + ")");

                // Nếu có điều kiện gia hạn, nối vào query
                if (extensionConditions.Count > 0)
                    query.Append(" AND (" + string.Join(" OR ", extensionConditions) + ")");

                query.Append(@" GROUP BY 
                    br.BorrowingReceiptID, 
                    br.ReaderID, 
                    br.ReaderName, 
                    br.BorrowingDate, 
                    br.ReturnDate, 
                    br.ExtensionOption, 
                    br.ExtensionDaysNumber, 
                    br.BorrowingReceiptStatus");

                SqlDataAdapter da = new SqlDataAdapter(query.ToString(), conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dGVBorrowingReceiptsList.DataSource = dt;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dGVBorrowingReceiptsList.Rows)
                    {
                        // Kiểm tra nếu hàng hợp lệ và chứa dữ liệu
                        if (row.Cells["BorrowingReceiptID"].Value != null && row.Cells["BorrowingReceiptStatus"].Value != null)
                        {
                            string borrowingReceiptID = row.Cells["BorrowingReceiptID"].Value.ToString();
                            string borrowingReceiptStatus = row.Cells["BorrowingReceiptStatus"].Value.ToString();

                            string query = "UPDATE BorrowingReceiptDetails SET BorrowingReceiptStatus = @BorrowingReceiptStatus WHERE BorrowingReceiptID = @BorrowingReceiptID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@BorrowingReceiptID", borrowingReceiptID);
                                cmd.Parameters.AddWithValue("@BorrowingReceiptStatus", borrowingReceiptStatus);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Borrowing Receipt Status updated successfully!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dGVBorrowingReceiptsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

