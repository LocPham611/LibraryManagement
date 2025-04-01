namespace LibraryManagement
{
    partial class Reader_Home
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanelBook = new System.Windows.Forms.FlowLayoutPanel();
            this.AddToBookCart = new System.Windows.Forms.Button();
            this.Search = new System.Windows.Forms.Button();
            this.txtCategory = new System.Windows.Forms.ComboBox();
            this.txtBookTitle = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbExtendDays = new System.Windows.Forms.ComboBox();
            this.chkExtendLoan = new System.Windows.Forms.CheckBox();
            this.Remove = new System.Windows.Forms.Button();
            this.Borrow = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dgvBookCart = new System.Windows.Forms.DataGridView();
            this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Quantity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnFineCheck = new System.Windows.Forms.Button();
            this.btnBorrowReturnCheck = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtChangePassword = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lReaderID = new System.Windows.Forms.Label();
            this.lReaderName = new System.Windows.Forms.Label();
            this.lEmail = new System.Windows.Forms.Label();
            this.lAccountStatus = new System.Windows.Forms.Label();
            this.lPhoneNumber = new System.Windows.Forms.Label();
            this.lAddress = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCart)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.tabControl1.Location = new System.Drawing.Point(12, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1900, 961);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.flowLayoutPanelBook);
            this.tabPage1.Controls.Add(this.AddToBookCart);
            this.tabPage1.Controls.Add(this.Search);
            this.tabPage1.Controls.Add(this.txtCategory);
            this.tabPage1.Controls.Add(this.txtBookTitle);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1892, 903);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Search Book   ";
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // flowLayoutPanelBook
            // 
            this.flowLayoutPanelBook.AutoScroll = true;
            this.flowLayoutPanelBook.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flowLayoutPanelBook.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flowLayoutPanelBook.Location = new System.Drawing.Point(3, 247);
            this.flowLayoutPanelBook.Margin = new System.Windows.Forms.Padding(0);
            this.flowLayoutPanelBook.Name = "flowLayoutPanelBook";
            this.flowLayoutPanelBook.Size = new System.Drawing.Size(1886, 653);
            this.flowLayoutPanelBook.TabIndex = 6;
            // 
            // AddToBookCart
            // 
            this.AddToBookCart.Location = new System.Drawing.Point(1408, 164);
            this.AddToBookCart.Name = "AddToBookCart";
            this.AddToBookCart.Size = new System.Drawing.Size(369, 64);
            this.AddToBookCart.TabIndex = 5;
            this.AddToBookCart.Text = "Add To Book Cart";
            this.AddToBookCart.UseVisualStyleBackColor = true;
            this.AddToBookCart.Click += new System.EventHandler(this.AddToBookCart_Click);
            // 
            // Search
            // 
            this.Search.Location = new System.Drawing.Point(1408, 49);
            this.Search.Name = "Search";
            this.Search.Size = new System.Drawing.Size(161, 64);
            this.Search.TabIndex = 4;
            this.Search.Text = "Search";
            this.Search.UseVisualStyleBackColor = true;
            this.Search.Click += new System.EventHandler(this.Search_Click);
            // 
            // txtCategory
            // 
            this.txtCategory.FormattingEnabled = true;
            this.txtCategory.Items.AddRange(new object[] {
            "Tất cả",
            "Thieu nhi",
            "Kinh di",
            "Tam ly",
            "Tinh cam",
            "Bi an",
            "Gia tuong",
            "Lich su"});
            this.txtCategory.Location = new System.Drawing.Point(889, 49);
            this.txtCategory.Name = "txtCategory";
            this.txtCategory.Size = new System.Drawing.Size(386, 53);
            this.txtCategory.TabIndex = 3;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.Location = new System.Drawing.Point(225, 46);
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.Size = new System.Drawing.Size(389, 51);
            this.txtBookTitle.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(712, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(171, 45);
            this.label8.TabIndex = 1;
            this.label8.Text = "Category:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(34, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 45);
            this.label7.TabIndex = 0;
            this.label7.Text = "Book Title:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.cmbExtendDays);
            this.tabPage2.Controls.Add(this.chkExtendLoan);
            this.tabPage2.Controls.Add(this.Remove);
            this.tabPage2.Controls.Add(this.Borrow);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.dgvBookCart);
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1892, 903);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Book Cart   ";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(723, 132);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(178, 38);
            this.label9.TabIndex = 9;
            this.label9.Text = "Extend Days";
            // 
            // cmbExtendDays
            // 
            this.cmbExtendDays.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbExtendDays.FormattingEnabled = true;
            this.cmbExtendDays.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.cmbExtendDays.Location = new System.Drawing.Point(907, 127);
            this.cmbExtendDays.Name = "cmbExtendDays";
            this.cmbExtendDays.Size = new System.Drawing.Size(151, 45);
            this.cmbExtendDays.TabIndex = 8;
            // 
            // chkExtendLoan
            // 
            this.chkExtendLoan.AutoSize = true;
            this.chkExtendLoan.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkExtendLoan.Location = new System.Drawing.Point(534, 128);
            this.chkExtendLoan.Name = "chkExtendLoan";
            this.chkExtendLoan.Size = new System.Drawing.Size(166, 42);
            this.chkExtendLoan.TabIndex = 7;
            this.chkExtendLoan.Text = "Extension";
            this.chkExtendLoan.UseVisualStyleBackColor = true;
            // 
            // Remove
            // 
            this.Remove.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Remove.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Remove.ForeColor = System.Drawing.Color.Transparent;
            this.Remove.Location = new System.Drawing.Point(1366, 120);
            this.Remove.Name = "Remove";
            this.Remove.Size = new System.Drawing.Size(155, 61);
            this.Remove.TabIndex = 6;
            this.Remove.Text = "Remove";
            this.Remove.UseVisualStyleBackColor = false;
            this.Remove.Click += new System.EventHandler(this.Remove_Click);
            // 
            // Borrow
            // 
            this.Borrow.BackColor = System.Drawing.Color.LightSeaGreen;
            this.Borrow.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Borrow.ForeColor = System.Drawing.Color.Transparent;
            this.Borrow.Location = new System.Drawing.Point(1156, 120);
            this.Borrow.Name = "Borrow";
            this.Borrow.Size = new System.Drawing.Size(155, 61);
            this.Borrow.TabIndex = 5;
            this.Borrow.Text = "Borrow";
            this.Borrow.UseVisualStyleBackColor = false;
            this.Borrow.Click += new System.EventHandler(this.Borrow_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(732, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(246, 62);
            this.label6.TabIndex = 4;
            this.label6.Text = "Book Cart";
            // 
            // dgvBookCart
            // 
            this.dgvBookCart.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvBookCart.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvBookCart.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvBookCart.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBookCart.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookID,
            this.BookTitle,
            this.Author,
            this.Category,
            this.Quantity});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvBookCart.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgvBookCart.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dgvBookCart.Location = new System.Drawing.Point(3, 225);
            this.dgvBookCart.Name = "dgvBookCart";
            this.dgvBookCart.RowHeadersWidth = 51;
            this.dgvBookCart.RowTemplate.Height = 24;
            this.dgvBookCart.Size = new System.Drawing.Size(1886, 675);
            this.dgvBookCart.TabIndex = 3;
            // 
            // BookID
            // 
            this.BookID.HeaderText = "Book ID";
            this.BookID.MinimumWidth = 6;
            this.BookID.Name = "BookID";
            // 
            // BookTitle
            // 
            this.BookTitle.HeaderText = "Book Title";
            this.BookTitle.MinimumWidth = 6;
            this.BookTitle.Name = "BookTitle";
            // 
            // Author
            // 
            this.Author.HeaderText = "Author";
            this.Author.MinimumWidth = 6;
            this.Author.Name = "Author";
            // 
            // Category
            // 
            this.Category.HeaderText = "Category";
            this.Category.MinimumWidth = 6;
            this.Category.Name = "Category";
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Quantity";
            this.Quantity.MinimumWidth = 6;
            this.Quantity.Name = "Quantity";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnFineCheck);
            this.tabPage3.Controls.Add(this.btnBorrowReturnCheck);
            this.tabPage3.Location = new System.Drawing.Point(4, 54);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1892, 903);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Borrow & Return   ";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnFineCheck
            // 
            this.btnFineCheck.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFineCheck.ForeColor = System.Drawing.Color.Transparent;
            this.btnFineCheck.Location = new System.Drawing.Point(964, 312);
            this.btnFineCheck.Name = "btnFineCheck";
            this.btnFineCheck.Size = new System.Drawing.Size(321, 114);
            this.btnFineCheck.TabIndex = 1;
            this.btnFineCheck.Text = "Fine Check";
            this.btnFineCheck.UseVisualStyleBackColor = false;
            this.btnFineCheck.Click += new System.EventHandler(this.btnFineCheck_Click_1);
            // 
            // btnBorrowReturnCheck
            // 
            this.btnBorrowReturnCheck.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnBorrowReturnCheck.ForeColor = System.Drawing.Color.Transparent;
            this.btnBorrowReturnCheck.Location = new System.Drawing.Point(477, 312);
            this.btnBorrowReturnCheck.Name = "btnBorrowReturnCheck";
            this.btnBorrowReturnCheck.Size = new System.Drawing.Size(321, 114);
            this.btnBorrowReturnCheck.TabIndex = 0;
            this.btnBorrowReturnCheck.Text = "Borrow - Return Check";
            this.btnBorrowReturnCheck.UseVisualStyleBackColor = false;
            this.btnBorrowReturnCheck.Click += new System.EventHandler(this.btnBorrowReturnCheck_Click_1);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnLogOut);
            this.tabPage4.Controls.Add(this.btnUpdate);
            this.tabPage4.Controls.Add(this.label5);
            this.tabPage4.Controls.Add(this.label4);
            this.tabPage4.Controls.Add(this.txtChangePassword);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.label13);
            this.tabPage4.Controls.Add(this.label12);
            this.tabPage4.Controls.Add(this.label11);
            this.tabPage4.Controls.Add(this.label10);
            this.tabPage4.Controls.Add(this.lReaderID);
            this.tabPage4.Controls.Add(this.lReaderName);
            this.tabPage4.Controls.Add(this.lEmail);
            this.tabPage4.Controls.Add(this.lAccountStatus);
            this.tabPage4.Controls.Add(this.lPhoneNumber);
            this.tabPage4.Controls.Add(this.lAddress);
            this.tabPage4.Controls.Add(this.label3);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 54);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1892, 903);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Account   ";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnLogOut
            // 
            this.btnLogOut.Location = new System.Drawing.Point(1721, 3);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(175, 53);
            this.btnLogOut.TabIndex = 36;
            this.btnLogOut.Text = "Log out";
            this.btnLogOut.UseVisualStyleBackColor = true;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click_2);
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnUpdate.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpdate.ForeColor = System.Drawing.Color.Transparent;
            this.btnUpdate.Location = new System.Drawing.Point(1408, 558);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(143, 59);
            this.btnUpdate.TabIndex = 35;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = false;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click_1);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(550, 776);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(525, 46);
            this.label5.TabIndex = 34;
            this.label5.Text = "Smart Library System helps readers easily borrow/return books,\r\n receive due date" +
    " reminders, and pay fines online.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(342, 776);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(190, 38);
            this.label4.TabIndex = 33;
            this.label4.Text = "Introduction:";
            // 
            // txtChangePassword
            // 
            this.txtChangePassword.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChangePassword.Location = new System.Drawing.Point(900, 566);
            this.txtChangePassword.Name = "txtChangePassword";
            this.txtChangePassword.Size = new System.Drawing.Size(443, 43);
            this.txtChangePassword.TabIndex = 32;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(256, 317);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(201, 38);
            this.label14.TabIndex = 31;
            this.label14.Text = "Reader Name:";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1234, 317);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(129, 38);
            this.label13.TabIndex = 30;
            this.label13.Text = "Address:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1141, 218);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(222, 38);
            this.label12.TabIndex = 29;
            this.label12.Text = "Account Status:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(360, 420);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 38);
            this.label11.TabIndex = 28;
            this.label11.Text = "Email:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(1138, 420);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(225, 38);
            this.label10.TabIndex = 27;
            this.label10.Text = "Phone Number:";
            // 
            // lReaderID
            // 
            this.lReaderID.AutoSize = true;
            this.lReaderID.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReaderID.Location = new System.Drawing.Point(467, 218);
            this.lReaderID.Name = "lReaderID";
            this.lReaderID.Size = new System.Drawing.Size(65, 38);
            this.lReaderID.TabIndex = 26;
            this.lReaderID.Text = "RID";
            // 
            // lReaderName
            // 
            this.lReaderName.AutoSize = true;
            this.lReaderName.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lReaderName.Location = new System.Drawing.Point(467, 317);
            this.lReaderName.Name = "lReaderName";
            this.lReaderName.Size = new System.Drawing.Size(57, 38);
            this.lReaderName.TabIndex = 25;
            this.lReaderName.Text = "RN";
            // 
            // lEmail
            // 
            this.lEmail.AutoSize = true;
            this.lEmail.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEmail.Location = new System.Drawing.Point(467, 420);
            this.lEmail.Name = "lEmail";
            this.lEmail.Size = new System.Drawing.Size(32, 38);
            this.lEmail.TabIndex = 24;
            this.lEmail.Text = "E";
            // 
            // lAccountStatus
            // 
            this.lAccountStatus.AutoSize = true;
            this.lAccountStatus.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAccountStatus.Location = new System.Drawing.Point(1380, 218);
            this.lAccountStatus.Name = "lAccountStatus";
            this.lAccountStatus.Size = new System.Drawing.Size(53, 38);
            this.lAccountStatus.TabIndex = 23;
            this.lAccountStatus.Text = "AS";
            // 
            // lPhoneNumber
            // 
            this.lPhoneNumber.AutoSize = true;
            this.lPhoneNumber.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPhoneNumber.Location = new System.Drawing.Point(1380, 420);
            this.lPhoneNumber.Name = "lPhoneNumber";
            this.lPhoneNumber.Size = new System.Drawing.Size(56, 38);
            this.lPhoneNumber.TabIndex = 22;
            this.lPhoneNumber.Text = "PN";
            // 
            // lAddress
            // 
            this.lAddress.AutoSize = true;
            this.lAddress.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAddress.Location = new System.Drawing.Point(1380, 317);
            this.lAddress.Name = "lAddress";
            this.lAddress.Size = new System.Drawing.Size(37, 38);
            this.lAddress.TabIndex = 21;
            this.lAddress.Text = "A";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(614, 569);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 38);
            this.label3.TabIndex = 20;
            this.label3.Text = "Change Password:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(304, 218);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 38);
            this.label2.TabIndex = 19;
            this.label2.Text = "Reader ID:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(889, 81);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(383, 62);
            this.label1.TabIndex = 18;
            this.label1.Text = "Readr\'s Account";
            // 
            // Reader_Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.ke_sach_2;
            this.ClientSize = new System.Drawing.Size(1924, 980);
            this.Controls.Add(this.tabControl1);
            this.Name = "Reader_Home";
            this.Text = "Reader_Home";
            this.Load += new System.EventHandler(this.Reader_Home_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBookCart)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbExtendDays;
        private System.Windows.Forms.CheckBox chkExtendLoan;
        private System.Windows.Forms.Button Remove;
        private System.Windows.Forms.Button Borrow;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgvBookCart;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnFineCheck;
        private System.Windows.Forms.Button btnBorrowReturnCheck;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtChangePassword;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lReaderID;
        private System.Windows.Forms.Label lReaderName;
        private System.Windows.Forms.Label lEmail;
        private System.Windows.Forms.Label lAccountStatus;
        private System.Windows.Forms.Label lPhoneNumber;
        private System.Windows.Forms.Label lAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelBook;
        private System.Windows.Forms.Button AddToBookCart;
        private System.Windows.Forms.Button Search;
        private System.Windows.Forms.ComboBox txtCategory;
        private System.Windows.Forms.TextBox txtBookTitle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookID;
        private System.Windows.Forms.DataGridViewTextBoxColumn BookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Quantity;
    }
}