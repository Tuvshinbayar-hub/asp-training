namespace DesignAPI_DotNet8.DTO
{
    public class DimensionDto
    {
        public int Id { get; set; }
        public string DimensionName { get; set; }
        public int? ImageId { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> ProductTypeIds { get; set; }
    }
}
