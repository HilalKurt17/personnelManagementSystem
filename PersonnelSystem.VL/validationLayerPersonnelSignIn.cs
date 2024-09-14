using PersonnelSystem.BLL;
using PersonnelSystem.Entities;

namespace PersonnelSystem.VL
{
    public class validationLayerPersonnelSignIn
    {
        BusinessLogicLayer BLL;

        public validationLayerPersonnelSignIn()
        {
            BLL = new BusinessLogicLayer();
        }

        // get personnel ID when personnel mail is given 
        public Guid getPersonnelIDFromBLL(string personnelMail)
        {
            return BLL.getPersonnelIDFromTL(personnelMail);
        }

        // send password and ID to BLL to enregister personnel password 
        public void sendPasswordToBLLToEnregisterPersonnelPassword(Guid personnelID, string _personnelPassword)
        {

            PersonnelPassword personnelPassword = new PersonnelPassword();
            personnelPassword.ID = personnelID;
            personnelPassword.password = _personnelPassword;
            BLL.sendPasswordToTLToEnregisterPersonnelPassword(personnelPassword);
        }

        // check textboxes are empty or not
        public int controlTextBoxes(string personnelID, string personnelPassword)
        {
            if (String.IsNullOrEmpty(personnelID) || String.IsNullOrEmpty(personnelPassword))
                return -1; // if textboxes are empty return -1 to warn user
            else return 1; // if textboxes are not empty, then return 1 to execute the next code
        }

        // check whether password is null or not. if it is null, then assign the new password as personnel password
        public int checkPersonnelPassword(Guid personnelID, string password)
        {
            try
            {
                PersonnelPassword personnelPassword = new PersonnelPassword();
                personnelPassword.ID = personnelID;
                personnelPassword.password = password;

                PersonnelPassword _personnelPassword = BLL.checkPersonnelPassword(personnelPassword);
                if (_personnelPassword.ID == Guid.Empty)
                {
                    // there is no personnel with given ID
                    return -1; // wrong ID
                }
                else if (_personnelPassword.password == null)
                {
                    // there is a personnel with given ID but password was not determined (determine password and store it in the database)

                    return 0; // password is recorded
                }
                else
                {
                    // there is a personnel with given ID and the password is already determined
                    if (_personnelPassword.password != personnelPassword.password)
                    {
                        return -2; // wrong password
                    }
                    else
                    {
                        return 1; // successfull entrance
                    }
                }
            }
            catch
            {
                return -3; // invalid data type 
            }
        }

        public Personnel getPersonnelInformation(Guid personnelID)
        {
            return BLL.getPersonnel(personnelID);
        }
    }
}
