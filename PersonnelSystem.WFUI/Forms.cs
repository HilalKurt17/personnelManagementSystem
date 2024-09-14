namespace PersonnelSystem.WFUI
{
    public sealed class Forms
    {
        private static readonly Forms instances = new Forms();

        public managerForm ManagerForm { get; private set; }
        public managerSignIn ManagerSignIn { get; private set; }
        public personnelForm PersonnelForm { get; private set; }
        public personnelSignIn PersonnelSignIn { get; private set; }
        public signInForm SignInForm { get; private set; }

        private Forms()
        {
            ManagerForm = new managerForm();
            ManagerSignIn = new managerSignIn();
            PersonnelForm = new personnelForm();
            PersonnelSignIn = new personnelSignIn();
            SignInForm = new signInForm();
        }

        public static Forms Instance
        {
            get
            {
                return instances;
            }
        }
    }
}
