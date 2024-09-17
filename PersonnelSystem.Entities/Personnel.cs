namespace PersonnelSystem.Entities
{
    public class Personnel
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Mail { get; set; }
        public string Title { get; set; }
        public string JobTitle { get; set; }
        public decimal Salary { get; set; }
        public decimal DaysOff { get; set; }
        public decimal UsedDaysOff { get; set; }
        public bool quitJob { get; set; }
        public int authority { get; set; }


        public override string ToString()
        {
            return $"{Name} {Surname}";
        }

    }


}
