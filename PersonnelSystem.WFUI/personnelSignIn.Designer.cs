namespace PersonnelSystem.WFUI
{
    partial class personnelSignIn
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
            this.label2 = new System.Windows.Forms.Label();
            this.txtBx_personnelMail = new System.Windows.Forms.TextBox();
            this.txtBx_password = new System.Windows.Forms.TextBox();
            this.bttn_personnelSignIn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(41, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(139, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Personel Mail:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(41, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 28);
            this.label2.TabIndex = 1;
            this.label2.Text = "Şifre:";
            // 
            // txtBx_personnelMail
            // 
            this.txtBx_personnelMail.Location = new System.Drawing.Point(192, 58);
            this.txtBx_personnelMail.Name = "txtBx_personnelMail";
            this.txtBx_personnelMail.Size = new System.Drawing.Size(291, 27);
            this.txtBx_personnelMail.TabIndex = 0;
            // 
            // txtBx_password
            // 
            this.txtBx_password.Location = new System.Drawing.Point(192, 106);
            this.txtBx_password.Name = "txtBx_password";
            this.txtBx_password.PasswordChar = '*';
            this.txtBx_password.Size = new System.Drawing.Size(291, 27);
            this.txtBx_password.TabIndex = 1;
            // 
            // bttn_personnelSignIn
            // 
            this.bttn_personnelSignIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_personnelSignIn.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttn_personnelSignIn.Location = new System.Drawing.Point(192, 165);
            this.bttn_personnelSignIn.Name = "bttn_personnelSignIn";
            this.bttn_personnelSignIn.Size = new System.Drawing.Size(291, 35);
            this.bttn_personnelSignIn.TabIndex = 2;
            this.bttn_personnelSignIn.Text = "GİRİŞ YAP";
            this.bttn_personnelSignIn.UseVisualStyleBackColor = false;
            this.bttn_personnelSignIn.Click += new System.EventHandler(this.bttn_personnelSignIn_Click);
            // 
            // personnelSignIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(543, 249);
            this.Controls.Add(this.bttn_personnelSignIn);
            this.Controls.Add(this.txtBx_password);
            this.Controls.Add(this.txtBx_personnelMail);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "personnelSignIn";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Girişi";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtBx_personnelMail;
        private TextBox txtBx_password;
        private Button bttn_personnelSignIn;
    }
}