namespace QLUSER
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
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.btnRemoveFromShelf = new System.Windows.Forms.Button();
            this.btnAddToShelf = new System.Windows.Forms.Button();
            this.rtbBookDetails = new System.Windows.Forms.RichTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(33)))), ((int)(((byte)(36)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(590, 81);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(8, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 37);
            this.label1.TabIndex = 0;
            this.label1.Text = "Chi tiết sách";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(69)))), ((int)(((byte)(73)))));
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.progressBar1);
            this.panel2.Controls.Add(this.btnRemoveFromShelf);
            this.panel2.Controls.Add(this.btnAddToShelf);
            this.panel2.Controls.Add(this.rtbBookDetails);
            this.panel2.Location = new System.Drawing.Point(1, 80);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(590, 393);
            this.panel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(13, 268);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID kệ sách";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(16, 297);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(152, 20);
            this.textBox1.TabIndex = 13;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(15, 228);
            this.progressBar1.Margin = new System.Windows.Forms.Padding(2);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(89, 19);
            this.progressBar1.TabIndex = 12;
            // 
            // btnRemoveFromShelf
            // 
            this.btnRemoveFromShelf.Location = new System.Drawing.Point(406, 333);
            this.btnRemoveFromShelf.Margin = new System.Windows.Forms.Padding(2);
            this.btnRemoveFromShelf.Name = "btnRemoveFromShelf";
            this.btnRemoveFromShelf.Size = new System.Drawing.Size(153, 30);
            this.btnRemoveFromShelf.TabIndex = 11;
            this.btnRemoveFromShelf.Text = "Xoá khỏi kệ sách";
            this.btnRemoveFromShelf.UseVisualStyleBackColor = true;
            this.btnRemoveFromShelf.Click += new System.EventHandler(this.btnRemoveFromShelf_Click);
            // 
            // btnAddToShelf
            // 
            this.btnAddToShelf.Location = new System.Drawing.Point(15, 333);
            this.btnAddToShelf.Margin = new System.Windows.Forms.Padding(2);
            this.btnAddToShelf.Name = "btnAddToShelf";
            this.btnAddToShelf.Size = new System.Drawing.Size(153, 30);
            this.btnAddToShelf.TabIndex = 10;
            this.btnAddToShelf.Text = "Thêm vào kệ sách";
            this.btnAddToShelf.UseVisualStyleBackColor = true;
            this.btnAddToShelf.Click += new System.EventHandler(this.btnAddToShelf_Click);
            // 
            // rtbBookDetails
            // 
            this.rtbBookDetails.Location = new System.Drawing.Point(14, 26);
            this.rtbBookDetails.Margin = new System.Windows.Forms.Padding(2);
            this.rtbBookDetails.Name = "rtbBookDetails";
            this.rtbBookDetails.Size = new System.Drawing.Size(545, 186);
            this.rtbBookDetails.TabIndex = 9;
            this.rtbBookDetails.Text = "";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(406, 259);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 30);
            this.button1.TabIndex = 15;
            this.button1.Text = "Thoát";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // BookDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(590, 472);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "BookDetail";
            this.Text = "BookDetail";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RichTextBox rtbBookDetails;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button btnRemoveFromShelf;
        private System.Windows.Forms.Button btnAddToShelf;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}