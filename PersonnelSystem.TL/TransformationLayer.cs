using PersonnelSystem.DLL;
using PersonnelSystem.Entities;
using System.Data.SqlClient;

namespace PersonnelSystem.TL
{
    public class TransformationLayer
    {
        SqlDataReader reader;
        DataLogicLayer DLL;
        public TransformationLayer()
        {
            DLL = new DataLogicLayer();
        }

        // get personnel information from ID
        public Personnel getPersonnel(Guid PersonnelID)
        {
            reader = DLL.getPersonnel(PersonnelID);
            List<Personnel> listPersonnel = convertDataToPersonnelEntity(reader);
            return listPersonnel[0];
        }

        // get personnel ID when personnel mail is given 
        public Guid getPersonnelIDFromDLL(string personnelMail)
        {
            reader = DLL.getPersonnelIDWhenPersonnelMailGiven(personnelMail);
            Guid personnelID = Guid.Empty;
            while (reader.Read())
            {
                personnelID = reader.GetGuid(reader.GetOrdinal("PersonnelID"));
            }
            DLL.ConnectDisconnect();
            return personnelID;
        }


        // send password and ID to DLL to enregister personnel password 
        public void sendPasswordToDLLToEnregisterPersonnelPassword(PersonnelPassword personnelPassword)
        {
            DLL.enregisterPersonnelPassword(personnelPassword);
        }


        // check personnel id and password
        public PersonnelPassword checkPersonnelPassword(PersonnelPassword personnelPassword)
        {
            PersonnelPassword _personnelPassword = new PersonnelPassword();
            reader = DLL.checkPersonnelPassword(personnelPassword);
            while (reader.Read())
            {
                _personnelPassword.ID = reader.GetGuid(reader.GetOrdinal("PersonnelID"));
                _personnelPassword.password = reader["PersonnelPassword"] != DBNull.Value ? reader.GetString(reader.GetOrdinal("PersonnelPassword")) : null;
            }
            DLL.ConnectDisconnect();
            return _personnelPassword;
        }

        // get raw data from DLL and convert it into personnel entity. Then return all personnels as a list
        public List<Personnel> getAllPersonnelDLLtoBLL(Personnel personnel)
        {
            reader = DLL.getAllPersonnels(personnel);
            return convertDataToPersonnelEntity(reader);
        }

        // send personnels with authority 1 or 2 to assign them to manager
        public List<Personnel> sendDataToBLLPersonnelAssignToManager()
        {
            reader = DLL.getPersonnelsToAssignManager();
            return convertDataToPersonnelEntity(reader);
        }

        // get personnel - manager List from dll
        public List<ManagerPersonnel> sendPersonnelManagerListToBLL()
        {
            List<ManagerPersonnel> personnelManagerPair = new List<ManagerPersonnel>();
            reader = DLL.getAllPersonnelManagerListFromDatabase();
            while (reader.Read())
            {
                ManagerPersonnel pair = new ManagerPersonnel();
                pair.PersonnelID = reader.GetGuid(reader.GetOrdinal("PersonnelID"));
                pair.PersonnelName = reader.GetString(reader.GetOrdinal("PersonnelName"));
                pair.PersonnelSurname = reader.GetString(reader.GetOrdinal("PersonnelSurname"));
                pair.PersonnelJobTitle = reader.GetString(reader.GetOrdinal("PersonnelJobTitle"));
                pair.ManagerID = reader.GetGuid(reader.GetOrdinal("ManagerID"));
                pair.ManagerName = reader.GetString(reader.GetOrdinal("ManagerName"));
                pair.ManagerSurname = reader.GetString(reader.GetOrdinal("ManagerSurname"));
                pair.ManagerJobTitle = reader.GetString(reader.GetOrdinal("ManagerJobTitle"));
                personnelManagerPair.Add(pair);

            }
            DLL.ConnectDisconnect();
            return personnelManagerPair;
        }


        // send personnels with authority 3 or 2 to assign them as manager
        public List<Personnel> sendDataToBLLPersonnelAssignAsManager()
        {
            reader = DLL.getPersonnelsToAssignAsManager();
            return convertDataToPersonnelEntity(reader);
        }

