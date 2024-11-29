using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialProperty: BaseWithModified
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

        // public int? ImageId { get; set; }
        // public Image Image { get; set; }

        public int? MaterialCategoryId { get; set; }
        public MaterialCategory? MaterialCategory { get; set; }

        public int? MaterialSubtypeId {  get; set; }
        public MaterialSubType? MaterialSubType { get; set; }

        public int? ProductTypeId { get; set; }
        public MaterialProductType? ProductType { get; set; }

        public List<int>? ProductNameId { get; set; }
        public List<ProductName>? ProductName { get; set; }

        public string? MaterialDescription { get; set; }
        public string? AdditionalInformation { get; set; }

        // public int? ImageId { get; set; }
        // public Image Image { get; set; }

        public string? Description { get; set; }
        
        public List<int>? MaterialCompositionIds { get; set; }
        public List<MaterialComposition>? MaterialCompositions { get; set; }
    }
}