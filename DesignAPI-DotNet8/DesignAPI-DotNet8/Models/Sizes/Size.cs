using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class Size: BaseCreation
    {
        public string Name { get; set; }
        public int SkuSizeCode { get; set; }
        public int SortOrder { get; set; }

        public int DimensionTypeId { get; set; }
        public DimensionType DimensionType { get; set; }

        public List<int>? ProductTypesIds { get; set; }
        public List<ProductType>? ProductTypes { get; set; }

        public List<int>? SizeGroupIds { get; set; }
        public SizeGroup? SizeGroup { get; set; }
    }
}