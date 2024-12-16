namespace DesignAPI_DotNet8.DTO
{
    public class GradingPitchDto
    {
        public int Id { get; set; }
        public string Increment { get; set; }
        public string DimensionName { get; set; }
        public int? ProductTypeId { get; set; }
        public List<float> Increments { get; set; }
    }
}