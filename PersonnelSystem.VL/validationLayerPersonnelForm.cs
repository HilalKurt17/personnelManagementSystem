using PersonnelSystem.BLL;
using PersonnelSystem.Entities;

namespace PersonnelSystem.VL
{
    public class validationLayerPersonnelForm
    {
        BusinessLogicLayer BLL;


        public validationLayerPersonnelForm()
        {
            BLL = new BusinessLogicLayer();
        }

        // control textboxes are empty or not
        public int controlTextBoxes(string _sender, string To, string subject, string context)
        {
            if (String.IsNullOrEmpty(subject) && String.IsNullOrEmpty(To) && String.IsNullOrEmpty(_sender) && String.IsNullOrEmpty(context))
            {
                return -1; // if there is an empty textbox, return -1 to warn user
            }
            return 1;
        }

        // get all duties of the personnel
        public List<Duty> getMyDuties(string personnelMail)
        {
            return BLL.getAllDuties(personnelMail);
        }

        // send duty to manager for control/check operation
        public void sendDutyToManager(Guid dutyID)
        {
            BLL.sendDutyToManager(dutyID);
        }
    }
}
