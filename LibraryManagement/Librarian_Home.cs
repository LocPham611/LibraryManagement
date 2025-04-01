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
using System.IO;

namespace LibraryManagement
{
    public partial class Librarian_Home : Form
    {
        //string connectionString = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectionString = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        public Librarian_Home(string text)
        {
            InitializeComponent();
        }
        private void btnReaderList_Click_1(object sender, EventArgs e)
        {
            Librarian_ReaderList readerList = new Librarian_ReaderList();
            readerList.Show();
        }
        private void btnBorrowingList_Click_1(object sender, EventArgs e)
        {
            Librarian_BorrowingList borrowingList = new Librarian_BorrowingList();
            borrowingList.ShowDialog();
        }
        private void btnFineList_Click_1(object sender, EventArgs e)
        {
            Librarian_FineList fineList = new Librarian_FineList();
            fineList.ShowDialog();
        }
 

        private void Librarian_Home_Load(object sender, EventArgs e)
        {
            cbxQuarterlyStatisics.Items.AddRange(new string[] { "1", "2", "3", "4" });
            cbxQuarterlyStatisics.SelectedIndex = 0;
            dGVBookManagement.Columns.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BookDetails"; // Chỉnh sửa câu lệnh SQL nếu cần
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dGVBookManagement.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void ShowStatistics(string whereClause, int month, int year, int quarter)
        {
            string query = $@"
                SELECT 
                    COUNT(DISTINCT bb.BorrowedBookID) AS TotalBorrowedBooks, 

                    SUM(CASE WHEN fr.LateStatus = 'Yes' THEN fr.LateDays * 10000 ELSE 0 END) AS TotalLatedFineFee,

                    COUNT(br.ExtensionOption) AS TotalExtension,

                    SUM(CASE WHEN br.ExtensionOption = 'Yes' THEN br.ExtensionDaysNumber * 5000 ELSE 0 END) AS TotalExtensionFee,

                    SUM(CASE WHEN fr.LateStatus = 'Yes' THEN fr.LateDays * 10000 ELSE 0 END) + 
                    SUM(CASE WHEN br.ExtensionOption = 'Yes' THEN br.ExtensionDaysNumber * 5000 ELSE 0 END) AS Revenue

                FROM BorrowingReceiptDetails br
                LEFT JOIN BorrowedBooks bb ON br.BorrowingReceiptID = bb.BorrowingReceiptID
                LEFT JOIN FineReceiptDetails fr ON br.BorrowingReceiptID = fr.BorrowingReceiptID
                WHERE {whereClause}";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, conn))
            {
                if (month > 0) cmd.Parameters.AddWithValue("@Month", month);
                if (quarter > 0) cmd.Parameters.AddWithValue("@Quarter", quarter);
                cmd.Parameters.AddWithValue("@Year", year);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        txtTotalBorrowedBooks.Text = reader["TotalBorrowedBooks"].ToString();
                        txtTotalLatedFineFee.Text = reader["TotalLatedFineFee"].ToString();
                        txtTotalExtension.Text = reader["TotalExtension"].ToString();
                        txtTotalExtensionFee.Text = reader["TotalExtensionFee"].ToString();
                        txtRevenue.Text = reader["Revenue"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Không có dữ liệu thống kê!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }


        private void cbxCategory_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            /*cbCategory.Items.Add("Bi an");
            cbCategory.Items.Add("Gia tuong");
            cbCategory.Items.Add("Kinh di");
            cbCategory.Items.Add("Lich su");
            cbCategory.Items.Add("Tinh cam");
            cbCategory.Items.Add("Tam ly");
            cbCategory.Items.Add("Thieu nhi");*/
        }

        private void btnShowMonthlyStatisics_Click(object sender, EventArgs e)
        {
            int month = dtpMonthlyStatisics.Value.Month;
            int year = dtpMonthlyStatisics.Value.Year;
            ShowStatistics("MONTH(BorrowingDate) = @Month AND YEAR(BorrowingDate) = @Year", month, year, 0);
        }

        private void btnQuarterlyStatisics_Click(object sender, EventArgs e)
        {
            if (cbxQuarterlyStatisics.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn một quý!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int quarter = int.Parse(cbxQuarterlyStatisics.SelectedItem.ToString());
            int year = dtpQuarterlyStatisics_Year.Value.Year;
            ShowStatistics("DATEPART(QUARTER, BorrowingDate) = @Quarter AND YEAR(BorrowingDate) = @Year", 0, year, quarter);
        }

        private void btnYearlyStatisics_Click(object sender, EventArgs e)
        {
            int year = dtpYearlyStatisics.Value.Year;
            ShowStatistics("YEAR(BorrowingDate) = @Year", 0, year, 0);
        }

        private void btnLogOut_Click(object sender, EventArgs e)
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


        // phan cua Loc
        private string selectedBookID = "";

        private string oldImagePath = "";

        private void dGVBookManagement_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chọn đúng dòng hợp lệ
            {
                DataGridViewRow row = dGVBookManagement.Rows[e.RowIndex];
                selectedBookID = row.Cells["BookID"].Value.ToString(); // Lưu BookID vào biến
                txtBookTitle.Text = row.Cells["BookTitle"].Value.ToString();
                txtAuthorName.Text = row.Cells["AuthorName"].Value.ToString();
                txtPublisherName.Text = row.Cells["PublisherName"].Value.ToString();
                txtYear.Text = row.Cells["Year"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtValue.Text = row.Cells["BookValue"].Value.ToString();
                cbCategory.SelectedItem = row.Cells["CategoryName"].Value.ToString();

                // Lấy đường dẫn ảnh từ database (nếu có)
                oldImagePath = row.Cells["ImagePath"].Value?.ToString();
                if (string.IsNullOrEmpty(oldImagePath))
                {
                    oldImagePath = ""; // Hoặc để ảnh mặc định
                }

                // Hiển thị ảnh lên PictureBox nếu có
                if (!string.IsNullOrEmpty(oldImagePath) && File.Exists(oldImagePath))
                {
                    picBookImage.Image = Image.FromFile(oldImagePath);
                    picBookImage.ImageLocation = oldImagePath;
                }
                else
                {
                    picBookImage.Image = null; // Không có ảnh
                }
                imagePath = oldImagePath;
            }
        }

        private string imagePath = "";
        private string fileName = "";

        private void Browse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                string imageFolder = Path.Combine(Application.StartupPath, "Images");
                openFileDialog.InitialDirectory = imageFolder;  // Mở sẵn thư mục Images
                openFileDialog.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png";
                openFileDialog.Title = "Chọn ảnh từ thư mục Images";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;

                    // Lấy tên file ảnh
                    fileName = Path.GetFileName(selectedFile);

                    // Lưu đường dẫn ảnh (chỉ lưu tên file, không lưu full path)
                    imagePath = Path.Combine("Images", fileName);

                    // Hiển thị ảnh trong PictureBox
                    picBookImage.Image = Image.FromFile(selectedFile);
                }
            }
        }

