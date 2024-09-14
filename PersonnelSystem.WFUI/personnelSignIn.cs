using PersonnelSystem.Entities;
using PersonnelSystem.VL;


namespace PersonnelSystem.WFUI
{
    public partial class personnelSignIn : Form
    {
        validationLayerPersonnelSignIn VL;
        public personnelSignIn()
        {
            VL = new validationLayerPersonnelSignIn();
            InitializeComponent();
        }

        private void bttn_personnelSignIn_Click(object sender, EventArgs e)
        {
            string personnelMail = txtBx_personnelMail.Text;
            string personnelPassword = txtBx_password.Text;
            // firstly check whether textboxes are empty or not
            int result = VL.controlTextBoxes(personnelMail, personnelPassword);
            Guid personnelID = VL.getPersonnelIDFromBLL(personnelMail);
            if (result == -1) // if result is -1, there is an empty  textbox, warn user
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz bir şekilde doldurun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else
            {

                int results = VL.checkPersonnelPassword(personnelID, personnelPassword);
                if (results == 0) // personnel password is enregistered
                {
                    MessageBox.Show("Şifreniz başarıyla kayıt edildi. Lütfen bilgilerinizi tekrar giriniz.", "BİLGİLENDİRME", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    VL.sendPasswordToBLLToEnregisterPersonnelPassword(personnelID, personnelPassword);

                }
                else if ((results == -1) || (results == -2)) // ID is invalid (-1). ID is valid password is invalid(-2)
                {
                    MessageBox.Show("Yanlış şifre veya mail.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (results == -3) // invalid data type entrance
                {
                    MessageBox.Show("Geçersiz veri tipi girişi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (results == 1) // successfull entrance
                {
                    Personnel personnel = VL.getPersonnelInformation(personnelID);
                    Forms.Instance.PersonnelForm.personnel = personnel;
                    Forms.Instance.PersonnelForm.Show();
                    Forms.Instance.PersonnelSignIn.Hide();
                }


            }

            clearTextboxes();
        }
        // helper methods
        public void clearTextboxes()
        {
            txtBx_password.Text = "";
            txtBx_personnelMail.Text = "";
        }
    }
}
