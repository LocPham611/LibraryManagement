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
    public partial class Librarian_FineList : Form
    {
        //string connectionString = @"Server=VIKEY;Database=Li;Integrated Security=True;TrustServerCertificate=True;";
        string connectionString = "Server=LAPTOP-M5VAIMCO;Database=Li2;Integrated Security=True;Encrypt=True;TrustServerCertificate=True;MultipleActiveResultSets=True;";
        SqlConnection connection;
        public Librarian_FineList()
        {
            InitializeComponent();
        }

        private void LoadFineReceiptDetails()
        {
            dGVFineReceiptsList.Columns.Clear();
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT * " +
                                   "FROM FineReceiptDetails";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dGVFineReceiptsList.DataSource = dt;

                    // Xóa cột PaymentStatus cũ và thêm mới bằng ComboBoxColumn
                    DataGridViewComboBoxColumn comboBoxColumn = new DataGridViewComboBoxColumn();
                    comboBoxColumn.Name = "PaymentStatus";
                    comboBoxColumn.HeaderText = "Payment Status";
                    comboBoxColumn.DataSource = new string[] { "Paid", "Not Paid" }; // Giá trị trong ComboBox
                    comboBoxColumn.DataPropertyName = "PaymentStatus"; // Gắn với dữ liệu trong DataTable
                    comboBoxColumn.FlatStyle = FlatStyle.Flat;

                    dGVFineReceiptsList.Columns.Remove("PaymentStatus");
                    dGVFineReceiptsList.Columns.Add(comboBoxColumn); // Thêm cột ComboBox mới
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        private void Librarian_FineList_Load(object sender, EventArgs e)
        {
            LoadFineReceiptDetails();
            dGVFineReceiptsList.CellValueChanged += dGVFineReceiptsList_CellValueChanged;
        }


        private void dGVFineReceiptsList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dGVFineReceiptsList.Columns[e.ColumnIndex].Name == "PaymentStatus")
            {
                // Lấy FineReceiptID và PaymentStatus mới
                string fineReceiptID = dGVFineReceiptsList.Rows[e.RowIndex].Cells["FineReceiptID"].Value.ToString();
                string paymentStatus = dGVFineReceiptsList.Rows[e.RowIndex].Cells["PaymentStatus"].Value.ToString();

                // Cập nhật thông tin vào cơ sở dữ liệu
                UpdatePaymentStatus(fineReceiptID, paymentStatus);
            }
        }


        private void UpdatePaymentStatus(string fineReceiptID, string paymentStatus)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "UPDATE FineReceiptDetails SET PaymentStatus = @PaymentStatus WHERE FineReceiptID = @FineReceiptID";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@FineReceiptID", fineReceiptID);
                        cmd.Parameters.AddWithValue("@PaymentStatus", paymentStatus);
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Payment status updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error while updating payment status: " + ex.Message);
            }
        }


        private void dGVFineReceiptsList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnFilter_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // Tạo truy vấn động
                    StringBuilder query = new StringBuilder("SELECT *" +
                                                            "FROM FineReceiptDetails " +
                                                            "WHERE 1=1");

                    if (chkbPaid.Checked)
                        query.Append(" AND PaymentStatus = 'Paid'");
                    if (chkbNotPaid.Checked)
                        query.Append(" AND PaymentStatus = 'Not Paid'");

                    // Thực thi truy vấn
                    SqlDataAdapter adapter = new SqlDataAdapter(query.ToString(), conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dGVFineReceiptsList.DataSource = dt; // Gán dữ liệu lọc vào DataGridView
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
