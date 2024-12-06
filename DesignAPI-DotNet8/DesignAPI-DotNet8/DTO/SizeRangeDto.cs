namespace DesignAPI_DotNet8.DTO
{
    public class SizeRangeDto
    {
        public required int Id { get; set; }
        public required string SizeRangeName { get; set; }
        public required int Dimension1TypeId { get; set; }
        public required string Description { get; set; }
        public List<string>? SizeNames { get; set; }
        public List<int>? ProductTypeIds { get; set; }
    }
}