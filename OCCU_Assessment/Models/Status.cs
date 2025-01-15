namespace OCCU_Assessment.Models
{
    public class Status
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public string Value { get; set; }   // "fail", "warn", "pass"

    }
}
