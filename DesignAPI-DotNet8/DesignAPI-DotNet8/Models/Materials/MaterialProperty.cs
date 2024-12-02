using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Factories;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialProperty: BaseWithModified
    {
        public string Code { get; set; }
        public string Name { get; set; }

        public int MaterialTypeId { get; set; }
        public MaterialType MaterialType { get; set; }

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
        public int AverageUnitCost { get; set; } = 0;

        // public int? ImageId { get; set; }
        // public Image Image { get; set; }

        public string? Description { get; set; }
        
        public int? UnitOfMeasureId { get; set; }
        public UnitOfMeasure? UnitOfMeasure { get; set; }

        public int? UnitOfWeightId { get; set; }
        public UnitOfWeight? UnitOfWeight { get; set; }

        // Image
        // Material Type
        // Material Subtype
        // Material Name
        // Material Code
        // Product Type
        // Product Name
        // Material Description
        // Additional information
        // Composition
        // Average Unit Cost
        // Average Weight
        // Style Fabric
        // Ply
        // Yarn Twist Code
        // Registration Code
        // Client
        // Size
        // Number of stitches
        // Base type
        // Order type
        // Collection
        // Chemical Code
        // Country
        // Base knitting type
        // Base weaving type
        // Base yarn count
        // Logo
        // Label type
        // Responsiblies of the herders
        // Livestock health and welfare
        // State of pasture
        // Quality and safety of raw materials
        // Microns
        // Fair trade
    }
}