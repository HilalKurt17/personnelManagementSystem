using PersonnelSystem.BLL;
using PersonnelSystem.Entities;

namespace PersonnelSystem.VL
{
    public class validationLayerManagerForm
    {
        BusinessLogicLayer BLL;
        public validationLayerManagerForm()
        {
            BLL = new BusinessLogicLayer();
        }
        // assign valid authorities of personnels to validAuthorities 
        List<decimal> validAuthorities = new List<decimal> { 1, 2, 3 };

        // send personnels to user interface to assign them as manager
        public List<Personnel> sendToWFUIPersonnelsToAssignAsManager()
        {
            return BLL.sendPersonnelToVLToAssignAsManager();
        }

        // send personnels to user interface to assign them to manager
        public List<Personnel> sendToWFUIPersonnelsToAssignToManager()
        {
            return BLL.sendPersonnelToVLToAssignToManager();
        }

        // send manager ID and personnel ID to BLL to create manager-personnel pair
        public void sendManagerPersonnelIDToBLL(Guid managerID, Guid personnelID)
        {
            BLL.sendManagerPersonnelIDToTL(managerID, personnelID);
        }


        // send all personnels to user interface
        public List<Personnel> getAllPersonnelToUI(Personnel personnel)
        {
            return BLL.getAllPersonnels(personnel);
        }

        // send personnel to bll to delete
        public void sendPersonnelDataToBLLToDelete(Personnel personnel)
        {
            BLL.sendPersonnelToTLToDelete(personnel);
        }

        // send personnel to bll to add
        public void sendPersonnelDataToBLLToAdd(Personnel personnel)
        {
            BLL.sendPersonnelToTLToAdd(personnel);
        }


        // send personnel to bll to update
        public void sendPersonnelDataToBLLToUpdate(Personnel personnel)
        {
            BLL.sendPersonnelToTLToUpdate(personnel);
        }

        // control user inputs and check whether they are valid or not.
        public int controlInputs(string daysOff, string personnelName, string personnelLastName, string personnelSalary, string personnelTitle, string personnelJobTitle, decimal personnelAuthority, string personnelMail)
        {
            if (String.IsNullOrEmpty(daysOff) && String.IsNullOrEmpty(personnelName) && String.IsNullOrEmpty(personnelLastName) && String.IsNullOrEmpty(personnelSalary) && String.IsNullOrEmpty(personnelTitle) && String.IsNullOrEmpty(personnelJobTitle) && String.IsNullOrEmpty(personnelMail))
            {
                return -1; // return -1 if there is an empty spaces
            }
            else if (!validAuthorities.Contains(personnelAuthority))
            {
                return -2; // return -2 if personnel Authority is not valid
            }
            else if (!personnelMail.Contains("@"))
            {
                return -3; // return -3 if personnel mail is invalid.
            }
            else return 1; // return 1 if there is no problem about inputs
        }

        // create new personnel to add [without id(it will be given automatically in the database stored proc)]
        public (Personnel, int) createPersonnel(string daysOff, string personnelName, string personnelLastName, string personnelSalary, string personnelTitle, string personnelJobTitle, int personnelAuthority, string personnelMail, decimal usedDaysOff)
        {
            (Personnel, int) returnValues;
            Personnel personnel = new Personnel();
            try
            {

                personnel.Name = personnelName;
                personnel.Surname = personnelLastName;
                personnel.Mail = personnelMail;
                personnel.Title = personnelTitle;
                personnel.JobTitle = personnelJobTitle;
                personnel.DaysOff = Decimal.Parse(daysOff);
                personnel.UsedDaysOff = usedDaysOff;
                personnel.Salary = Decimal.Parse(personnelSalary);
                personnel.authority = personnelAuthority;
                personnel.quitJob = false;
                returnValues.Item1 = personnel;
                returnValues.Item2 = 1;
                return returnValues;
            }
            catch
            {
                returnValues.Item1 = personnel;
                returnValues.Item2 = -1;
                return returnValues;
            }
        }

