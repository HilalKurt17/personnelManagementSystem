namespace PersonnelSystem.WFUI
{
    public partial class signInForm : Form
    {
        public signInForm()
        {
            InitializeComponent();
        }

        private void bttn_managerSignIn_Click(object sender, EventArgs e)
        {
            Forms.Instance.ManagerSignIn.Show();
            Forms.Instance.SignInForm.Hide();
        }

        private void bttn_personnelSignIn_Click(object sender, EventArgs e)
        {
            Forms.Instance.PersonnelSignIn.Show();
            Forms.Instance.SignInForm.Hide();
        }
    }
}