namespace ContosoUniverstity.Models
{
    public class Delinquent
    {
        public int ID { get; set; }
        public string LastName { get; set; }
        public string FirstMidName { get; set; }

        public RecentViolation? Violation { get; set; }
    }

    public enum RecentViolation
    {
        CleanRecord,
        MinorInfraction,
        SeriousInfraction,
        MajorInfraction,
        Expelled
    }
}
