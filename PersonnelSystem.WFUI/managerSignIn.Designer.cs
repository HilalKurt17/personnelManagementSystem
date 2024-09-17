namespace PersonnelSystem.WFUI
{
    partial class managerSignIn
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtBx_managerMail = new System.Windows.Forms.TextBox();
            this.bttn_managerSignIn = new System.Windows.Forms.Button();
            this.txtBx_password = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(41, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Yetkili Mail:";
            // 
            // txtBx_managerMail
            // 
            this.txtBx_managerMail.Location = new System.Drawing.Point(192, 58);
            this.txtBx_managerMail.Name = "txtBx_managerMail";
            this.txtBx_managerMail.Size = new System.Drawing.Size(291, 27);
            this.txtBx_managerMail.TabIndex = 0;
            // 
            // bttn_managerSignIn
            // 
            this.bttn_managerSignIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_managerSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttn_managerSignIn.Location = new System.Drawing.Point(192, 165);
            this.bttn_managerSignIn.Name = "bttn_managerSignIn";
            this.bttn_managerSignIn.Size = new System.Drawing.Size(291, 40);
            this.bttn_managerSignIn.TabIndex = 2;
            this.bttn_managerSignIn.Text = "GİRİŞ YAP";
            this.bttn_managerSignIn.UseVisualStyleBackColor = false;
            this.bttn_managerSignIn.Click += new System.EventHandler(this.bttn_managerSignIn_Click);
            // 
            // txtBx_password
            // 
            this.txtBx_password.Location = new System.Drawing.Point(192, 106);
            this.txtBx_password.Name = "txtBx_password";
            this.txtBx_password.PasswordChar = '*';
            this.txtBx_password.Size = new System.Drawing.Size(291, 27);
            this.txtBx_password.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(41, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 28);
            this.label2.TabIndex = 4;
            this.label2.Text = "Şifre:";
            // 
            // managerSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(543, 249);
            this.Controls.Add(this.txtBx_password);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.bttn_managerSignIn);
            this.Controls.Add(this.txtBx_managerMail);
            this.Controls.Add(this.label1);
            this.Name = "managerSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yetkili Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox txtBx_managerMail;
        private Button bttn_managerSignIn;
        private TextBox txtBx_password;
        private Label label2;
    }
}