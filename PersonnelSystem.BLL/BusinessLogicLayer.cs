using PersonnelSystem.Entities;
using PersonnelSystem.TL;

namespace PersonnelSystem.BLL
{
    public class BusinessLogicLayer
    {
        TransformationLayer TL;
        public BusinessLogicLayer()
        {
            TL = new TransformationLayer();
        }

        // get personnel information using ID
        public Personnel getPersonnel(Guid PersonnelID)
        {
            return TL.getPersonnel(PersonnelID);
        }

        // get personnel ID when personnel mail is given 
        public Guid getPersonnelIDFromTL(string personnelMail)
        {
            return TL.getPersonnelIDFromDLL(personnelMail);
        }

        // send password and ID to TL to enregister personnel password 
        public void sendPasswordToTLToEnregisterPersonnelPassword(PersonnelPassword personnelPassword)
        {
            TL.sendPasswordToDLLToEnregisterPersonnelPassword(personnelPassword);
        }

        // send personnel ID and password to TL to check their validity
        public PersonnelPassword checkPersonnelPassword(PersonnelPassword personnelPassword)
        {
            return TL.checkPersonnelPassword(personnelPassword);
        }

        // get personnel list from TL and send it to VL of manager form
        public List<Personnel> getAllPersonnels(Personnel personnel)
        {
            return TL.getAllPersonnelDLLtoBLL(personnel);
        }

        // send personnel data to TL (delete personnel operation)
        public void sendPersonnelToTLToDelete(Personnel personnel)
        {
            TL.sendPersonnelToDLLToDelete(personnel);
        }
        // send personnel data to TL (add new personnel operation)
        public void sendPersonnelToTLToAdd(Personnel personnel)
        {
            TL.sendPersonnelToDLLToAdd(personnel);
        }
        // send personnel data to TL (update personnel data operation)
        public void sendPersonnelToTLToUpdate(Personnel personnel)
        {
            TL.sendPersonnelToDLLToUpdate(personnel);
        }

        // get personnels to assign as manager

        public List<Personnel> sendPersonnelToVLToAssignAsManager()
        {
            return TL.sendDataToBLLPersonnelAssignAsManager();
        }

        // get personnels to assign to manager
        public List<Personnel> sendPersonnelToVLToAssignToManager()
        {
            return TL.sendDataToBLLPersonnelAssignToManager();
        }
        // send manager and personnel IDs to TL to create manager personnel pair
        public void sendManagerPersonnelIDToTL(Guid managerID, Guid personnelID)
        {
            TL.sendManagerPersonnelIDToDLL(managerID, personnelID);
        }

        // send manager - personnel pair list to validation layer of manager form
        public List<ManagerPersonnel> sendPersonnelManagerListToVLManagerForm()
        {
            return TL.sendPersonnelManagerListToBLL();
        }

        // send new duty to TL
        public int sendNewDutyToTL(Duty newDuty)
        {
            return TL.sendNewDutyToDLL(newDuty);
        }

        // get all personnel duties using personnel mail
        public List<Duty> getAllDuties(string personnelMail)
        {
            return TL.getAllDuties(personnelMail);
        }

        // send duty to manager for control/check operation
        public void sendDutyToManager(Guid dutyID)
        {
            TL.sendDutyToManagerToControl(dutyID);
        }

        // send duty to mssql for update/delete operation
        public void sendDutyForUpdateDeleteOperation(Duty updateDuty)
        {
            TL.sendDutyForUpdateDeleteOperation(updateDuty);
        }

    }
}