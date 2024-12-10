namespace DesignAPI_DotNet8.DTO
{
    public class ToleranceHeaderDto
    {
        public int Id { get; set; }
        public string Tolerance { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public List<string> DimensionNames { get; set; }
        public List<string> Increments { get; set; }
    }

}