        private void SearchBooks()
        {
            dGVBookManagement.Columns.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    string query = "SELECT * FROM BookDetails WHERE 1=1";
                    List<SqlParameter> parameters = new List<SqlParameter>();

                    if (!string.IsNullOrEmpty(txtBookTitle.Text))
                    {
                        query += " AND BookTitle LIKE @BookTitle";
                        parameters.Add(new SqlParameter("@BookTitle", "%" + txtBookTitle.Text + "%"));
                    }

                    if (!string.IsNullOrEmpty(txtAuthorName.Text))
                    {
                        query += " AND AuthorName LIKE @AuthorName";
                        parameters.Add(new SqlParameter("@AuthorName", "%" + txtAuthorName.Text + "%"));
                    }

                    if (!string.IsNullOrEmpty(txtPublisherName.Text))
                    {
                        query += " AND PublisherName LIKE @PublisherName";
                        parameters.Add(new SqlParameter("@PublisherName", "%" + txtPublisherName.Text + "%"));
                    }

                    if (!string.IsNullOrEmpty(txtValue.Text))
                    {
                        query += " AND BookValue = @BookValue";
                        parameters.Add(new SqlParameter("@BookValue", txtValue.Text));
                    }

                    if (cbCategory.SelectedItem != null && cbCategory.SelectedItem.ToString() != "Tất cả")
                        query += " AND CategoryName = @Category";



                    if (!string.IsNullOrEmpty(txtQuantity.Text))
                    {
                        query += " AND Quantity = @Quantity";
                        parameters.Add(new SqlParameter("@Quantity", txtQuantity.Text));
                    }

                    if (!string.IsNullOrEmpty(txtYear.Text))
                    {
                        query += " AND Year = @Year";
                        parameters.Add(new SqlParameter("@Year", txtYear.Text));
                    }

                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddRange(parameters.ToArray());
                    if (cbCategory.SelectedItem != null && cbCategory.SelectedItem.ToString() != "Tất cả")
                        cmd.Parameters.AddWithValue("@Category", cbCategory.SelectedItem.ToString());

                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();

                    conn.Open();
                    adapter.Fill(dt);
                    dGVBookManagement.DataSource = dt; // Hiển thị kết quả trong DataGridView
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi tìm kiếm: " + ex.Message);
                }
            }
        }

        private void Search_Click(object sender, EventArgs e)
        {
            SearchBooks();
        }

        private void ClearSearchFields()
        {
            txtBookTitle.Clear();
            txtAuthorName.Clear();
            txtPublisherName.Clear();
            txtValue.Clear();
            txtQuantity.Clear();
            txtYear.Clear();
            cbCategory.SelectedIndex = -1; // Bỏ chọn combobox

            // Xóa ảnh trong PictureBox
            picBookImage.Image = null;

            // Reset lại đường dẫn ảnh
            imagePath = "";

            dGVBookManagement.DataSource = null; // Xóa dữ liệu trong DataGridView
        }

        private void Clear_Click(object sender, EventArgs e)
        {
            ClearSearchFields();
        }

        private void Edit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedBookID))
            {
                MessageBox.Show("Vui lòng chọn một cuốn sách để sửa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {

                    conn.Open();
                    string query = @"
                UPDATE BookDetails
                SET BookTitle = @BookTitle, 
                    AuthorName = @AuthorName, 
                    PublisherName = @PublisherName, 
                    Year = @Year, 
                    Quantity = @Quantity, 
                    BookValue = @BookValue, 
                    CategoryName = @CategoryName,
                    ImagePath = @ImagePath 
                WHERE BookID = @BookID";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@BookID", selectedBookID);
                        cmd.Parameters.AddWithValue("@BookTitle", txtBookTitle.Text);
                        cmd.Parameters.AddWithValue("@AuthorName", txtAuthorName.Text);
                        cmd.Parameters.AddWithValue("@PublisherName", txtPublisherName.Text);
                        cmd.Parameters.AddWithValue("@Year", txtYear.Text);
                        cmd.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                        cmd.Parameters.AddWithValue("@BookValue", txtValue.Text);
                        cmd.Parameters.AddWithValue("@CategoryName", cbCategory.SelectedItem.ToString());

                        string newImagePath = "";
                        if (picBookImage.Image != null && !string.IsNullOrEmpty(picBookImage.ImageLocation))
                        {
                            newImagePath = picBookImage.ImageLocation; // Ảnh mới được chọn
                        }
                        else
                        {
                            newImagePath = oldImagePath; // Giữ nguyên ảnh cũ nếu không chọn ảnh mới
                        }
                        string imagePathToUpdate = string.IsNullOrEmpty(imagePath) ?
                                       dGVBookManagement.SelectedRows[0].Cells["ImagePath"].Value.ToString()
                                       : imagePath;
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePathToUpdate) ? (object)DBNull.Value : imagePathToUpdate);



                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            LoadBookData(); // Cập nhật lại DataGridView sau khi sửa
                        }
                        else
                        {
                            MessageBox.Show("Không thể cập nhật sách!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadBookData()
        {
            dGVBookManagement.Columns.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * FROM BookDetails"; // Hoặc có điều kiện tìm kiếm nếu cần

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);
                            dGVBookManagement.DataSource = dt; // Hiển thị dữ liệu mới trong DataGridView
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (dGVBookManagement.SelectedRows.Count > 0)
            {
                string bookID = dGVBookManagement.SelectedRows[0].Cells["BookID"].Value.ToString(); // Lấy BookID từ dòng được chọn

                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa sách này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM BookDetails WHERE BookID = @BookID";

                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@BookID", bookID);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Xóa sách thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadBookData(); // Cập nhật lại danh sách sách trong DataGridView
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một quyển sách để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();


                    // Lấy CategoryID từ tên thể loại
                    string categoryName = cbCategory.SelectedItem?.ToString();
                    string categoryID = GenerateCategoryID(cbCategory.Text);
                    if (categoryID == null) return; // Nếu chọn "Tất cả" thì dừng lại

                    // Tạo BookID dựa trên CategoryID
                    string bookID = GenerateBookID(categoryID);

                    // Lấy hoặc tạo AuthorID
                    string authorName = txtAuthorName.Text.Trim();
                    string authorID = GetOrCreateAuthorID(authorName, conn);

                    // Lấy hoặc tạo PublisherID
                    string publisherName = txtPublisherName.Text.Trim();
                    string publisherID = GetOrCreatePublisherID(publisherName, conn);

                    // Các thông tin còn lại
                    string bookTitle = txtBookTitle.Text.Trim();
                    int year = int.Parse(txtYear.Text.Trim());
                    int quantity = int.Parse(txtQuantity.Text.Trim());
                    decimal bookValue = decimal.Parse(txtValue.Text.Trim());
                    string bookStatus = "Available"; // Mặc định là Available




                    // Thêm sách vào database
                    string query = "INSERT INTO BookDetails (CategoryID, CategoryName, BookID, BookTitle, AuthorID, AuthorName, PublisherID, PublisherName, Year, Quantity, BookStatus, BookValue, ImagePath) " +
                                   "VALUES (@CategoryID, @CategoryName, @BookID, @BookTitle, @AuthorID, @AuthorName, @PublisherID, @PublisherName, @Year, @Quantity, @BookStatus, @BookValue, @ImagePath)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@CategoryID", categoryID);
                        cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                        cmd.Parameters.AddWithValue("@BookID", bookID);
                        cmd.Parameters.AddWithValue("@BookTitle", bookTitle);
                        cmd.Parameters.AddWithValue("@AuthorID", authorID);
                        cmd.Parameters.AddWithValue("@AuthorName", authorName);
                        cmd.Parameters.AddWithValue("@PublisherID", publisherID);
                        cmd.Parameters.AddWithValue("@PublisherName", publisherName);
                        cmd.Parameters.AddWithValue("@Year", year);
                        cmd.Parameters.AddWithValue("@Quantity", quantity);
                        cmd.Parameters.AddWithValue("@BookStatus", bookStatus);
                        cmd.Parameters.AddWithValue("@BookValue", bookValue);
                        //cmd.Parameters.AddWithValue("@ImagePath", imagePath);
                        cmd.Parameters.AddWithValue("@ImagePath", string.IsNullOrEmpty(imagePath) ? (object)DBNull.Value : imagePath);

                        cmd.ExecuteNonQuery();
                    }

                    MessageBox.Show("Thêm sách thành công!");
                    LoadBookData(); // Cập nhật lại danh sách sách
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm sách: " + ex.Message);
            }
        }

        private string GenerateCategoryID(string categoryName)
        {
            // Kiểm tra nếu chọn "Tất cả" thì báo lỗi
            if (categoryName == "Tất cả")
            {
                MessageBox.Show("Vui lòng chọn một thể loại cụ thể!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return null;
            }

            // Tạo CategoryID bằng cách lấy chữ cái đầu của mỗi từ (VD: "Tình cảm" -> "TC")
            string[] words = categoryName.Split(' ');
            string categoryID = "";
            foreach (string word in words)
            {
                if (!string.IsNullOrEmpty(word))
                    categoryID += char.ToUpper(word[0]); // Lấy ký tự đầu tiên và viết hoa
            }

            return categoryID + "000"; // Luôn gắn "000" vào sau
        }

        private string GenerateBookID(string categoryID)
        {
            string newBookID = "";
            int maxNumber = 0;

            // Kết nối database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT MAX(CAST(SUBSTRING(BookID, 3, LEN(BookID)-2) AS INT)) FROM BookDetails WHERE CategoryID = @CategoryID";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@CategoryID", categoryID);

                // Lấy mã số lớn nhất hiện tại
                object result = cmd.ExecuteScalar();
                if (result != DBNull.Value && result != null)
                {
                    maxNumber = Convert.ToInt32(result);
                }

                // Tăng dần lên 1
                maxNumber++;
            }

            // Ghép thành BookID (VD: TC000 -> TC001, TC002, ...)
            newBookID = categoryID.Substring(0, 2) + maxNumber.ToString("D3"); // Format thành 3 chữ số
            return newBookID;
        }

        private string GetOrCreateAuthorID(string authorName, SqlConnection conn)
        {
            // Kiểm tra nếu tác giả đã tồn tại
            string queryAuthor = "SELECT AuthorID FROM BookDetails WHERE AuthorName = @AuthorName";
            SqlCommand cmd = new SqlCommand(queryAuthor, conn);
            cmd.Parameters.AddWithValue("@AuthorName", authorName);
            object existingAuthorID = cmd.ExecuteScalar();

            if (existingAuthorID != null)
            {
                return existingAuthorID.ToString();
            }

            // Nếu tác giả chưa có, tạo mới AuthorID
            string queryMaxAuthorID = "SELECT MAX(AuthorID) FROM BookDetails WHERE AuthorID LIKE 'AU%'";
            cmd = new SqlCommand(queryMaxAuthorID, conn);
            object maxAuthor = cmd.ExecuteScalar();

            int newAuthorNumber = (maxAuthor != DBNull.Value) ? int.Parse(maxAuthor.ToString().Substring(2)) + 1 : 1;
            return "AU" + newAuthorNumber.ToString("D3");
        }

        private string GetOrCreatePublisherID(string publisherName, SqlConnection conn)
        {
            // Kiểm tra nếu nhà xuất bản đã tồn tại
            string queryPublisher = "SELECT PublisherID FROM BookDetails WHERE PublisherName = @PublisherName";
            SqlCommand cmd = new SqlCommand(queryPublisher, conn);
            cmd.Parameters.AddWithValue("@PublisherName", publisherName);
            object existingPublisherID = cmd.ExecuteScalar();

            if (existingPublisherID != null)
            {
                return existingPublisherID.ToString();
            }

            // Nếu NXB chưa có, tạo mới PublisherID
            string queryMaxPublisherID = "SELECT MAX(PublisherID) FROM BookDetails WHERE PublisherID LIKE 'PB%'";
            cmd = new SqlCommand(queryMaxPublisherID, conn);
            object maxPublisher = cmd.ExecuteScalar();

            int newPublisherNumber = (maxPublisher != DBNull.Value) ? int.Parse(maxPublisher.ToString().Substring(2)) + 1 : 1;
            return "PB" + newPublisherNumber.ToString("D3");
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }
    }
}
