namespace LibraryManagement
{
    partial class BookItem
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.picCover = new System.Windows.Forms.PictureBox();
            this.Title = new System.Windows.Forms.Label();
            this.Author = new System.Windows.Forms.Label();
            this.Category = new System.Windows.Forms.Label();
            this.Chon = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            this.SuspendLayout();
            // 
            // picCover
            // 
            this.picCover.Location = new System.Drawing.Point(0, 0);
            this.picCover.Margin = new System.Windows.Forms.Padding(0);
            this.picCover.Name = "picCover";
            this.picCover.Size = new System.Drawing.Size(300, 450);
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCover.TabIndex = 0;
            this.picCover.TabStop = false;
            // 
            // Title
            // 
            this.Title.AutoSize = true;
            this.Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Title.Location = new System.Drawing.Point(3, 450);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(82, 38);
            this.Title.TabIndex = 1;
            this.Title.Text = "Tên:";
            // 
            // Author
            // 
            this.Author.AutoSize = true;
            this.Author.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Author.Location = new System.Drawing.Point(-6, 504);
            this.Author.Name = "Author";
            this.Author.Size = new System.Drawing.Size(128, 36);
            this.Author.TabIndex = 2;
            this.Author.Text = " Tác giả:";
            this.Author.Click += new System.EventHandler(this.label2_Click);
            // 
            // Category
            // 
            this.Category.AutoSize = true;
            this.Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Category.Location = new System.Drawing.Point(3, 540);
            this.Category.Name = "Category";
            this.Category.Size = new System.Drawing.Size(137, 36);
            this.Category.TabIndex = 3;
            this.Category.Text = "Thể loại: ";
            // 
            // Chon
            // 
            this.Chon.AutoSize = true;
            this.Chon.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chon.Location = new System.Drawing.Point(9, 579);
            this.Chon.Name = "Chon";
            this.Chon.Size = new System.Drawing.Size(109, 40);
            this.Chon.TabIndex = 4;
            this.Chon.Text = "Chọn";
            this.Chon.UseVisualStyleBackColor = true;
            // 
            // BookItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Chon);
            this.Controls.Add(this.Category);
            this.Controls.Add(this.Author);
            this.Controls.Add(this.Title);
            this.Controls.Add(this.picCover);
            this.Name = "BookItem";
            this.Size = new System.Drawing.Size(300, 626);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picCover;
        private System.Windows.Forms.Label Title;
        private System.Windows.Forms.Label Author;
        private System.Windows.Forms.Label Category;
        private System.Windows.Forms.CheckBox Chon;
    }
}
