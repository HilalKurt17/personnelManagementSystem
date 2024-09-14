using PersonnelSystem.Entities;
using PersonnelSystem.VL;

namespace PersonnelSystem.WFUI
{
    public partial class managerSignIn : Form
    {
        validationLayerManagerSignIn VL;
        public managerSignIn()
        {
            VL = new validationLayerManagerSignIn();
            InitializeComponent();
        }


        private void bttn_managerSignIn_Click(object sender, EventArgs e)
        {
            string managerMail = txtBx_managerMail.Text;
            string managerPassword = txtBx_password.Text;

            int result = VL.controlTextBoxes(managerMail, managerPassword);
            if (result == -1)
            {
                MessageBox.Show("Lütfen bilgileri eksiksiz bir şekilde doldurun.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Guid managerID = VL.getPersonnelID(managerMail);
                if (managerID == Guid.Empty)
                {
                    MessageBox.Show("Hatalı kullanıcı maili veya şifresi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Personnel manager = VL.getPersonnel(managerID);
                    if (manager.authority == 2 || manager.authority == 3)
                    {
                        int results = VL.checkManagerEntrance(manager.ID, managerPassword);
                        if (results == 1)
                        {


                            Forms.Instance.ManagerForm.manager = manager;


                            Forms.Instance.ManagerForm.Show();
                            Forms.Instance.ManagerSignIn.Hide();

                        }
                        else
                        {
                            MessageBox.Show("Hatalı kullanıcı maili veya şifresi.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Yetkili değilsiniz.", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }

            }
        }
    }
}
