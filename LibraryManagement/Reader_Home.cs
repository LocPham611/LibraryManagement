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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace LibraryManagement
{
    public partial class Reader_Home : Form
    {
        private string email;
        private string ReaderID;
        string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ReaderRegisterDB"].ConnectionString;

        public Reader_Home(string email)
        {
            InitializeComponent();
            this.email = email;
            this.ReaderID = ReaderID;
        }



        private void LoadReaderInfo()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT ReaderID, ReaderName, ReaderEmail, ReaderPhoneNumber, ReaderAddress, AccountStatus " +
                               "FROM ReaderDetails " +
                               "WHERE ReaderEmail = @Email";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Email", email);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    ReaderID = reader["ReaderID"].ToString(); // Gán ReaderID từ cơ sở dữ liệu
                    lReaderID.Text = ReaderID; // Hiển thị ReaderID lên giao diện
                    lReaderName.Text = reader["ReaderName"].ToString();
                    lEmail.Text = reader["ReaderEmail"].ToString();
                    lPhoneNumber.Text = reader["ReaderPhoneNumber"].ToString();
                    lAddress.Text = reader["ReaderAddress"].ToString();
                    lAccountStatus.Text = reader["AccountStatus"].ToString();
                }
            }
        }

        private void Reader_Home_Load(object sender, EventArgs e)
        {
            LoadReaderInfo();
        }


        private void btnBorrowReturnCheck_Click_1(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ReaderID))
            {
                Reader_BorrowingHistory borrowingHistory = new Reader_BorrowingHistory(ReaderID);
                borrowingHistory.ShowDialog();
            }
            else
            {
                MessageBox.Show("Reader ID not found. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFineCheck_Click_1(object sender, EventArgs e)
        {
            Reader_FineCheck fineCheck = new Reader_FineCheck(ReaderID);
            fineCheck.ShowDialog();
        }

        private void btnLogOut_Click_2(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Do you want to log out?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ẩn form hiện tại (MainForm)
                this.Hide();

                // Mở lại form đăng nhập (LoginForm)
                LoginForm loginForm = new LoginForm();
                loginForm.Show();

                // Đóng hoàn toàn form chính để tránh chạy nền
                this.Close();
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {
            string newPassword = txtChangePassword.Text.Trim();

            // Kiểm tra mật khẩu mới không để trống
            if (string.IsNullOrEmpty(newPassword))
            {
                MessageBox.Show("New Password can't be blank!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ReaderDetails SET ReaderPassword = @NewPassword WHERE ReaderEmail = @Email";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NewPassword", newPassword);
                        cmd.Parameters.AddWithValue("@Email", email); // Email của người dùng hiện tại

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("New Password updated successfully!", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Updated fail, please check again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "System error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        // phan cua Loc
        private void SearchBooks(string bookTitle, string category)
        {
            flowLayoutPanelBook.Controls.Clear(); // Xóa danh sách cũ
            var booksFromDB = GetBooksFromDatabase();



            if (category == "Tất cả" || string.IsNullOrEmpty(category))
            {
                category = null; // Nếu chọn "Tất cả", không lọc thể loại
            }
            // Lọc sách theo tên hoặc thể loại

            var result = booksFromDB.Where(b =>
                (string.IsNullOrEmpty(bookTitle) || (b["Title"]?.ToString() ?? "").ToLower().Contains(bookTitle.ToLower())) &&
                (string.IsNullOrEmpty(category) || (b["Category"]?.ToString() ?? "").ToLower().Contains(category.ToLower()))
            ).ToList();

            // Hiển thị kết quả tìm kiếm
            foreach (var book in result)
            {
                BookItem bookItem = new BookItem();
                bookItem.SetBookInfo(/*book.title, book.author, book.category, book.imagePath,*/book);
                flowLayoutPanelBook.Controls.Add(bookItem);
            }
        }

        private List<Dictionary<string, object>> GetBooksFromDatabase()
        {
            List<Dictionary<string, object>> books = new List<Dictionary<string, object>>();


            string query = "SELECT BookID, BookTitle, AuthorName, CategoryName, ImagePath FROM BookDetails"; // 🔹 Điều chỉnh nếu cần

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            books.Add(new Dictionary<string, object>
                    {
                        { "ID", reader["BookID"] },
                        { "Title", reader["BookTitle"] },
                        { "Author", reader["AuthorName"] },
                        { "Category", reader["CategoryName"] },
                        { "Image", reader["ImagePath"] }
                    });
                        }
                    }
                }
            }

            return books;
        }

        private void Search_Click(object sender, EventArgs e)
        {
            string bookTitle = txtBookTitle.Text.Trim();
            string category = txtCategory.SelectedItem?.ToString();

            SearchBooks(bookTitle, category);
        }

        private void AddToBookCart_Click(object sender, EventArgs e)
        {
            foreach (BookItem bookItem in flowLayoutPanelBook.Controls)
            {
                if (bookItem.IsSelected()) // Nếu sách được chọn
                {
                    Dictionary<string, object> selectedBook = bookItem.GetBookData();
                    AddToBookCarts(selectedBook);

                    // Bỏ chọn sách sau khi thêm vào Book Cart
                    bookItem.Deselect();
                }
            }
        }

        private void AddToBookCarts(Dictionary<string, object> book)
        {
            DataGridViewRow row = new DataGridViewRow();
            row.CreateCells(dgvBookCart);

            row.Cells[0].Value = book["ID"];
            row.Cells[1].Value = book["Title"];
            row.Cells[2].Value = book["Author"];
            row.Cells[3].Value = book["Category"];
            row.Cells[4].Value = 1; // Mặc định số lượng là 1

            dgvBookCart.Rows.Add(row);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            if (dgvBookCart.CurrentRow != null) // Kiểm tra có dòng nào đang chọn không
            {
                dgvBookCart.Rows.Remove(dgvBookCart.CurrentRow); // Xóa dòng được chọn khỏi DataGridView
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Borrow_Click(object sender, EventArgs e)
        {
            string readerID = GetLoggedInReaderID();
            string readerName = GetReaderNameByID(readerID);

            // Lấy ngày mượn (hiện tại)
            DateTime borrowingDate = DateTime.Now;

            // Kiểm tra người dùng có chọn gia hạn không
            string extensionOption = chkExtendLoan.Checked ? "Yes" : "No";
            int extensionDaysNumber = extensionOption == "Yes" ? Convert.ToInt32(cmbExtendDays.SelectedItem) : 0;

            // Tính ngày trả sách
            DateTime returnDate = borrowingDate.AddDays(7 + extensionDaysNumber);

            // Trạng thái phiếu mượn
            string borrowingReceiptStatus = "Pending";

            // Tạo BorrowingReceiptID tự động tăng
            string borrowingReceiptID = GetNextBorrowingReceiptID().ToString();

            // Thêm vào database
            string query = "INSERT INTO BorrowingReceiptDetails (BorrowingReceiptID, ReaderID, ReaderName, BorrowingDate, ReturnDate, ExtensionOption, ExtensionDaysNumber, BorrowingReceiptStatus) " +
                           "VALUES (@BorrowingReceiptID, @ReaderID, @ReaderName, @BorrowingDate, @ReturnDate, @ExtensionOption, @ExtensionDaysNumber, @BorrowingReceiptStatus)";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@BorrowingReceiptID", borrowingReceiptID);
                    cmd.Parameters.AddWithValue("@ReaderID", readerID);
                    cmd.Parameters.AddWithValue("@ReaderName", readerName);
                    cmd.Parameters.AddWithValue("@BorrowingDate", borrowingDate);
                    cmd.Parameters.AddWithValue("@ExtensionOption", extensionOption);
                    cmd.Parameters.AddWithValue("@ExtensionDaysNumber", extensionDaysNumber);
                    cmd.Parameters.AddWithValue("@ReturnDate", returnDate);
                    cmd.Parameters.AddWithValue("@BorrowingReceiptStatus", borrowingReceiptStatus);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Mượn sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //lưu thông tin sách
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction transaction = conn.BeginTransaction(); // Bắt đầu transaction

                try
                {
                    foreach (DataGridViewRow row in dgvBookCart.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            string borrowedbookID = row.Cells["BookID"].Value.ToString();
                            string borrowedbookTitle = row.Cells["BookTitle"].Value.ToString();


                            string queryInsertBorrowedBook = "INSERT INTO BorrowedBooks (BorrowingReceiptID, BorrowedBookID, BorrowedBookName) " +
                                                             "VALUES (@BorrowingReceiptID, @BorrowedBookID, @BorrowedBookName)";

                            using (SqlCommand cmd = new SqlCommand(queryInsertBorrowedBook, conn, transaction)) // Thêm transaction vào đây
                            {
                                cmd.Parameters.AddWithValue("@BorrowingReceiptID", borrowingReceiptID);
                                cmd.Parameters.AddWithValue("@BorrowedBookID", borrowedbookID);
                                cmd.Parameters.AddWithValue("@BorrowedBookName", borrowedbookTitle);

                                cmd.ExecuteNonQuery();
                            }

                            // Cập nhật trạng thái BookStatus thành 'Unavailable' trong BookDetails
                            string queryUpdateBookStatus = @"
                                 UPDATE BookDetails
                                 SET BookStatus = 'Unavailable'
                                 WHERE BookID = @BookID";

                            SqlCommand cmdUpdateStatus = new SqlCommand(queryUpdateBookStatus, conn, transaction);
                            cmdUpdateStatus.Parameters.AddWithValue("@BookID", borrowedbookID);
                            cmdUpdateStatus.ExecuteNonQuery();
                        }
                    }

                    transaction.Commit(); // Xác nhận lưu dữ liệu
                }
                catch (Exception ex)
                {
                    transaction.Rollback(); // Nếu lỗi, hủy tất cả thay đổi
                    MessageBox.Show("Lỗi khi lưu sách vào bảng BorrowedBook: " + ex.Message);
                }

            }
        }

        private string GetLoggedInReaderID()
        {
            // Giả sử bạn đã có biến lưu thông tin bạn đọc sau khi đăng nhập
            return ReaderID;
        }

        private string GetReaderNameByID(string readerID)
        {
            string readerName = "";
            string query = "SELECT ReaderName FROM ReaderDetails WHERE ReaderID = @ReaderID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Kiểm tra nếu readerID rỗng thì không thực hiện truy vấn
                    if (string.IsNullOrEmpty(readerID))
                    {
                        MessageBox.Show("ReaderID không hợp lệ!");
                        return "";
                    }

                    cmd.Parameters.AddWithValue("@ReaderID", readerID);
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        readerName = result.ToString();
                    }
                }
            }
            return readerName;
        }

        private string GetNextBorrowingReceiptID()
        {
            int nextID = 1;
            string query = "SELECT MAX(CAST(SUBSTRING(BorrowingReceiptID, 3, LEN(BorrowingReceiptID)) AS INT)) FROM BorrowingReceiptDetails";


            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    var result = cmd.ExecuteScalar();
                    if (result != DBNull.Value && result != null)
                    {
                        nextID = Convert.ToInt32(result) + 1;
                    }
                }
            }
            return "BR" + nextID.ToString("D6");
        }

        private void LoadBookCart()
        {
            string query = "SELECT * FROM BookCart";
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
            {
                adapter.Fill(dt);
            }
            dgvBookCart.DataSource = dt;
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            
        

        }
    }
}
