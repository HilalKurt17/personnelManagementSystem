using PersonnelSystem.Entities;
using PersonnelSystem.VL;

namespace PersonnelSystem.WFUI
{
    public partial class personnelForm : Form
    {
        validationLayerPersonnelForm VL;
        public Personnel personnel;
        public Guid dutyIDToSendDutyToControl;
        public personnelForm()
        {
            VL = new validationLayerPersonnelForm();
            personnel = new Personnel();
            InitializeComponent();
        }

        // list all duties when form is loaded.
        private void personnelForm_Load(object sender, EventArgs e)
        {
            lbl_personnelNameSurname.Text = personnel.Name + " " + personnel.Surname;
            lbl_personnelJobTitle.Text = personnel.JobTitle;
            dtGrdVw_dutyList.DataSource = VL.getMyDuties(personnel.Mail);
        }

        // send duty to manager for control/check operation
        private void bttn_sendDutyToControl_Click(object sender, EventArgs e)
        {
            VL.sendDutyToManager(dutyIDToSendDutyToControl);
            dtGrdVw_dutyList.DataSource = VL.getMyDuties(personnel.Mail);
            bttn_sendDutyToControl.Enabled = false;
            clearTextBoxes();
            tabControl1.SelectedTab = tbPg_listDuties;
        }

        // get selected duty information
        private void dtGrdVw_dutyList_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            foreach (DataGridViewRow row in dtGrdVw_dutyList.SelectedRows)
            {
                Duty duty = new Duty();
                duty.ID = (Guid)row.Cells["ID"].Value;

                dutyIDToSendDutyToControl = new Guid();
                dutyIDToSendDutyToControl = duty.ID;

                duty.sender = (string)row.Cells["sender"].Value;
                duty.toPersonnel = (string)row.Cells["toPersonnel"].Value;
                duty.subject = (string)row.Cells["subject"].Value;
                duty.content = (string)row.Cells["content"].Value;
                duty.explanation = (string)row.Cells["explanation"].Value;
                duty.startDate = (DateTime)row.Cells["startDate"].Value;
                duty.endDate = (DateTime)row.Cells["endDate"].Value;
                duty.sendControl = row.Cells["sendControl"].Value != null ? (bool)row.Cells["sendControl"].Value : false;
                duty.completed = row.Cells["completed"].Value != null ? (bool)row.Cells["completed"].Value : false;
                duty.failed = row.Cells["failed"].Value != null ? (bool)row.Cells["failed"].Value : false;
                showDutyInformation(duty);
            }
            tabControl1.SelectedTab = tbPg_personnelDutyDetail;
            bttn_sendDutyToControl.Enabled = true;

        }

        // show duty information detailed
        public void showDutyInformation(Duty duty)
        {
            txtBx_dutyDetailsSender.Text = duty.sender;
            txtBx_dutyDetailSubject.Text = duty.subject;
            txtBx_dutyDetailContent.Text = duty.content;
            txtBx_dutyDetailExplanation.Text = duty.explanation;
            dtTm_dutyDetailDueDate.Value = duty.endDate;
        }

        public void clearTextBoxes()
        {
            txtBx_dutyDetailsSender.Text = "";
            txtBx_dutyDetailSubject.Text = "";
            txtBx_dutyDetailContent.Text = "";
            txtBx_dutyDetailExplanation.Text = "";
            dtTm_dutyDetailDueDate.Value = DateTime.Parse("30-09-2024");
        }


    }
}
