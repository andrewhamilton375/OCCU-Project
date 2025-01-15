namespace OCCU_Assessment.Models
{
    public class DataItem
    {
        public string Name { get; set; } // Unique
        public string Field1 { get; set; }
        public string Field2 { get; set; }
        public string Field3 { get; set; }
        public DateTime UpdateTimeStamp { get; set; }
        public bool IsSelected { get; set; }
    }
}
