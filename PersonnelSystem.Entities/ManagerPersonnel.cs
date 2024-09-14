namespace PersonnelSystem.Entities
{
    public class ManagerPersonnel
    {
        public Guid PersonnelID { get; set; }
        public string PersonnelName { get; set; }
        public string PersonnelSurname { get; set; }
        public string PersonnelJobTitle { get; set; }
        public Guid ManagerID { get; set; }
        public string ManagerName { get; set; }
        public string ManagerSurname { get; set; }
        public string ManagerJobTitle { get; set; }
    }
}
