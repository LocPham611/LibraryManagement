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

namespace LibraryManagement
{
    public partial class Librarian_ReaderList : Form
    {
        //string connectionString = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectionString = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        SqlConnection connection;
        public Librarian_ReaderList()
        {
            InitializeComponent();
        }

        private void Librarian_ReaderList_Load(object sender, EventArgs e)
        {
            LoadReaderList();
            dGVReaderList.CellValueChanged += dGVReaderList_CellValueChanged;
        }

        private void LoadReaderList()
        {
            // Xóa các cột cũ nếu có
            dGVReaderList.Columns.Clear();

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"SELECT *
                            FROM ReaderDetails";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    // Gán dữ liệu vào DataGridView
                    dGVReaderList.DataSource = dt;

                    // Xóa cột PaymentStatus cũ và thêm mới bằng ComboBoxColumn
                    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                    comboBoxColumn.Name = "AccountStatus";
                    comboBoxColumn.HeaderText = "Account Status";
                    comboBoxColumn.DataSource = new string[]
                    {
                        "Valid", "Locked"
                    }; // Giá trị trong ComboBox
                    comboBoxColumn.DataPropertyName = "AccountStatus"; // Gắn với dữ liệu trong DataTable
                    comboBoxColumn.FlatStyle = FlatStyle.Flat;

                    dGVReaderList.Columns.Remove("AccountStatus");
                    dGVReaderList.Columns.Add(comboBoxColumn); // Thêm cột ComboBox mới

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void dGVReaderList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVReaderList.Columns[e.ColumnIndex].Name == "AccountStatus")
            {
                // Lấy FineReceiptID và PaymentStatus mới
                string readerID = dGVReaderList.Rows[e.RowIndex].Cells["ReaderID"].Value.ToString();
                string accountStatus = dGVReaderList.Rows[e.RowIndex].Cells["AccountStatus"].Value.ToString();

                // Cập nhật thông tin vào cơ sở dữ liệu
                UpdateAccountStatus(readerID, accountStatus);
            }
        }

        private void UpdateAccountStatus(string readerID, string accountStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE ReaderDetails SET AccountStatus = @AccountStatus WHERE ReaderID = @ReaderID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@ReaderID", readerID);
                        cmd.Parameters.AddWithValue("@AccountStatus", accountStatus);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Account status updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating account status: " + ex.Message);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo truy vấn động
                    StringBuilder query = new StringBuilder("SELECT *" +
                                                            "FROM ReaderDetails " +
                                                            "WHERE 1=1");

                    if (chkbValid.Checked)
                        query.Append(" AND AccountStatus = 'Valid'");
                    if (chkbLocked.Checked)
                        query.Append(" AND AccountStatus = 'Locked'");

                    // Thực thi truy vấn
                    SqlDataAdapter adapter = new SqlDataAdapter(query.ToString(), conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dGVReaderList.DataSource = dt; // Gán dữ liệu lọc vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    foreach (DataGridViewRow row in dGVReaderList.Rows)
                    {
                        // Kiểm tra nếu hàng hợp lệ và chứa dữ liệu
                        if (row.Cells["ReaderID"].Value != null && row.Cells["AccountStatus"].Value != null)
                        {
                            string readerID = row.Cells["ReaderID"].Value.ToString();
                            string accountStatus = row.Cells["AccountStatus"].Value.ToString();

                            string query = "UPDATE FineReceiptDetails SET AccountStatus = @AccountStatus WHERE ReaderID = @ReaderID";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ReaderID", readerID);
                                cmd.Parameters.AddWithValue("@AccountStatus", accountStatus);
                                cmd.ExecuteNonQuery();
                            }
                        }
                    }
                    MessageBox.Show("Account status updated successfully!");
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

        private void dGVReaderList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
