namespace Exercise4LTM
{
    partial class BookDetail
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rtbBookDetails = new System.Windows.Forms.RichTextBox();
            this.btnAddToShelf = new System.Windows.Forms.Button();
            this.btnRemoveFromShelf = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(787, 100);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 46);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi tiết sách";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.progressBar2);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnRemoveFromShelf);
            this.panel2.Controls.Add(this.btnAddToShelf);
            this.panel2.Controls.Add(this.rtbBookDetails);
            this.panel2.Location = new System.Drawing.Point(1, 98);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(787, 484);
            this.panel2.TabIndex = 1;
            // 
            // rtbBookDetails
            // 
            this.rtbBookDetails.Location = new System.Drawing.Point(19, 32);
            this.rtbBookDetails.Name = "rtbBookDetails";
            this.rtbBookDetails.Size = new System.Drawing.Size(725, 228);
            this.rtbBookDetails.TabIndex = 9;
            this.rtbBookDetails.Text = "";
            // 
            // btnAddToShelf
            // 
            this.btnAddToShelf.Location = new System.Drawing.Point(19, 386);
            this.btnAddToShelf.Name = "btnAddToShelf";
            this.btnAddToShelf.Size = new System.Drawing.Size(204, 37);
            this.btnAddToShelf.TabIndex = 10;
            this.btnAddToShelf.Text = "Thêm vào kệ sách";
            this.btnAddToShelf.UseVisualStyleBackColor = true;
            // 
            // btnRemoveFromShelf
            // 
            this.btnRemoveFromShelf.Location = new System.Drawing.Point(540, 386);
            this.btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            this.btnRemoveFromShelf.Size = new System.Drawing.Size(204, 37);
            this.btnRemoveFromShelf.TabIndex = 11;
            this.btnRemoveFromShelf.Text = "Xoá khỏi kệ sách";
            this.btnRemoveFromShelf.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(19, 429);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 23);
            this.progressBar1.TabIndex = 12;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(540, 429);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(100, 23);
            this.progressBar2.TabIndex = 13;
            // 
            // BookDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 581);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BookDetail";
            this.Text = "BookDetail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtbBookDetails;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnRemoveFromShelf;
        private System.Windows.Forms.Button btnAddToShelf;
    }
}