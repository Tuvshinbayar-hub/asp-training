using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Sizes;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace DesignAPI_DotNet8.Models.Grading
{
    public class GradingHeader: BaseCreation
    {
        public string Increment { get; set; }
        public string? Description { get; set; }
        
        public List<int>? ProductTypeIds { get; set; }
        public List<ProductType>? ProductTypes { get; set; }

        public SizeRange? SizeRange { get; set; }

        public List<Size>? Sizes {  get; set; }
        
        public Size? BaseSize { get; set; }
        
        // DimensionType1 is referenced from SizeRange
    }
}