using PersonnelSystem.BLL;
using PersonnelSystem.Entities;

namespace PersonnelSystem.VL
{
    public class validationLayerManagerSignIn
    {
        BusinessLogicLayer BLL;
        public validationLayerManagerSignIn()
        {
            BLL = new BusinessLogicLayer();
        }
        // check whether textboxes are filled or not
        public int controlTextBoxes(string managerMail, string managerPassword)
        {
            if (String.IsNullOrEmpty(managerMail) && String.IsNullOrEmpty(managerPassword))
            {
                return -1;// if there is an empty textbox return -1 to warn user
            }
            else return 1;
        }

        // get personnel information using personnel ID
        public Personnel getPersonnel(Guid PersonnelID)
        {
            return BLL.getPersonnel(PersonnelID);
        }

        // get personnel ID using personnel Mail
        public Guid getPersonnelID(string PersonnelMail)
        {
            return BLL.getPersonnelIDFromTL(PersonnelMail);
        }

        // get personnel ID and password to check
        public int checkManagerEntrance(Guid managerID, string ManagerPassword)
        {
            PersonnelPassword personnelPassword = new PersonnelPassword();
            personnelPassword.ID = managerID;
            personnelPassword.password = ManagerPassword;

            PersonnelPassword _DLLPersonnelPassword = BLL.checkPersonnelPassword(personnelPassword);
            if (personnelPassword.password == _DLLPersonnelPassword.password)
            {
                return 1; // entrance is successfully completed.
            }
            else
            {
                return -1; // entrance is failed
            }
        }
    }
}
