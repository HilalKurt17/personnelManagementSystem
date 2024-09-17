using PersonnelSystem.Entities;
using PersonnelSystem.VL;

namespace PersonnelSystem.WFUI
{

    public partial class managerForm : Form
    {
        validationLayerManagerForm VL;
        List<Personnel> personnelList;
        Guid updatedPersonnelID;
        Guid dutyIDToSendUpdateDelete;
        public Personnel manager { get; set; } // get manager and rearrange form using authority, name, surname and job title.

        public managerForm()
        {
            VL = new validationLayerManagerForm();

            InitializeComponent();

        }
        private void managerForm_Load(object sender, EventArgs e) // load personnelList when form is loaded
        {
            lbl_managerNameSurname.Text = manager.Name + " " + manager.Surname;
            lbl_managerJobTitle.Text = manager.JobTitle;
            if (manager.authority == 2)
            {
                rearrangeFormAccordingToAuthorityLevelOfManager();
            }
            else
            {

                bttn_editUpdatePersonnel.Text = "DÜZENLE";
                bttn_editUpdatePersonnel.Enabled = false;
                enableDisableEditPersonnel(true);

                addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignAsManager(), lstBx_manager);
                addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignToManager(), lstBx_personnel);
                dtGrdVw_managerPersonnelPairs.ReadOnly = true;
                dtGrdVw_managerPersonnelPairs.DataSource = showPersonnelManagerList();
                dtGrdVwManagerPersonnelPairsRearrange();
            }
            dtGrdVw_allPersonnels.ReadOnly = true;
            fillPersonnelList();
            dtGrdVw_myDuties.ReadOnly = true;
            dtGrdVw_myDuties.DataSource = VL.getAllDuties(manager.Mail);

