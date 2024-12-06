using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;
using DesignAPI_DotNet8.Models.Sizes;

namespace DesignAPI_DotNet8.Models.Grading
{
    public class Dimension : BaseCreation
    {
        // FK
        public string DimensionName { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }

        public List<int>? ProductTypeId { get; set; }
        public List<ProductType>? ProductType { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;
    }
}