using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class BookItem : UserControl
    {
        private Dictionary<string, object> bookData;
        private CheckBox chkSelect;
        public BookItem()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        public void SetBookInfo(Dictionary<string, object> book)
        {

            Title.Text = book["Title"].ToString();
            Author.Text = "Tác Giả: " + book["Author"].ToString();
            Category.Text = "Thể Loại: " + book["Category"].ToString();
            string projectRoot = AppDomain.CurrentDomain.BaseDirectory;
            string imageFolder = Path.Combine(projectRoot, "Images"); // Thư mục gốc chứa ảnh
            string imageFile = book["Image"].ToString();

            // Nếu dữ liệu đã có "Images\" thì bỏ đi
            if (imageFile.StartsWith("Images\\"))
                imageFile = imageFile.Substring(7);

            string imagePath = Path.Combine(imageFolder, imageFile);

            // 🛠 Kiểm tra đường dẫn ảnh
            Console.WriteLine("Đường dẫn ảnh: " + imagePath);

            if (File.Exists(imagePath))
            {
                picCover.Image = Image.FromFile(imagePath);
            }
            else
            {
                Console.WriteLine("⚠ Ảnh không tồn tại: " + imagePath);
                //picCover.Image = Image.FromFile(Path.Combine(imageFolder, "default.jpg")); // Ảnh mặc định
            }
            this.bookData = book;
        }

        public bool IsSelected()
        {
            return Chon.Checked;
        }

        public Dictionary<string, object> GetBookData()
        {
            return bookData;
        }

        public void Deselect()
        {
            Chon.Checked = false;
        }
    }
}
