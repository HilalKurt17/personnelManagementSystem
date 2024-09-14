namespace PersonnelSystem.WFUI
{
    partial class signInForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.bttn_personnelSignIn = new System.Windows.Forms.Button();
            this.bttn_managerSignIn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.label1.Font = new System.Drawing.Font("Segoe UI Black", 22.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(102, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(555, 50);
            this.label1.TabIndex = 0;
            this.label1.Text = "PERSONEL YÖNETİM SİSTEMİ";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.bttn_personnelSignIn);
            this.groupBox1.Controls.Add(this.bttn_managerSignIn);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(28, 31);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(748, 363);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // bttn_personnelSignIn
            // 
            this.bttn_personnelSignIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_personnelSignIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttn_personnelSignIn.Location = new System.Drawing.Point(169, 231);
            this.bttn_personnelSignIn.Name = "bttn_personnelSignIn";
            this.bttn_personnelSignIn.Size = new System.Drawing.Size(420, 60);
            this.bttn_personnelSignIn.TabIndex = 1;
            this.bttn_personnelSignIn.Text = "PERSONEL GİRİŞİ";
            this.bttn_personnelSignIn.UseVisualStyleBackColor = false;
            this.bttn_personnelSignIn.Click += new System.EventHandler(this.bttn_personnelSignIn_Click);
            // 
            // bttn_managerSignIn
            // 
            this.bttn_managerSignIn.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.bttn_managerSignIn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.bttn_managerSignIn.Location = new System.Drawing.Point(169, 142);
            this.bttn_managerSignIn.Name = "bttn_managerSignIn";
            this.bttn_managerSignIn.Size = new System.Drawing.Size(420, 60);
            this.bttn_managerSignIn.TabIndex = 0;
            this.bttn_managerSignIn.Text = "YETKİLİ GİRİŞİ";
            this.bttn_managerSignIn.UseVisualStyleBackColor = false;
            this.bttn_managerSignIn.Click += new System.EventHandler(this.bttn_managerSignIn_Click);
            // 
            // signInForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 434);
            this.Controls.Add(this.groupBox1);
            this.Name = "signInForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Yönetim Sistemi";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private GroupBox groupBox1;
        private Button bttn_personnelSignIn;
        private Button bttn_managerSignIn;
    }
}