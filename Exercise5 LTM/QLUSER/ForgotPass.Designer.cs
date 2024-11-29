namespace QLUSER
{
    partial class ForgotPass
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
            this.tb_email = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_sendEmail = new System.Windows.Forms.Button();
            this.btn_exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_email
            // 
            this.tb_email.Location = new System.Drawing.Point(283, 181);
            this.tb_email.Name = "tb_email";
            this.tb_email.Size = new System.Drawing.Size(255, 22);
            this.tb_email.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 181);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nhập email của tài khoản";
            // 
            // btn_sendEmail
            // 
            this.btn_sendEmail.Location = new System.Drawing.Point(330, 254);
            this.btn_sendEmail.Name = "btn_sendEmail";
            this.btn_sendEmail.Size = new System.Drawing.Size(138, 23);
            this.btn_sendEmail.TabIndex = 2;
            this.btn_sendEmail.Text = "Nhận Mã";
            this.btn_sendEmail.UseVisualStyleBackColor = true;
            this.btn_sendEmail.Click += new System.EventHandler(this.btn_sendEmail_Click);
            // 
            // btn_exit
            // 
            this.btn_exit.AutoEllipsis = true;
            this.btn_exit.Location = new System.Drawing.Point(540, 254);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(75, 23);
            this.btn_exit.TabIndex = 3;
            this.btn_exit.Text = "thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // ForgotPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_sendEmail);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_email);
            this.Name = "ForgotPass";
            this.Text = "ForgotPass";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_sendEmail;
        private System.Windows.Forms.Button btn_exit;
    }
}