            dtGrdVw_myDuties.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            renameMyDutiesTable();

        }

        private void bttn_addPersonnel_Click(object sender, EventArgs e)// add new personnel to the Personnels table in the database
        {
            string daysOff = txtBx_daysOff.Text;
            string personnelName = txtBx_personnelName.Text;
            string personnelLastName = txtBx_personnelLastName.Text;
            string personnelSalary = txtBx_personnelSalary.Text;
            string personnelTitle = txtBx_personnelTitle.Text;
            string personnelJobTitle = txtBx_personnelJobTitle.Text;
            int personnelAuthority = (int)nmrc_personnelAuthority.Value;
            string personnelMail = txtBx_personnelMail.Text;
            decimal personnelUsedDaysOff = 0;

            int result = VL.controlInputs(daysOff, personnelName, personnelLastName, personnelSalary, personnelTitle, personnelJobTitle, personnelAuthority, personnelMail);
            if (result == -1) // warn user if there is an empty space
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz bir şekilde doldurun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == -2) // warn user if authority is invalid
            {
                MessageBox.Show("Geçersiz erişim durumu.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (result == -3) // warn user if mail is invalid
            {
                MessageBox.Show("Lütfen geçerli bir mail adresi giriniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                // create new personnel
                (Personnel, int) returnValues = VL.createPersonnel(daysOff, personnelName, personnelLastName, personnelSalary, personnelTitle, personnelJobTitle, personnelAuthority, personnelMail, personnelUsedDaysOff);
                if (returnValues.Item2 == 1)
                {
                    VL.sendPersonnelDataToBLLToAdd(returnValues.Item1);
                    fillPersonnelList();
                    clearAddPersonnelPart();
                    lstBx_manager.Items.Clear();
                    lstBx_personnel.Items.Clear();
                    addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignAsManager(), lstBx_manager);
                    addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignToManager(), lstBx_personnel);
                }
                else
                {
                    MessageBox.Show("Lütfen veri girişlerini doğru veri tipinde yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
        }
        // edit/update personnel information
        private void bttn_editUpdatePersonnel_Click(object sender, EventArgs e)
        {

            if (bttn_editUpdatePersonnel.Text == "DÜZENLE")
            {
                enableDisableEditPersonnel(false);
                bttn_editUpdatePersonnel.Text = "GÜNCELLE";
            }
            else if (bttn_editUpdatePersonnel.Text == "GÜNCELLE")
            {
                (Personnel, int) returnValues = editPersonnelTabGetPersonnelInfo();

                if (returnValues.Item1.quitJob == true)
                {
                    // delete the personnel from Personnels table
                    VL.sendPersonnelDataToBLLToDelete(returnValues.Item1);
                    fillPersonnelList();
                    tabControl1.SelectedTab = tbPg_listPersonnels;
                    clearEditPersonnelPart();
                }
                else
                {
                    // update personnel in the Personnels table

                    if (returnValues.Item2 == 1)
                    {
                        VL.sendPersonnelDataToBLLToUpdate(returnValues.Item1);
                        fillPersonnelList();
                        tabControl1.SelectedTab = tbPg_listPersonnels;
                        clearEditPersonnelPart();
                        lstBx_manager.Items.Clear();
                        lstBx_personnel.Items.Clear();
                        addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignAsManager(), lstBx_manager);
                        addElementsToLstBx(VL.sendToWFUIPersonnelsToAssignToManager(), lstBx_personnel);
                    }
                    else
                    {
                        MessageBox.Show("Lütfen veri girişlerini doğru veri tipinde yapınız.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                enableDisableEditPersonnel(true);
                bttn_editUpdatePersonnel.Text = "DÜZENLE";
            }
        }
        // shows the selected personnel in the edit/update personnel tab control.
        private void dtGrdVw_allPersonnels_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            DataGridViewRow row = dtGrdVw_allPersonnels.Rows[e.RowIndex];
            Guid personnelID = (Guid)row.Cells[0].Value;
            string personnelName = (string)row.Cells[1].Value;
            string personnelSurname = (string)row.Cells[2].Value;
            string personnelMail = (string)row.Cells[3].Value;
            string personnelTitle = (string)row.Cells[4].Value;
            string personnelJobTitle = (string)row.Cells[5].Value;
            decimal personnelSalary = (decimal)row.Cells[6].Value;
            decimal personnelDaysOff = (decimal)row.Cells[7].Value;
            decimal personnelUsedDaysOff = (decimal)row.Cells[8].Value;
            bool personnelQuitJob = (bool)row.Cells[9].Value;
            int personnelAuthority = (int)row.Cells[10].Value;
            Personnel updatePersonnel = VL.showUpdatePersonnel(personnelID, personnelName, personnelSurname, personnelSalary, personnelTitle, personnelJobTitle, personnelAuthority, personnelMail, personnelUsedDaysOff, personnelDaysOff, personnelQuitJob);
            updatedPersonnelID = personnelID;
            editPersonnelTabShowPersonnelInfo(updatePersonnel);
            tabControl1.SelectedTab = tbPg_personnelEditUpdate;
            bttn_editUpdatePersonnel.Enabled = true;
            nmrc_editPersonnelUsedDaysOff.Maximum = personnelDaysOff;
        }


        // helper methods

        public void addElementsToLstBx(List<Personnel> personnelList, ListBox listboxName)
        {
            foreach (Personnel personnel in personnelList)
            {
                listboxName.Items.Add(personnel);
            }
        }
        public void clearAddPersonnelPart() // clearize add personnel textboxes
        {
            txtBx_daysOff.Text = "";
            txtBx_personnelName.Text = "";
            txtBx_personnelLastName.Text = "";
            txtBx_personnelSalary.Text = "";
            txtBx_personnelTitle.Text = "";
            txtBx_personnelJobTitle.Text = "";
            nmrc_personnelAuthority.Value = 1;
            txtBx_personnelMail.Text = "";

        }

        public void clearEditPersonnelPart() // clearize edit/update personnel textboxes
        {
            txtBx_editPersonnelDaysOff.Text = "";
            txtBx_editPersonnelName.Text = "";
            txtBx_editPersonnelLastName.Text = "";
            txtBx_editPersonnelMail.Text = "";
            txtBx_editPersonnelTitle.Text = "";
            txtBx_editPersonnelJobTitle.Text = "";
            nmrc_editPersonnelAuthority.Value = 1;
            nmrc_editPersonnelUsedDaysOff.Value = 0;
            chckBx_editLeaveCompany.Checked = false;
            txtBx_editPersonnelSalary.Text = "";
        }

        // show selected personnel information in the editPersonnel part
        public void editPersonnelTabShowPersonnelInfo(Personnel personnel)
        {
            txtBx_editPersonnelName.Text = personnel.Name;
            txtBx_editPersonnelLastName.Text = personnel.Surname;
            txtBx_editPersonnelMail.Text = personnel.Mail;
            txtBx_editPersonnelTitle.Text = personnel.Title;
            txtBx_editPersonnelJobTitle.Text = personnel.JobTitle;
            txtBx_editPersonnelDaysOff.Text = Convert.ToString(personnel.DaysOff);
            nmrc_editPersonnelAuthority.Value = personnel.authority;
            nmrc_editPersonnelUsedDaysOff.Value = personnel.UsedDaysOff;
            chckBx_editLeaveCompany.Checked = personnel.quitJob;
            txtBx_editPersonnelSalary.Text = personnel.Salary.ToString();


        }

        // create updated personnel with updated values if operation is successfully completed returnvalues.Item2 will be 1 otherwise, -1.
        public (Personnel, int) editPersonnelTabGetPersonnelInfo()
        {
            (Personnel, int) returnValues = VL.createPersonnel(updatedPersonnelID, txtBx_editPersonnelName.Text, txtBx_editPersonnelLastName.Text, txtBx_editPersonnelSalary.Text, txtBx_editPersonnelTitle.Text, txtBx_editPersonnelJobTitle.Text, nmrc_editPersonnelAuthority.Value, txtBx_editPersonnelMail.Text, nmrc_editPersonnelUsedDaysOff.Value, txtBx_editPersonnelDaysOff.Text, chckBx_editLeaveCompany.Checked);
            return returnValues;

        }

        public void fillPersonnelList() // fill personnel list to the data grid view
        {
            allPersonnels();
            dtGrdVw_allPersonnels.DataSource = personnelList;

            dataGridViewChangeName();
        }

        public void allPersonnels() // get all personnels from DLL
        {
            personnelList = VL.getAllPersonnelToUI(manager);
        }
        // enable disable form elements in the edit/update personnel tab control
        public void enableDisableEditPersonnel(bool condition)
        {

            txtBx_editPersonnelName.ReadOnly = condition;
            txtBx_editPersonnelLastName.ReadOnly = condition;
            txtBx_editPersonnelMail.ReadOnly = condition;
            txtBx_editPersonnelTitle.ReadOnly = condition;
            txtBx_editPersonnelJobTitle.ReadOnly = condition;
            nmrc_editPersonnelAuthority.ReadOnly = condition;
            nmrc_editPersonnelUsedDaysOff.ReadOnly = condition;
            chckBx_editLeaveCompany.Enabled = !condition;
            txtBx_editPersonnelSalary.ReadOnly = condition;
            txtBx_editPersonnelDaysOff.ReadOnly = condition;

        }

        // helper methods
        // change datagridview column names
        public void dataGridViewChangeName()
        {
            // change datagridview column headers name 
            dtGrdVw_allPersonnels.Columns[0].Visible = false;
            dtGrdVw_allPersonnels.Columns[1].HeaderText = "AD";
            dtGrdVw_allPersonnels.Columns[2].HeaderText = "SOYAD";
            dtGrdVw_allPersonnels.Columns[3].HeaderText = "MAİL";
            dtGrdVw_allPersonnels.Columns[4].HeaderText = "ÜNVAN";
            dtGrdVw_allPersonnels.Columns[5].HeaderText = "İŞ TANIMI";
            dtGrdVw_allPersonnels.Columns[6].HeaderText = "MAAŞ";
            dtGrdVw_allPersonnels.Columns[7].HeaderText = "TOPLAM İZİN GÜNÜ";
            dtGrdVw_allPersonnels.Columns[8].HeaderText = "KULLANILAN İZİN GÜNÜ";
            dtGrdVw_allPersonnels.Columns[9].Visible = false;
            dtGrdVw_allPersonnels.Columns[10].Visible = false;

            // adjust column width
            dtGrdVw_allPersonnels.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_allPersonnels.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            // adjust alignment of column content
            dtGrdVw_allPersonnels.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            // adjust alignment of column header content
            dtGrdVw_allPersonnels.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        // add personnel manager pair
        private void bttn_personnelManagerAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Personnel selectedPersonnel = (Personnel)lstBx_personnel.SelectedItem;
                Personnel selectedManager = (Personnel)lstBx_manager.SelectedItem;
                lstBx_personnel.ClearSelected();
                lstBx_manager.ClearSelected();
                Guid personnelID = selectedPersonnel.ID;
                Guid managerID = selectedManager.ID;
                VL.sendManagerPersonnelIDToBLL(managerID, personnelID);
                dtGrdVw_managerPersonnelPairs.DataSource = showPersonnelManagerList();
            }
            catch
            {
                MessageBox.Show("Personel ve yönetici seçimleri zorunludur.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        // show personnel - manager list for manager whom personnel auhtority is three
        public List<ManagerPersonnel> showPersonnelManagerList()
        {
            List<ManagerPersonnel> pairList;
            pairList = VL.sendPersonnelManagerListToManagerForm();
            return pairList;
        }

        // dataGridView change names, autosize columns etc. for personnel manager pair list
        public void dtGrdVwManagerPersonnelPairsRearrange()
        {
            dtGrdVw_managerPersonnelPairs.Columns[0].HeaderText = "Personel ID";
            dtGrdVw_managerPersonnelPairs.Columns[0].Visible = false;
            dtGrdVw_managerPersonnelPairs.Columns[1].HeaderText = "Personel Adı";
            dtGrdVw_managerPersonnelPairs.Columns[2].HeaderText = "Personel Soyadı";
            dtGrdVw_managerPersonnelPairs.Columns[3].HeaderText = "Personel İş Tanımı";
            dtGrdVw_managerPersonnelPairs.Columns[4].HeaderText = "Yetkili ID";
            dtGrdVw_managerPersonnelPairs.Columns[4].Visible = false;
            dtGrdVw_managerPersonnelPairs.Columns[5].HeaderText = "Yetkili Adı";
            dtGrdVw_managerPersonnelPairs.Columns[6].HeaderText = "Yetkili Soyadı";
            dtGrdVw_managerPersonnelPairs.Columns[7].HeaderText = "Yetkili İş Tanımı";

            dtGrdVw_managerPersonnelPairs.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_managerPersonnelPairs.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_managerPersonnelPairs.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_managerPersonnelPairs.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_managerPersonnelPairs.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_managerPersonnelPairs.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtGrdVw_managerPersonnelPairs.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dtGrdVw_managerPersonnelPairs.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        // rearrange form (remove some of the tabpages) according to authority level
        public void rearrangeFormAccordingToAuthorityLevelOfManager()
        {
            tabControl1.TabPages.Remove(tbPg_addNewPersonnel);
            tabControl1.TabPages.Remove(tbPg_assignManager);
            tabControl1.TabPages.Remove(tbPg_personnelEditUpdate);
            tabControl1.TabPages.Remove(tbPg_managerPersonnelPair);
        }

        // add new duty when button is clicked
        private void bttn_addNewDuty_Click(object sender, EventArgs e)
        {
            DateTime dueDate = dtTm_addNewDutyDueTime.Value;
            DateTime startDate = DateTime.Today;
            string senderMail = manager.Mail;
            string toPersonnelMail = txtBx_addNewDutyToPersonnelMail.Text;
            string subject = txtBx_addNewDutySubject.Text;
            string content = txtBx_addNewDutyContent.Text;
            string explanation = txtBx_addNewDutyExplanation.Text;
            Duty newDuty = VL.createNewDutyToAddNewDuty(dueDate, startDate, senderMail, toPersonnelMail, subject, content, explanation);
            int isDutyAdded = VL.sendNewDutyToBLL(newDuty);
            if (isDutyAdded == 1)
            {
                MessageBox.Show("Yeni görev başarıyla eklendi.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Yanlış personel maili girişi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            clearAddNewDutyTextBoxes();

        }

        // clear textboxes in the add new duty tab page
        public void clearAddNewDutyTextBoxes()
        {
            txtBx_addNewDutyContent.Text = "";
            txtBx_addNewDutyExplanation.Text = "";
            txtBx_addNewDutyToPersonnelMail.Text = "";
            txtBx_addNewDutySubject.Text = "";
            dtTm_addNewDutyDueTime.Value = DateTime.Parse("21-09-2024");
        }

        // show content in the duty detail tab page when duty cell is double clicked
        private void dtGrdVw_myDuties_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dtGrdVw_myDuties.SelectedRows[0];

            Duty duty = new Duty();
            duty.ID = (Guid)row.Cells["ID"].Value;

            dutyIDToSendUpdateDelete = new Guid();
            dutyIDToSendUpdateDelete = duty.ID;

            duty.toPersonnel = (string)row.Cells["toPersonnel"].Value;
            duty.subject = (string)row.Cells["subject"].Value;
            duty.content = (string)row.Cells["content"].Value;
            duty.explanation = (string)row.Cells["explanation"].Value;
            duty.startDate = (DateTime)row.Cells["startDate"].Value;
            duty.endDate = (DateTime)row.Cells["endDate"].Value;
            duty.completed = row.Cells["completed"] != null ? (bool)row.Cells["completed"].Value : null;
            duty.failed = row.Cells["failed"].Value != null ? (bool)row.Cells["failed"].Value : null;
            duty.sendControl = row.Cells["sendControl"].Value != null ? (bool)row.Cells["sendControl"].Value : null;
            duty.sender = (string)row.Cells["sender"].Value;
            showDutyDetails(duty);
            bttn_sendUpdateDuty.Enabled = true;

        }

        // show duty details on tab page
        public void showDutyDetails(Duty duty)
        {
            if (manager.Mail == duty.sender)
            {
                txtBx_dutyDetailsToPersonnel.Text = duty.toPersonnel;
                lbl_dutyDetails.Text = "Kime: ";
                bttn_sendUpdateDuty.Text = "GÜNCELLE";
                chckBx_dutyDetailCompleted.Text = "Tamamlandı";
                chckBx_dutyDetailCompleted.Visible = true;
                chckBx_dutyDetailCompleted.Enabled = true;
                txtBx_dutyDetailExplanation.Enabled = true;
                dtTm_dutyDetailDueDate.Enabled = true;
            }
            else
            {
                lbl_dutyDetails.Text = "Gönderen:";
                txtBx_dutyDetailsToPersonnel.Text = duty.sender;
                bttn_sendUpdateDuty.Text = "GÖNDER";
                chckBx_dutyDetailCompleted.Visible = false;
            }
            txtBx_dutyDetailSubject.Text = duty.subject;
            txtBx_dutyDetailContent.Text = duty.content;
            dtTm_dutyDetailDueDate.Value = duty.endDate;
            txtBx_dutyDetailExplanation.Text = duty.explanation;

            tabControl1.SelectedTab = tbPg_dutyDetails;

        }

        // rename my duties table
        public void renameMyDutiesTable()
        {

            dtGrdVw_myDuties.Columns[1].HeaderText = "GÖNDEREN";
            dtGrdVw_myDuties.Columns[2].HeaderText = "ALICI";
            dtGrdVw_myDuties.Columns[3].HeaderText = "KONU";
            dtGrdVw_myDuties.Columns[4].HeaderText = "İÇERİK";
            dtGrdVw_myDuties.Columns[6].HeaderText = "BAŞLANGIÇ";
            dtGrdVw_myDuties.Columns[7].HeaderText = "BİTİŞ";

            dtGrdVw_myDuties.Columns[0].Visible = false;
            dtGrdVw_myDuties.Columns[5].Visible = false;
            dtGrdVw_myDuties.Columns[8].Visible = false;
            dtGrdVw_myDuties.Columns[9].Visible = false;
            dtGrdVw_myDuties.Columns[10].Visible = false;

            dtGrdVw_myDuties.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_myDuties.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_myDuties.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_myDuties.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_myDuties.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dtGrdVw_myDuties.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

            dtGrdVw_myDuties.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


            dtGrdVw_myDuties.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        // send/update duty 
        private void bttn_sendUpdateDuty_Click(object sender, EventArgs e)
        {
            if (bttn_sendUpdateDuty.Text == "GÖNDER")
            {
                VL.sendDutyToManager(dutyIDToSendUpdateDelete);
                clearSendUpdateDutyTextBoxes();
                txtBx_dutyDetailExplanation.Enabled = false;
                dtTm_dutyDetailDueDate.Enabled = false;
                chckBx_dutyDetailCompleted.Enabled = false;

            }
            else
            {
                VL.sendDutyToUpdateDelete(dutyIDToSendUpdateDelete, txtBx_dutyDetailExplanation.Text, dtTm_dutyDetailDueDate.Value, chckBx_dutyDetailCompleted.Checked);
                clearSendUpdateDutyTextBoxes();
            }
            bttn_sendUpdateDuty.Enabled = false;
            txtBx_dutyDetailExplanation.Enabled = false;
            chckBx_dutyDetailCompleted.Enabled = false;
            dtTm_dutyDetailDueDate.Enabled = false;
            dtGrdVw_myDuties.DataSource = VL.getAllDuties(manager.Mail);
            tabControl1.SelectedTab = tbPg_myDuties;
        }

        // clear textboxes in send/update duty tab page
        public void clearSendUpdateDutyTextBoxes()
        {
            txtBx_dutyDetailContent.Text = "";
            txtBx_dutyDetailExplanation.Text = "";
            txtBx_dutyDetailsToPersonnel.Text = "";
            txtBx_dutyDetailSubject.Text = "";
            chckBx_dutyDetailCompleted.Checked = false;
            dtTm_dutyDetailDueDate.Value = DateTime.Parse("30-09-2024");
        }


    }
}
