namespace OCCU_Assessment.Models
{
    public class ComparisonResult
    {
        public string FieldName { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
        public bool IsDifferent => Value1 != Value2;
    }
}
