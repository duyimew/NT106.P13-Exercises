namespace QLUSER
{
    partial class SERVER
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
            this.btn_Listen = new System.Windows.Forms.Button();
            this.lv_ClientsView = new System.Windows.Forms.ListView();
            this.btn_Exit = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btn_Listen
            // 
            this.btn_Listen.Location = new System.Drawing.Point(920, 28);
            this.btn_Listen.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Listen.Name = "btn_Listen";
            this.btn_Listen.Size = new System.Drawing.Size(113, 42);
            this.btn_Listen.TabIndex = 0;
            this.btn_Listen.Text = "LISTEN";
            this.btn_Listen.UseVisualStyleBackColor = true;
            this.btn_Listen.Click += new System.EventHandler(this.btn_Listen_Click);
            // 
            // lv_ClientsView
            // 
            this.lv_ClientsView.HideSelection = false;
            this.lv_ClientsView.Location = new System.Drawing.Point(36, 106);
            this.lv_ClientsView.Margin = new System.Windows.Forms.Padding(4);
            this.lv_ClientsView.Name = "lv_ClientsView";
            this.lv_ClientsView.Size = new System.Drawing.Size(996, 409);
            this.lv_ClientsView.TabIndex = 1;
            this.lv_ClientsView.UseCompatibleStateImageBehavior = false;
            // 
            // btn_Exit
            // 
            this.btn_Exit.Location = new System.Drawing.Point(36, 28);
            this.btn_Exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Exit.Name = "btn_Exit";
            this.btn_Exit.Size = new System.Drawing.Size(113, 42);
            this.btn_Exit.TabIndex = 2;
            this.btn_Exit.Text = "THOÁT";
            this.btn_Exit.UseVisualStyleBackColor = true;
            this.btn_Exit.Click += new System.EventHandler(this.btn_Exit_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(199, 48);
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(271, 22);
            this.textBox1.TabIndex = 3;
            // 
            // SERVER
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.btn_Exit);
            this.Controls.Add(this.lv_ClientsView);
            this.Controls.Add(this.btn_Listen);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "SERVER";
            this.Text = "SERVER";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Listen;
        private System.Windows.Forms.ListView lv_ClientsView;
        private System.Windows.Forms.Button btn_Exit;
        private System.Windows.Forms.TextBox textBox1;
    }
}