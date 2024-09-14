using PersonnelSystem.Entities;
using System.Data.SqlClient;

namespace PersonnelSystem.DLL
{
    public class DataLogicLayer
    {
        SqlConnection connect;
        SqlCommand command;
        SqlDataReader reader;
        SqlParameter returnValue;


        public DataLogicLayer()
        {
            connect = new SqlConnection("Data Source=.; initial catalog=PersonnelManagementSystem; user ID =sa; Password=1;");
        }
        // connect/close database
        public void ConnectDisconnect()
        {
            if (connect.State == System.Data.ConnectionState.Closed)
            {
                connect.Open();
            }
            else connect.Close();
        }
        // get all personnel from sql and send it to TL
        public SqlDataReader getAllPersonnels(Personnel personnel)
        {
            command = new SqlCommand("getAllPersonnel", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("personnelID", personnel.ID);
            command.Parameters.AddWithValue("personnelAuthority", personnel.authority);
            ConnectDisconnect();
            reader = command.ExecuteReader();
            return reader;
        }

        // add personnel' s manager to the database
        public void addPersonnelToManager(Guid managerID, Guid personnelID)
        {
            command = new SqlCommand("addManagerPersonnelPair", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("managerID", managerID);
            command.Parameters.AddWithValue("personnelID", personnelID);
            ConnectDisconnect();
            reader = command.ExecuteReader();
            ConnectDisconnect();
        }

        // get all personnel - manager list for personnel with authority is 3
        public SqlDataReader getAllPersonnelManagerListFromDatabase()
        {
            command = new SqlCommand("getAllPersonnelManagerPairs", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            ConnectDisconnect();
            return command.ExecuteReader();
        }


        // get personnels which authority is 1 or 2 to assign them to Manager
        public SqlDataReader getPersonnelsToAssignManager()
        {
            command = new SqlCommand("getPersonnelAccordingToPersonnelAuthority", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("authorityLevel", 1);
            command.Parameters.AddWithValue("authorityLevel2", 2);
            ConnectDisconnect();
            reader = command.ExecuteReader();
            return reader;

        }
        // get personnels with authority level 3 and 2 to assign them as Manager
        public SqlDataReader getPersonnelsToAssignAsManager()
        {
            command = new SqlCommand("getPersonnelAccordingToPersonnelAuthority", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("authorityLevel", 3);
            command.Parameters.AddWithValue("authorityLevel2", 2);
            ConnectDisconnect();
            reader = command.ExecuteReader();

            return reader;
        }

        // add new personnel to the Personnels table
        public void addPersonnel(Personnel personnel)
        {
            command = new SqlCommand("addPersonnel", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("PersonnelName", personnel.Name);
            command.Parameters.AddWithValue("PersonnelSurname", personnel.Surname);
            command.Parameters.AddWithValue("PersonnelMail", personnel.Mail);
            command.Parameters.AddWithValue("PersonnelTitle", personnel.Title);
            command.Parameters.AddWithValue("PersonnelJobTitle", personnel.JobTitle);
            command.Parameters.AddWithValue("PersonnelSalary", personnel.Salary);
            command.Parameters.AddWithValue("PersonnelDaysOff", personnel.DaysOff);
            command.Parameters.AddWithValue("PersonnelUsedDaysOff", personnel.UsedDaysOff);
            command.Parameters.AddWithValue("PersonnelQuitJob", personnel.quitJob);
            command.Parameters.AddWithValue("PersonnelAuthority", personnel.authority);

            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();
        }

        //delete personnel from Personnels and PersonnelPasswords tables
        public void deletePersonnel(Personnel personnel)
        {
            command = new SqlCommand("deletePersonnel", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("personnelID", personnel.ID);
            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();
        }

        // update personnel in the personnel table
        public void updatePersonnel(Personnel personnel)
        {
            command = new SqlCommand("updatePersonnel", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("personnelID", personnel.ID);
            command.Parameters.AddWithValue("name", personnel.Name);
            command.Parameters.AddWithValue("surname", personnel.Surname);
            command.Parameters.AddWithValue("mail", personnel.Mail);
            command.Parameters.AddWithValue("title", personnel.Title);
            command.Parameters.AddWithValue("jobTitle", personnel.JobTitle);
            command.Parameters.AddWithValue("salary", personnel.Salary);
            command.Parameters.AddWithValue("daysOff", personnel.DaysOff);
            command.Parameters.AddWithValue("usedDaysOff", personnel.UsedDaysOff);
            command.Parameters.AddWithValue("quitJob", personnel.quitJob);
            command.Parameters.AddWithValue("authority", personnel.authority);

            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();
        }


        public SqlDataReader getPersonnelIDWhenPersonnelMailGiven(string personnelMail)
        {
            command = new SqlCommand("GetPersonnelIDFromMail", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("PersonnelMail", personnelMail);
            ConnectDisconnect();
            return command.ExecuteReader();
        }

        // get personnel ID and password to check personnel password and IDs validity
        public SqlDataReader checkPersonnelPassword(PersonnelPassword personnelPassword)
        {
            command = new SqlCommand("checkPersonnelPassword", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("PersonnelID", personnelPassword.ID);
            ConnectDisconnect();
            return command.ExecuteReader();

        }

        // enregister personnel password and ID
        public void enregisterPersonnelPassword(PersonnelPassword personnelPassword)
        {
            command = new SqlCommand("addPersonnelPassword", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("PersonnelID", personnelPassword.ID);
            command.Parameters.AddWithValue("PersonnelPassword", personnelPassword.password);
            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();

        }

        // get personnel information from ID
        public SqlDataReader getPersonnel(Guid PersonnelID)
        {
            command = new SqlCommand("getPersonnel", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("PersonnelID", PersonnelID);
            ConnectDisconnect();
            return command.ExecuteReader();
        }

        // add new duty to sql database 
        public int addNewDuty(Duty newDuty)
        {
            returnValue = new SqlParameter();
            command = new SqlCommand("addDutyToPersonnel", connect);
            returnValue.Direction = System.Data.ParameterDirection.ReturnValue;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("sender", newDuty.sender);
            command.Parameters.AddWithValue("toPersonnel", newDuty.toPersonnel);
            command.Parameters.AddWithValue("dutySubject", newDuty.subject);
            command.Parameters.AddWithValue("content", newDuty.content);
            command.Parameters.AddWithValue("explanation", newDuty.explanation);
            command.Parameters.AddWithValue("startDate", newDuty.startDate);
            command.Parameters.AddWithValue("endDate", newDuty.endDate);
            command.Parameters.Add(returnValue);
            ConnectDisconnect();
            command.ExecuteNonQuery();
            int result = (int)returnValue.Value;
            ConnectDisconnect();
            return result;
        }

        // 
        public SqlDataReader getMyDuties(string personnelMail)
        {
            command = new SqlCommand("getAllDuties", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("personnelMail", personnelMail);
            ConnectDisconnect();
            return command.ExecuteReader();
        }

        // send completed duty to manager to control/check it
        public void sendDutyToControl(Guid dutyID)
        {
            command = new SqlCommand("sendDutyToControl", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("dutyID", dutyID);
            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();
        }

        // send duty to update or delete duty to database, if completed is 1, duty will be deleted by stored procedure. Otherwise, duty is updated.
        public void sendDutyToUpdateDelete(Duty updateDuty)
        {
            command = new SqlCommand("updateDuty", connect);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.Parameters.AddWithValue("dutyID", updateDuty.ID);
            command.Parameters.AddWithValue("explanation", updateDuty.explanation);
            command.Parameters.AddWithValue("endDate", updateDuty.endDate);
            command.Parameters.AddWithValue("completed", updateDuty.completed);
            command.Parameters.AddWithValue("failed", updateDuty.failed);
            command.Parameters.AddWithValue("sendControl", updateDuty.sendControl);
            ConnectDisconnect();
            command.ExecuteNonQuery();
            ConnectDisconnect();

        }
    }
}
