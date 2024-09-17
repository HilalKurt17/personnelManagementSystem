namespace PersonnelSystem.WFUI
{
    partial class personnelForm
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
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbl_personnelJobTitle = new System.Windows.Forms.Label();
            this.lbl_personnelNameSurname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tbPg_listDuties = new System.Windows.Forms.TabPage();
            this.dtGrdVw_dutyList = new System.Windows.Forms.DataGridView();
            this.tbPg_personnelDutyDetail = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bttn_sendDutyToControl = new System.Windows.Forms.Button();
            this.txtBx_dutyDetailExplanation = new System.Windows.Forms.TextBox();
            this.lbl_dutyDetails = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.txtBx_dutyDetailsSender = new System.Windows.Forms.TextBox();
            this.dtTm_dutyDetailDueDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBx_dutyDetailSubject = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBx_dutyDetailContent = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tbPg_listDuties.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVw_dutyList)).BeginInit();
            this.tbPg_personnelDutyDetail.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbl_personnelJobTitle);
            this.groupBox3.Controls.Add(this.lbl_personnelNameSurname);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 14);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1053, 403);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            // 
            // lbl_personnelJobTitle
            // 
            this.lbl_personnelJobTitle.AutoSize = true;
            this.lbl_personnelJobTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_personnelJobTitle.Location = new System.Drawing.Point(112, 70);
            this.lbl_personnelJobTitle.Name = "lbl_personnelJobTitle";
            this.lbl_personnelJobTitle.Size = new System.Drawing.Size(67, 28);
            this.lbl_personnelJobTitle.TabIndex = 4;
            this.lbl_personnelJobTitle.Text = "label4";
            // 
            // lbl_personnelNameSurname
            // 
            this.lbl_personnelNameSurname.AutoSize = true;
            this.lbl_personnelNameSurname.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lbl_personnelNameSurname.Location = new System.Drawing.Point(224, 23);
            this.lbl_personnelNameSurname.Name = "lbl_personnelNameSurname";
            this.lbl_personnelNameSurname.Size = new System.Drawing.Size(66, 28);
            this.lbl_personnelNameSurname.TabIndex = 3;
            this.lbl_personnelNameSurname.Text = "label3";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(19, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ünvan:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(19, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(187, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "Personel Ad Soyad:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tabControl1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 115);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 302);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tbPg_listDuties);
            this.tabControl1.Controls.Add(this.tbPg_personnelDutyDetail);
            this.tabControl1.Location = new System.Drawing.Point(0, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1047, 270);
            this.tabControl1.TabIndex = 0;
            // 
            // tbPg_listDuties
            // 
            this.tbPg_listDuties.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbPg_listDuties.Controls.Add(this.dtGrdVw_dutyList);
            this.tbPg_listDuties.Location = new System.Drawing.Point(4, 29);
            this.tbPg_listDuties.Name = "tbPg_listDuties";
            this.tbPg_listDuties.Size = new System.Drawing.Size(1039, 237);
            this.tbPg_listDuties.TabIndex = 2;
            this.tbPg_listDuties.Text = "Görev Listesi";
            // 
            // dtGrdVw_dutyList
            // 
            this.dtGrdVw_dutyList.BackgroundColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.dtGrdVw_dutyList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrdVw_dutyList.Location = new System.Drawing.Point(-4, 3);
            this.dtGrdVw_dutyList.Name = "dtGrdVw_dutyList";
            this.dtGrdVw_dutyList.ReadOnly = true;
            this.dtGrdVw_dutyList.RowHeadersWidth = 51;
            this.dtGrdVw_dutyList.RowTemplate.Height = 29;
            this.dtGrdVw_dutyList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGrdVw_dutyList.Size = new System.Drawing.Size(1043, 234);
            this.dtGrdVw_dutyList.TabIndex = 0;
            this.dtGrdVw_dutyList.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGrdVw_dutyList_CellContentDoubleClick);
            // 
            // tbPg_personnelDutyDetail
            // 
            this.tbPg_personnelDutyDetail.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tbPg_personnelDutyDetail.Controls.Add(this.groupBox2);
            this.tbPg_personnelDutyDetail.Location = new System.Drawing.Point(4, 29);
            this.tbPg_personnelDutyDetail.Name = "tbPg_personnelDutyDetail";
            this.tbPg_personnelDutyDetail.Size = new System.Drawing.Size(1039, 237);
            this.tbPg_personnelDutyDetail.TabIndex = 3;
            this.tbPg_personnelDutyDetail.Text = "Görev Detay";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bttn_sendDutyToControl);
            this.groupBox2.Controls.Add(this.txtBx_dutyDetailExplanation);
            this.groupBox2.Controls.Add(this.lbl_dutyDetails);
            this.groupBox2.Controls.Add(this.label27);
            this.groupBox2.Controls.Add(this.txtBx_dutyDetailsSender);
            this.groupBox2.Controls.Add(this.dtTm_dutyDetailDueDate);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtBx_dutyDetailSubject);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtBx_dutyDetailContent);
            this.groupBox2.Location = new System.Drawing.Point(3, -15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1034, 250);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // bttn_sendDutyToControl
            // 
            this.bttn_sendDutyToControl.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.bttn_sendDutyToControl.Enabled = false;
            this.bttn_sendDutyToControl.Location = new System.Drawing.Point(814, 205);
            this.bttn_sendDutyToControl.Name = "bttn_sendDutyToControl";
            this.bttn_sendDutyToControl.Size = new System.Drawing.Size(201, 35);
            this.bttn_sendDutyToControl.TabIndex = 18;
            this.bttn_sendDutyToControl.Text = "GÖNDER";
            this.bttn_sendDutyToControl.UseVisualStyleBackColor = false;
            this.bttn_sendDutyToControl.Click += new System.EventHandler(this.bttn_sendDutyToControl_Click);
            // 
            // txtBx_dutyDetailExplanation
            // 
            this.txtBx_dutyDetailExplanation.Enabled = false;
            this.txtBx_dutyDetailExplanation.Location = new System.Drawing.Point(592, 81);
            this.txtBx_dutyDetailExplanation.Multiline = true;
            this.txtBx_dutyDetailExplanation.Name = "txtBx_dutyDetailExplanation";
            this.txtBx_dutyDetailExplanation.Size = new System.Drawing.Size(423, 115);
            this.txtBx_dutyDetailExplanation.TabIndex = 11;
            // 
            // lbl_dutyDetails
            // 
            this.lbl_dutyDetails.AutoSize = true;
            this.lbl_dutyDetails.Location = new System.Drawing.Point(20, 36);
            this.lbl_dutyDetails.Name = "lbl_dutyDetails";
            this.lbl_dutyDetails.Size = new System.Drawing.Size(81, 20);
            this.lbl_dutyDetails.TabIndex = 10;
            this.lbl_dutyDetails.Text = "Gönderen:";
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(483, 37);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(97, 20);
            this.label27.TabIndex = 16;
            this.label27.Text = "Teslim Tarihi:";
            // 
            // txtBx_dutyDetailsSender
            // 
            this.txtBx_dutyDetailsSender.Enabled = false;
            this.txtBx_dutyDetailsSender.Location = new System.Drawing.Point(129, 32);
            this.txtBx_dutyDetailsSender.Name = "txtBx_dutyDetailsSender";
            this.txtBx_dutyDetailsSender.Size = new System.Drawing.Size(203, 27);
            this.txtBx_dutyDetailsSender.TabIndex = 14;
            // 
            // dtTm_dutyDetailDueDate
            // 
            this.dtTm_dutyDetailDueDate.Enabled = false;
            this.dtTm_dutyDetailDueDate.Location = new System.Drawing.Point(592, 32);
            this.dtTm_dutyDetailDueDate.Name = "dtTm_dutyDetailDueDate";
            this.dtTm_dutyDetailDueDate.Size = new System.Drawing.Size(238, 27);
            this.dtTm_dutyDetailDueDate.TabIndex = 15;
            this.dtTm_dutyDetailDueDate.Value = new System.DateTime(2024, 8, 31, 0, 0, 0, 0);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "Konu:";
            // 
            // txtBx_dutyDetailSubject
            // 
            this.txtBx_dutyDetailSubject.Enabled = false;
            this.txtBx_dutyDetailSubject.Location = new System.Drawing.Point(129, 78);
            this.txtBx_dutyDetailSubject.Name = "txtBx_dutyDetailSubject";
            this.txtBx_dutyDetailSubject.Size = new System.Drawing.Size(203, 27);
            this.txtBx_dutyDetailSubject.TabIndex = 13;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 78);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 7;
            this.label6.Text = "Açıklama:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(19, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "İçerik:";
            // 
            // txtBx_dutyDetailContent
            // 
            this.txtBx_dutyDetailContent.Enabled = false;
            this.txtBx_dutyDetailContent.Location = new System.Drawing.Point(129, 124);
            this.txtBx_dutyDetailContent.Multiline = true;
            this.txtBx_dutyDetailContent.Name = "txtBx_dutyDetailContent";
            this.txtBx_dutyDetailContent.Size = new System.Drawing.Size(203, 72);
            this.txtBx_dutyDetailContent.TabIndex = 12;
            // 
            // personnelForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1077, 441);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Name = "personnelForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Sistemi";
            this.Load += new System.EventHandler(this.personnelForm_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tbPg_listDuties.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrdVw_dutyList)).EndInit();
            this.tbPg_personnelDutyDetail.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private GroupBox groupBox3;
        private Label label1;
        private GroupBox groupBox1;
        private TabControl tabControl1;
        private TabPage tbPg_listDuties;
        private Label lbl_personnelJobTitle;
        private Label lbl_personnelNameSurname;
        private Label label2;
        private DataGridView dtGrdVw_dutyList;
        private TabPage tbPg_personnelDutyDetail;
        private GroupBox groupBox2;
        private Button bttn_sendDutyToControl;
        private TextBox txtBx_dutyDetailExplanation;
        private Label lbl_dutyDetails;
        private Label label27;
        private TextBox txtBx_dutyDetailsSender;
        private DateTimePicker dtTm_dutyDetailDueDate;
        private Label label3;
        private TextBox txtBx_dutyDetailSubject;
        private Label label6;
        private Label label5;
        private TextBox txtBx_dutyDetailContent;
    }
}