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
    public partial class Reader_FineCheck : Form
    {
        //string connectionString = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectionString = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        private string ReaderID;

        public Reader_FineCheck(string loggedInUserID)
        {
            InitializeComponent();
            this.ReaderID = loggedInUserID;
            LoadLichSuPhat();
        }

        private void LoadLichSuPhat()
        {
            if (string.IsNullOrWhiteSpace(ReaderID))
            {
                MessageBox.Show("Lỗi: ReaderID không hợp lệ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string query = @"
            SELECT FineReceiptID, BorrowingReceiptID, 
                   Reason, Fee, PaymentStatus
            FROM FineReceiptDetails
            WHERE ReaderID = @ReaderID";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                dGVBorrowReturnCheck.Columns.Clear();
                try
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ReaderID", SqlDbType.NVarChar, 10).Value = ReaderID.Trim();

                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            DataTable dt = new DataTable();
                            da.Fill(dt);

                            // Kiểm tra lại DataGridView, nếu có tên khác thì cần đổi lại
                            dGVBorrowReturnCheck.DataSource = null; // Xóa dữ liệu cũ trước khi load mới

                            if (dt.Rows.Count > 0)
                            {
                                dGVBorrowReturnCheck.DataSource = dt;
                            }
                            else
                            {
                                MessageBox.Show("Tài khoản không có lịch sử phạt.", "Notify", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Reader_FineCheck_Load(object sender, EventArgs e)
        {
            LoadLichSuPhat();
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
