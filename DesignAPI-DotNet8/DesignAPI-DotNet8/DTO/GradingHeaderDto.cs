namespace DesignAPI_DotNet8.DTO
{
    public class GradingHeaderDto
    {
        public int Id { get; set; }
        public string Increment { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; } = true;
        public List<int> ProductTypeIds { get; set; }
        public List<string> SizeNames { get; set; }
    }
}
