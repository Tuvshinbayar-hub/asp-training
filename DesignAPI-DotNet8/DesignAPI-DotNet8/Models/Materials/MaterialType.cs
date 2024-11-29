using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialType: Base
    {
        public string Name { get; set; }

        public int? MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }
        
        public List<int>? MaterialCompositionIds { get; set; }
        public List<MaterialComposition>? MaterialComposition { get; set; }
    }
}