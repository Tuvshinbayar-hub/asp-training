using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class SizeRange: BaseCreation
    {
        // FK
        public string SizeRangeName {  get; set; }
        
        public int Dimension1TypeId { get; set; }
        public DimensionType Dimension1Type { get; set; }

        public List<ProductType>? ProductTypes { get; set; }

        public string? Description { get; set; }
        
        public List<Size>? Sizes { get; set; }

        public int? BaseSizeId { get; set; }
        public Size? BaseSize { get; set; }

        public bool IsOkForStyle {  get; set; } = true;
        public bool IsOkForMaterial { get; set; } = true;
        public bool IsOkForSizeChar { get; set; } = true;

        public int? SizeRangeCategoryId { get; set; }
        public SizeRangeCategory? SizeRangeCategory { get; set; }
    }
}