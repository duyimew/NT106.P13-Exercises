namespace QLUSER
{
    partial class DoiMatKhau
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
            this.components = new System.ComponentModel.Container();
            this.tb_mkhientai = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tb_mkmoi = new System.Windows.Forms.TextBox();
            this.tb_xacnhanmk = new System.Windows.Forms.TextBox();
            this.lb_mkhientai = new System.Windows.Forms.Label();
            this.lb_mkmoi = new System.Windows.Forms.Label();
            this.lb_xacnhanmk = new System.Windows.Forms.Label();
            this.btn_exit = new System.Windows.Forms.Button();
            this.btn_doimk = new System.Windows.Forms.Button();
            this.lb_doimatkhau = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_mkhientai
            // 
            this.tb_mkhientai.Location = new System.Drawing.Point(355, 150);
            this.tb_mkhientai.Name = "tb_mkhientai";
            this.tb_mkhientai.Size = new System.Drawing.Size(273, 20);
            this.tb_mkhientai.TabIndex = 0;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tb_mkmoi
            // 
            this.tb_mkmoi.Location = new System.Drawing.Point(355, 196);
            this.tb_mkmoi.Name = "tb_mkmoi";
            this.tb_mkmoi.Size = new System.Drawing.Size(273, 20);
            this.tb_mkmoi.TabIndex = 0;
            // 
            // tb_xacnhanmk
            // 
            this.tb_xacnhanmk.Location = new System.Drawing.Point(355, 244);
            this.tb_xacnhanmk.Name = "tb_xacnhanmk";
            this.tb_xacnhanmk.Size = new System.Drawing.Size(273, 20);
            this.tb_xacnhanmk.TabIndex = 0;
            // 
            // lb_mkhientai
            // 
            this.lb_mkhientai.AutoSize = true;
            this.lb_mkhientai.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_mkhientai.Location = new System.Drawing.Point(169, 154);
            this.lb_mkhientai.Name = "lb_mkhientai";
            this.lb_mkhientai.Size = new System.Drawing.Size(106, 16);
            this.lb_mkhientai.TabIndex = 2;
            this.lb_mkhientai.Text = "Mật khẩu hiện tại";
            // 
            // lb_mkmoi
            // 
            this.lb_mkmoi.AutoSize = true;
            this.lb_mkmoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_mkmoi.Location = new System.Drawing.Point(169, 199);
            this.lb_mkmoi.Name = "lb_mkmoi";
            this.lb_mkmoi.Size = new System.Drawing.Size(92, 17);
            this.lb_mkmoi.TabIndex = 2;
            this.lb_mkmoi.Text = "Mật khẩu mới";
            // 
            // lb_xacnhanmk
            // 
            this.lb_xacnhanmk.AutoSize = true;
            this.lb_xacnhanmk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.lb_xacnhanmk.Location = new System.Drawing.Point(169, 247);
            this.lb_xacnhanmk.Name = "lb_xacnhanmk";
            this.lb_xacnhanmk.Size = new System.Drawing.Size(156, 17);
            this.lb_xacnhanmk.TabIndex = 2;
            this.lb_xacnhanmk.Text = "Xác nhận mật khẩu mới";
            // 
            // btn_exit
            // 
            this.btn_exit.AutoEllipsis = true;
            this.btn_exit.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_exit.Location = new System.Drawing.Point(547, 334);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(2);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(81, 39);
            this.btn_exit.TabIndex = 5;
            this.btn_exit.Text = "thoát";
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // btn_doimk
            // 
            this.btn_doimk.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.btn_doimk.Location = new System.Drawing.Point(172, 334);
            this.btn_doimk.Margin = new System.Windows.Forms.Padding(2);
            this.btn_doimk.Name = "btn_doimk";
            this.btn_doimk.Size = new System.Drawing.Size(129, 39);
            this.btn_doimk.TabIndex = 4;
            this.btn_doimk.Text = "Đổi mật khẩu";
            this.btn_doimk.UseVisualStyleBackColor = true;
            this.btn_doimk.Click += new System.EventHandler(this.btn_sendEmail_Click);
            // 
            // lb_doimatkhau
            // 
            this.lb_doimatkhau.AutoSize = true;
            this.lb_doimatkhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lb_doimatkhau.Location = new System.Drawing.Point(308, 56);
            this.lb_doimatkhau.Name = "lb_doimatkhau";
            this.lb_doimatkhau.Size = new System.Drawing.Size(173, 31);
            this.lb_doimatkhau.TabIndex = 6;
            this.lb_doimatkhau.Text = "Đổi mật khẩu";
            // 
            // DoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lb_doimatkhau);
            this.Controls.Add(this.btn_exit);
            this.Controls.Add(this.btn_doimk);
            this.Controls.Add(this.lb_xacnhanmk);
            this.Controls.Add(this.lb_mkmoi);
            this.Controls.Add(this.lb_mkhientai);
            this.Controls.Add(this.tb_xacnhanmk);
            this.Controls.Add(this.tb_mkmoi);
            this.Controls.Add(this.tb_mkhientai);
            this.Name = "DoiMatKhau";
            this.Text = "DoiMatKhau";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_mkhientai;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tb_mkmoi;
        private System.Windows.Forms.TextBox tb_xacnhanmk;
        private System.Windows.Forms.Label lb_mkhientai;
        private System.Windows.Forms.Label lb_mkmoi;
        private System.Windows.Forms.Label lb_xacnhanmk;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Button btn_doimk;
        private System.Windows.Forms.Label lb_doimatkhau;
    }
}