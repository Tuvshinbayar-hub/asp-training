using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class Dimension: BaseCreation
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        public int? DimensionTypeId {  get; set; }
        public DimensionType? DimensionType { get; set; }

        public bool IsActive { get; set; } = true;
        
        public List<int>? ProductTypeId { get; set; }
        public List<ProductType>? ProductType { get; set; }
        
        //public int? ImageId { get; set; }
        //public Image? Image { get; set; }
    }
}
