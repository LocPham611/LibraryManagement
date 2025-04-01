namespace LibraryManagement
{
    partial class Librarian_FineList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.dGVFineReceiptsList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbPaymentStatus = new System.Windows.Forms.GroupBox();
            this.chkbNotPaid = new System.Windows.Forms.CheckBox();
            this.chkbPaid = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVFineReceiptsList)).BeginInit();
            this.gbPaymentStatus.SuspendLayout();
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
            this.label1.Size = new System.Drawing.Size(403, 62);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fine Receipts List";
            // 
            // dGVFineReceiptsList
            // 
            this.dGVFineReceiptsList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVFineReceiptsList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVFineReceiptsList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dGVFineReceiptsList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVFineReceiptsList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column6,
            this.Column5,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVFineReceiptsList.DefaultCellStyle = dataGridViewCellStyle6;
            this.dGVFineReceiptsList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dGVFineReceiptsList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dGVFineReceiptsList.Location = new System.Drawing.Point(42, 389);
            this.dGVFineReceiptsList.Name = "dGVFineReceiptsList";
            this.dGVFineReceiptsList.RowHeadersWidth = 51;
            this.dGVFineReceiptsList.RowTemplate.Height = 24;
            this.dGVFineReceiptsList.Size = new System.Drawing.Size(2000, 561);
            this.dGVFineReceiptsList.TabIndex = 2;
            this.dGVFineReceiptsList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVFineReceiptsList_CellContentClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "Fine ID";
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
            this.Column4.HeaderText = "Borrowing Receipt ID";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Reason";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Late Days";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Fee";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Payment Status ";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // gbPaymentStatus
            // 
            this.gbPaymentStatus.Controls.Add(this.chkbNotPaid);
            this.gbPaymentStatus.Controls.Add(this.chkbPaid);
            this.gbPaymentStatus.Location = new System.Drawing.Point(1095, 294);
            this.gbPaymentStatus.Name = "gbPaymentStatus";
            this.gbPaymentStatus.Size = new System.Drawing.Size(309, 74);
            this.gbPaymentStatus.TabIndex = 9;
            this.gbPaymentStatus.TabStop = false;
            this.gbPaymentStatus.Text = "Payment Status";
            // 
            // chkbNotPaid
            // 
            this.chkbNotPaid.AutoSize = true;
            this.chkbNotPaid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbNotPaid.Location = new System.Drawing.Point(159, 25);
            this.chkbNotPaid.Name = "chkbNotPaid";
            this.chkbNotPaid.Size = new System.Drawing.Size(110, 32);
            this.chkbNotPaid.TabIndex = 6;
            this.chkbNotPaid.Text = "Not Paid";
            this.chkbNotPaid.UseVisualStyleBackColor = true;
            // 
            // chkbPaid
            // 
            this.chkbPaid.AutoSize = true;
            this.chkbPaid.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbPaid.Location = new System.Drawing.Point(61, 25);
            this.chkbPaid.Name = "chkbPaid";
            this.chkbPaid.Size = new System.Drawing.Size(71, 32);
            this.chkbPaid.TabIndex = 5;
            this.chkbPaid.Text = "Paid";
            this.chkbPaid.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(1733, 313);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 50);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click_1);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Transparent;
            this.btnFilter.Location = new System.Drawing.Point(940, 313);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(137, 50);
            this.btnFilter.TabIndex = 15;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click_1);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1837, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 47);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Librarian_FineList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.ke_sach_1;
            this.ClientSize = new System.Drawing.Size(1924, 980);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.gbPaymentStatus);
            this.Controls.Add(this.dGVFineReceiptsList);
            this.Controls.Add(this.label1);
            this.Name = "Librarian_FineList";
            this.Text = "Librarian_FineList";
            this.Load += new System.EventHandler(this.Librarian_FineList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVFineReceiptsList)).EndInit();
            this.gbPaymentStatus.ResumeLayout(false);
            this.gbPaymentStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dGVFineReceiptsList;
        private System.Windows.Forms.GroupBox gbPaymentStatus;
        private System.Windows.Forms.CheckBox chkbNotPaid;
        private System.Windows.Forms.CheckBox chkbPaid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnClose;
    }
}