namespace LibraryManagement
{
    partial class Librarian_BorrowingList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVBorrowingReceiptsList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.chkbYes = new System.Windows.Forms.CheckBox();
            this.chkbNo = new System.Windows.Forms.CheckBox();
            this.gbExtensionOption = new System.Windows.Forms.GroupBox();
            this.chkbPending = new System.Windows.Forms.CheckBox();
            this.chkbBorrowed = new System.Windows.Forms.CheckBox();
            this.chkbReturned = new System.Windows.Forms.CheckBox();
            this.gbBorrowingReceiptStatus = new System.Windows.Forms.GroupBox();
            this.chkbLated = new System.Windows.Forms.CheckBox();
            this.chkbCanceled = new System.Windows.Forms.CheckBox();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVBorrowingReceiptsList)).BeginInit();
            this.gbExtensionOption.SuspendLayout();
            this.gbBorrowingReceiptStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(608, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(546, 62);
            this.label1.TabIndex = 0;
            this.label1.Text = "Borrowing Receipts List";
            // 
            // dGVBorrowingReceiptsList
            // 
            this.dGVBorrowingReceiptsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVBorrowingReceiptsList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVBorrowingReceiptsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVBorrowingReceiptsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVBorrowingReceiptsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column8,
            this.Column9});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVBorrowingReceiptsList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVBorrowingReceiptsList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dGVBorrowingReceiptsList.Location = new System.Drawing.Point(42, 389);
            this.dGVBorrowingReceiptsList.Name = "dGVBorrowingReceiptsList";
            this.dGVBorrowingReceiptsList.RowHeadersWidth = 51;
            this.dGVBorrowingReceiptsList.RowTemplate.Height = 24;
            this.dGVBorrowingReceiptsList.Size = new System.Drawing.Size(2000, 561);
            this.dGVBorrowingReceiptsList.TabIndex = 1;
            this.dGVBorrowingReceiptsList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVBorrowingReceiptsList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Borrowing Receipt ID";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Reader ID";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Reader Name";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Borrowing Date";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Return Date";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Borrowed Books ID";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Borrowed Books Title";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Borrowing Receipt Status";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Extension Option";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Extension Days";
            this.Column9.MinimumWidth = 6;
            this.Column9.Name = "Column9";
            // 
            // chkbYes
            // 
            this.chkbYes.AutoSize = true;
            this.chkbYes.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbYes.Location = new System.Drawing.Point(73, 25);
            this.chkbYes.Name = "chkbYes";
            this.chkbYes.Size = new System.Drawing.Size(69, 35);
            this.chkbYes.TabIndex = 5;
            this.chkbYes.Text = "Yes";
            this.chkbYes.UseVisualStyleBackColor = true;
            // 
            // chkbNo
            // 
            this.chkbNo.AutoSize = true;
            this.chkbNo.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbNo.Location = new System.Drawing.Point(73, 61);
            this.chkbNo.Name = "chkbNo";
            this.chkbNo.Size = new System.Drawing.Size(66, 35);
            this.chkbNo.TabIndex = 6;
            this.chkbNo.Text = "No";
            this.chkbNo.UseVisualStyleBackColor = true;
            // 
            // gbExtensionOption
            // 
            this.gbExtensionOption.Controls.Add(this.chkbNo);
            this.gbExtensionOption.Controls.Add(this.chkbYes);
            this.gbExtensionOption.Location = new System.Drawing.Point(1243, 255);
            this.gbExtensionOption.Name = "gbExtensionOption";
            this.gbExtensionOption.Size = new System.Drawing.Size(176, 111);
            this.gbExtensionOption.TabIndex = 8;
            this.gbExtensionOption.TabStop = false;
            this.gbExtensionOption.Text = "Extension Option";
            // 
            // chkbPending
            // 
            this.chkbPending.AutoSize = true;
            this.chkbPending.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbPending.Location = new System.Drawing.Point(25, 25);
            this.chkbPending.Name = "chkbPending";
            this.chkbPending.Size = new System.Drawing.Size(120, 35);
            this.chkbPending.TabIndex = 2;
            this.chkbPending.Text = "Pending";
            this.chkbPending.UseVisualStyleBackColor = true;
            // 
            // chkbBorrowed
            // 
            this.chkbBorrowed.AutoSize = true;
            this.chkbBorrowed.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbBorrowed.Location = new System.Drawing.Point(176, 25);
            this.chkbBorrowed.Name = "chkbBorrowed";
            this.chkbBorrowed.Size = new System.Drawing.Size(134, 35);
            this.chkbBorrowed.TabIndex = 3;
            this.chkbBorrowed.Text = "Borrowed";
            this.chkbBorrowed.UseVisualStyleBackColor = true;
            // 
            // chkbReturned
            // 
            this.chkbReturned.AutoSize = true;
            this.chkbReturned.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbReturned.Location = new System.Drawing.Point(176, 66);
            this.chkbReturned.Name = "chkbReturned";
            this.chkbReturned.Size = new System.Drawing.Size(129, 35);
            this.chkbReturned.TabIndex = 4;
            this.chkbReturned.Text = "Returned";
            this.chkbReturned.UseVisualStyleBackColor = true;
            // 
            // gbBorrowingReceiptStatus
            // 
            this.gbBorrowingReceiptStatus.Controls.Add(this.chkbLated);
            this.gbBorrowingReceiptStatus.Controls.Add(this.chkbCanceled);
            this.gbBorrowingReceiptStatus.Controls.Add(this.chkbReturned);
            this.gbBorrowingReceiptStatus.Controls.Add(this.chkbBorrowed);
            this.gbBorrowingReceiptStatus.Controls.Add(this.chkbPending);
            this.gbBorrowingReceiptStatus.Location = new System.Drawing.Point(776, 255);
            this.gbBorrowingReceiptStatus.Name = "gbBorrowingReceiptStatus";
            this.gbBorrowingReceiptStatus.Size = new System.Drawing.Size(452, 111);
            this.gbBorrowingReceiptStatus.TabIndex = 7;
            this.gbBorrowingReceiptStatus.TabStop = false;
            this.gbBorrowingReceiptStatus.Text = "Borrowing Receipt Status";
            // 
            // chkbLated
            // 
            this.chkbLated.AutoSize = true;
            this.chkbLated.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbLated.Location = new System.Drawing.Point(316, 25);
            this.chkbLated.Name = "chkbLated";
            this.chkbLated.Size = new System.Drawing.Size(93, 35);
            this.chkbLated.TabIndex = 6;
            this.chkbLated.Text = "Lated";
            this.chkbLated.UseVisualStyleBackColor = true;
            // 
            // chkbCanceled
            // 
            this.chkbCanceled.AutoSize = true;
            this.chkbCanceled.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbCanceled.Location = new System.Drawing.Point(25, 66);
            this.chkbCanceled.Name = "chkbCanceled";
            this.chkbCanceled.Size = new System.Drawing.Size(130, 35);
            this.chkbCanceled.TabIndex = 5;
            this.chkbCanceled.Text = "Canceled";
            this.chkbCanceled.UseVisualStyleBackColor = true;
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Transparent;
            this.btnFilter.Location = new System.Drawing.Point(619, 309);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(137, 50);
            this.btnFilter.TabIndex = 9;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click_1);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(1720, 309);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 50);
            this.btnSave.TabIndex = 13;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1837, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 47);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Librarian_BorrowingList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.ke_sach_1;
            this.ClientSize = new System.Drawing.Size(1924, 980);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.gbExtensionOption);
            this.Controls.Add(this.gbBorrowingReceiptStatus);
            this.Controls.Add(this.dGVBorrowingReceiptsList);
            this.Controls.Add(this.label1);
            this.Name = "Librarian_BorrowingList";
            this.Text = "Librarian_BorrowingList";
            this.Load += new System.EventHandler(this.Librarian_BorrowingList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVBorrowingReceiptsList)).EndInit();
            this.gbExtensionOption.ResumeLayout(false);
            this.gbExtensionOption.PerformLayout();
            this.gbBorrowingReceiptStatus.ResumeLayout(false);
            this.gbBorrowingReceiptStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVBorrowingReceiptsList;
        private System.Windows.Forms.CheckBox chkbYes;
        private System.Windows.Forms.CheckBox chkbNo;
        private System.Windows.Forms.GroupBox gbExtensionOption;
        private System.Windows.Forms.CheckBox chkbPending;
        private System.Windows.Forms.CheckBox chkbBorrowed;
        private System.Windows.Forms.CheckBox chkbReturned;
        private System.Windows.Forms.GroupBox gbBorrowingReceiptStatus;
        private System.Windows.Forms.CheckBox chkbCanceled;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkbLated;
        private System.Windows.Forms.Button btnClose;
    }
}