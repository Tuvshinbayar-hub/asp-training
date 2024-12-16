using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Sizes;

namespace DesignAPI_DotNet8.Models.Grading
{
    public class GradingPitch: Base
    {
        // Fk
        public string Increment { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }

        public string DimensionName { get; set; }
        public Dimension Dimension { get; set; }

        public List<float> Increments { get; set; }
    }
}