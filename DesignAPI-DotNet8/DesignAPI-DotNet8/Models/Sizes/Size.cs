using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class Size: BaseCreation
    {
        public int SkuSizeCode { get; set; }

        // FK
        public string SizeName { get; set; }

        public List<int>? ProductTypesIds { get; set; }
        public List<ProductType>? ProductTypes { get; set; }

        public int? DimensionTypeId { get; set; }
        public DimensionType? DimensionType { get; set; }

        public int SortOrder { get; set; } = 0;

        public int? SizeGroupId { get; set; }
        public SizeGroup? SizeGroup { get; set; }
    }
}