namespace LibraryManagement
{
    partial class Librarian_ReaderList
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
            this.dGVReaderList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.gbAccountStatus = new System.Windows.Forms.GroupBox();
            this.chkbLocked = new System.Windows.Forms.CheckBox();
            this.chkbValid = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dGVReaderList)).BeginInit();
            this.gbAccountStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // dGVReaderList
            // 
            this.dGVReaderList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dGVReaderList.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dGVReaderList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dGVReaderList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVReaderList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column10,
            this.Column7,
            this.Column8});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dGVReaderList.DefaultCellStyle = dataGridViewCellStyle2;
            this.dGVReaderList.GridColor = System.Drawing.SystemColors.ActiveBorder;
            this.dGVReaderList.Location = new System.Drawing.Point(42, 389);
            this.dGVReaderList.Name = "dGVReaderList";
            this.dGVReaderList.RowHeadersWidth = 51;
            this.dGVReaderList.RowTemplate.Height = 24;
            this.dGVReaderList.Size = new System.Drawing.Size(1941, 561);
            this.dGVReaderList.TabIndex = 2;
            this.dGVReaderList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dGVReaderList_CellContentClick);
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
            this.Column4.HeaderText = "Reader Address";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Reader Phon Number";
            this.Column5.MinimumWidth = 6;
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Reader Email";
            this.Column6.MinimumWidth = 6;
            this.Column6.Name = "Column6";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "ReaderPassword";
            this.Column10.MinimumWidth = 6;
            this.Column10.Name = "Column10";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Gender";
            this.Column7.MinimumWidth = 6;
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "AccountStatus";
            this.Column8.MinimumWidth = 6;
            this.Column8.Name = "Column8";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 28.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(608, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(269, 62);
            this.label1.TabIndex = 3;
            this.label1.Text = "Reader List";
            // 
            // gbAccountStatus
            // 
            this.gbAccountStatus.Controls.Add(this.chkbLocked);
            this.gbAccountStatus.Controls.Add(this.chkbValid);
            this.gbAccountStatus.Location = new System.Drawing.Point(1221, 307);
            this.gbAccountStatus.Name = "gbAccountStatus";
            this.gbAccountStatus.Size = new System.Drawing.Size(254, 63);
            this.gbAccountStatus.TabIndex = 9;
            this.gbAccountStatus.TabStop = false;
            this.gbAccountStatus.Text = "Account Status";
            // 
            // chkbLocked
            // 
            this.chkbLocked.AutoSize = true;
            this.chkbLocked.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbLocked.Location = new System.Drawing.Point(140, 21);
            this.chkbLocked.Name = "chkbLocked";
            this.chkbLocked.Size = new System.Drawing.Size(108, 35);
            this.chkbLocked.TabIndex = 6;
            this.chkbLocked.Text = "Locked";
            this.chkbLocked.UseVisualStyleBackColor = true;
            // 
            // chkbValid
            // 
            this.chkbValid.AutoSize = true;
            this.chkbValid.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.chkbValid.Location = new System.Drawing.Point(6, 21);
            this.chkbValid.Name = "chkbValid";
            this.chkbValid.Size = new System.Drawing.Size(86, 35);
            this.chkbValid.TabIndex = 5;
            this.chkbValid.Text = "Valid";
            this.chkbValid.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Transparent;
            this.btnSave.Location = new System.Drawing.Point(1752, 307);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(137, 50);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.BackColor = System.Drawing.Color.LightSeaGreen;
            this.btnFilter.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFilter.ForeColor = System.Drawing.Color.Transparent;
            this.btnFilter.Location = new System.Drawing.Point(1014, 307);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(137, 50);
            this.btnFilter.TabIndex = 14;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = false;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // btnClose
            // 
            this.btnClose.BackColor = System.Drawing.Color.Red;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(1837, -2);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(89, 47);
            this.btnClose.TabIndex = 17;
            this.btnClose.Text = "X";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // Librarian_ReaderList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::LibraryManagement.Properties.Resources.ke_sach_1;
            this.ClientSize = new System.Drawing.Size(1924, 980);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnFilter);
            this.Controls.Add(this.gbAccountStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dGVReaderList);
            this.Name = "Librarian_ReaderList";
            this.Text = "Librarian_ReaderList";
            this.Load += new System.EventHandler(this.Librarian_ReaderList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVReaderList)).EndInit();
            this.gbAccountStatus.ResumeLayout(false);
            this.gbAccountStatus.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVReaderList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.GroupBox gbAccountStatus;
        private System.Windows.Forms.CheckBox chkbLocked;
        private System.Windows.Forms.CheckBox chkbValid;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnFilter;
        private System.Windows.Forms.Button btnClose;
    }
}