        // convert data to personnel entity
        public List<Personnel> convertDataToPersonnelEntity(SqlDataReader reader)
        {
            List<Personnel> personnelList = new List<Personnel>();
            while (reader.Read())
            {
                Personnel personnel = new Personnel();
                personnel.ID = reader.GetGuid(reader.GetOrdinal("PersonnelID"));
                personnel.Name = reader.GetString(reader.GetOrdinal("PersonnelName"));
                personnel.Surname = reader.GetString(reader.GetOrdinal("PersonnelSurname"));
                personnel.Mail = reader.GetString(reader.GetOrdinal("PersonnelMail"));
                personnel.Title = reader.GetString(reader.GetOrdinal("PersonnelTitle"));
                personnel.JobTitle = reader.GetString(reader.GetOrdinal("PersonnelJobTitle"));
                personnel.Salary = reader.GetDecimal(reader.GetOrdinal("PersonnelSalary"));
                personnel.DaysOff = reader.GetDecimal(reader.GetOrdinal("PersonnelDaysOff"));
                personnel.UsedDaysOff = reader.GetDecimal(reader.GetOrdinal("PersonnelUsedDaysOff"));
                personnel.quitJob = reader.GetBoolean(reader.GetOrdinal("PersonnelQuitJob"));
                personnel.authority = reader.GetByte(reader.GetOrdinal("PersonnelAuthority"));

                personnelList.Add(personnel);
            }
            DLL.ConnectDisconnect();
            return personnelList;
        }
        // send personnel data to delete the personnel (quit job)
        public void sendPersonnelToDLLToDelete(Personnel personnel)
        {
            DLL.deletePersonnel(personnel);
        }

        // send personnel data to add new personnel to Personnels table
        public void sendPersonnelToDLLToAdd(Personnel personnel)
        {
            DLL.addPersonnel(personnel);
        }

        // send personnel data to update personnel in the Personnels table
        public void sendPersonnelToDLLToUpdate(Personnel personnel)
        {
            DLL.updatePersonnel(personnel);
        }

        // send manager ID and personnel ID to DLL to create manager-personnel pair
        public void sendManagerPersonnelIDToDLL(Guid managerID, Guid PersonnelID)
        {
            DLL.addPersonnelToManager(managerID, PersonnelID);
        }

        // send new duty to DLL
        public int sendNewDutyToDLL(Duty newDuty)
        {
            return DLL.addNewDuty(newDuty);
        }

        // get all duties for a personnel, which personnel mail is given, from database
        public List<Duty> getAllDuties(string personnelMail)
        {
            List<Duty> dutyList = new List<Duty>();
            reader = DLL.getMyDuties(personnelMail);
            while (reader.Read())
            {
                Duty duty = new Duty();
                duty.ID = reader.GetGuid(reader.GetOrdinal("DutyID"));
                duty.sender = reader.GetString(reader.GetOrdinal("sender"));
                duty.toPersonnel = reader.GetString(reader.GetOrdinal("toPersonnel"));
                duty.subject = reader.GetString(reader.GetOrdinal("dutySubject"));
                duty.content = reader.GetString(reader.GetOrdinal("content"));
                duty.explanation = !reader.IsDBNull(reader.GetOrdinal("explanation")) ? reader.GetString(reader.GetOrdinal("explanation")) : null;
                duty.startDate = reader.GetDateTime(reader.GetOrdinal("startDate"));
                duty.endDate = reader.GetDateTime(reader.GetOrdinal("endDate"));
                duty.completed = !reader.IsDBNull(reader.GetOrdinal("completed")) ? reader.GetByte(reader.GetOrdinal("completed")) == 1 : null;
                duty.failed = !reader.IsDBNull(reader.GetOrdinal("failed")) ? reader.GetByte(reader.GetOrdinal("failed")) == 1 : null;
                duty.sendControl = !reader.IsDBNull(reader.GetOrdinal("sendControl")) ? reader.GetBoolean(reader.GetOrdinal("sendControl")) : null;
                dutyList.Add(duty);
            }
            DLL.ConnectDisconnect();
            return dutyList;
        }

        // send duty to manager for control/check operation
        public void sendDutyToManagerToControl(Guid dutyID)
        {
            DLL.sendDutyToControl(dutyID);
        }

        // send duty to mssql for update/delete operation
        public void sendDutyForUpdateDeleteOperation(Duty updateDuty)
        {
            DLL.sendDutyToUpdateDelete(updateDuty);
        }
    }
}