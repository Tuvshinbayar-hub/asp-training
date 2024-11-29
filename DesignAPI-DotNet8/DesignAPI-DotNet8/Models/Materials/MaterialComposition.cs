using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialComposition: Base
    {
        public int MaterialCompositionPropetyId;
        public MaterialCompositionProperty MaterialCompositionProperty { get; set; }

        public int Percentage;
    }
}
