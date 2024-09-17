namespace PersonnelSystem.Entities
{
    public class Duty
    {
        public Guid ID { get; set; }
        public string sender { get; set; }
        public string toPersonnel { get; set; }
        public string subject { get; set; }
        public string content { get; set; }
        public string? explanation { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public bool? completed { get; set; }
        public bool? failed { get; set; }
        public bool? sendControl { get; set; }
    }
}