        // create updated personnel to update its informations (there is a control if user input type is not valid it will be informed)
        public (Personnel, int) createPersonnel(Guid personnelID, string personnelName, string personnelLastName, string personnelSalary, string personnelTitle, string personnelJobTitle, decimal personnelAuthority, string personnelMail, decimal usedDaysOff, string daysOff, bool quitJob)
        {
            (Personnel, int) returnValues;
            Personnel personnel = new Personnel();
            try
            {

                personnel.ID = personnelID;
                personnel.Name = personnelName;
                personnel.Surname = personnelLastName;
                personnel.Mail = personnelMail;
                personnel.Title = personnelTitle;
                personnel.JobTitle = personnelJobTitle;
                personnel.DaysOff = Decimal.Parse(daysOff);
                personnel.UsedDaysOff = usedDaysOff;
                personnel.Salary = Decimal.Parse(personnelSalary);
                personnel.authority = (int)personnelAuthority;
                personnel.quitJob = quitJob;
                returnValues.Item1 = personnel;
                returnValues.Item2 = 1;
                return returnValues;
            }


            catch
            {
                returnValues.Item1 = personnel;
                returnValues.Item2 = -1;
                return returnValues;
            }

        }


        // create a personnel instance to show selected personnel information in the dataGridView
        public Personnel showUpdatePersonnel(Guid personnelID, string personnelName, string personnelLastName, decimal personnelSalary, string personnelTitle, string personnelJobTitle, decimal personnelAuthority, string personnelMail, decimal usedDaysOff, decimal daysOff, bool quitJob)
        {
            Personnel personnel = new Personnel();

            personnel.ID = personnelID;
            personnel.Name = personnelName;
            personnel.Surname = personnelLastName;
            personnel.Mail = personnelMail;
            personnel.Title = personnelTitle;
            personnel.JobTitle = personnelJobTitle;
            personnel.DaysOff = daysOff;
            personnel.UsedDaysOff = usedDaysOff;
            personnel.Salary = personnelSalary;
            personnel.authority = (int)personnelAuthority;
            personnel.quitJob = quitJob;
            return personnel;
        }

        // send manager - personnel pair list to manager form
        public List<ManagerPersonnel> sendPersonnelManagerListToManagerForm()
        {
            return BLL.sendPersonnelManagerListToVLManagerForm();
        }

        // send new duty to BLL
        public int sendNewDutyToBLL(Duty newDuty)
        {
            return BLL.sendNewDutyToTL(newDuty);
        }

        // create new duty to add new duty
        public Duty createNewDutyToAddNewDuty(DateTime dueDate, DateTime startDate, string senderMail, string toPersonnelMail, string subject, string content, string explanation)
        {
            Duty newDuty = new Duty();
            newDuty.startDate = startDate;
            newDuty.endDate = dueDate;
            newDuty.sender = senderMail;
            newDuty.toPersonnel = toPersonnelMail;
            newDuty.subject = subject;
            newDuty.content = content;
            newDuty.explanation = explanation;
            return newDuty;
        }

        // get all duties using personnel mail
        public List<Duty> getAllDuties(string personnelMail)
        {
            return BLL.getAllDuties(personnelMail);
        }


        // send duty to BLL for update/delete operation
        public void sendDutyToUpdateDelete(Guid dutyID, string dutyExplanation, DateTime dutyDueDate, bool dutyCompleted)

        {
            Duty duty = new Duty();
            duty.explanation = dutyExplanation;
            duty.ID = dutyID;
            duty.completed = dutyCompleted;
            duty.failed = !dutyCompleted;
            duty.sendControl = false;
            duty.endDate = dutyDueDate;

            BLL.sendDutyForUpdateDeleteOperation(duty);
        }

        // send duty to BLL to manager for control/check operation
        public void sendDutyToManager(Guid dutyID)
        {
            BLL.sendDutyToManager(dutyID);
        }
    }
}
