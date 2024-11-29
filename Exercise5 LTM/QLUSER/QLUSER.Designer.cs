namespace QLUSER
{
    partial class QLUSER
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
            this.btn_OpenServer = new System.Windows.Forms.Button();
            this.btn_OpenUser = new System.Windows.Forms.Button();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.lb_IP = new System.Windows.Forms.Label();
            this.tb_NhapIP = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_OpenServer
            // 
            this.btn_OpenServer.Location = new System.Drawing.Point(16, 47);
            this.btn_OpenServer.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenServer.Name = "btn_OpenServer";
            this.btn_OpenServer.Size = new System.Drawing.Size(664, 47);
            this.btn_OpenServer.TabIndex = 0;
            this.btn_OpenServer.Text = "OPEN SERVER";
            this.btn_OpenServer.UseVisualStyleBackColor = true;
            this.btn_OpenServer.Click += new System.EventHandler(this.btn_OpenServer_Click);
            // 
            // btn_OpenUser
            // 
            this.btn_OpenUser.Location = new System.Drawing.Point(16, 132);
            this.btn_OpenUser.Margin = new System.Windows.Forms.Padding(4);
            this.btn_OpenUser.Name = "btn_OpenUser";
            this.btn_OpenUser.Size = new System.Drawing.Size(664, 47);
            this.btn_OpenUser.TabIndex = 1;
            this.btn_OpenUser.Text = "OPEN NEW USER";
            this.btn_OpenUser.UseVisualStyleBackColor = true;
            this.btn_OpenUser.Click += new System.EventHandler(this.btn_OpenUser_Click);
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(375, 220);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(305, 47);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "Thoát";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // lb_IP
            // 
            this.lb_IP.AutoSize = true;
            this.lb_IP.Location = new System.Drawing.Point(16, 236);
            this.lb_IP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lb_IP.Name = "lb_IP";
            this.lb_IP.Size = new System.Drawing.Size(62, 16);
            this.lb_IP.TabIndex = 3;
            this.lb_IP.Text = "Địa chỉ IP";
            // 
            // tb_NhapIP
            // 
            this.tb_NhapIP.Location = new System.Drawing.Point(95, 233);
            this.tb_NhapIP.Margin = new System.Windows.Forms.Padding(4);
            this.tb_NhapIP.Name = "tb_NhapIP";
            this.tb_NhapIP.Size = new System.Drawing.Size(251, 22);
            this.tb_NhapIP.TabIndex = 4;
            // 
            // QLUSER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(696, 299);
            this.Controls.Add(this.tb_NhapIP);
            this.Controls.Add(this.lb_IP);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.btn_OpenUser);
            this.Controls.Add(this.btn_OpenServer);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "QLUSER";
            this.Text = "QLUSER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_OpenServer;
        private System.Windows.Forms.Button btn_OpenUser;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.Label lb_IP;
        private System.Windows.Forms.TextBox tb_NhapIP;
    }
}