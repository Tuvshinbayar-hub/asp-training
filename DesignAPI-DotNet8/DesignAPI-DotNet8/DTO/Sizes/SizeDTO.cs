namespace DesignAPI_DotNet8.DTO.Sizes
{
    public class SizeDTO
    {
        public int Id { get; set; }
        public int SkuSizeCode { get; set; }
        public string SizeName { get; set; }
        public int DimensionTypeId { get; set; }
        public int SortOrder { get; set; }
        public int? SizeGroupId { get; set; }
    }
}