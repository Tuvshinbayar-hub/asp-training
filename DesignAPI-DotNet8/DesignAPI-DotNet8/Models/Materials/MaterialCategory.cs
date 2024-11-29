using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialCategory: Base
    {
        public string Name { get; set; }
        
        public int? MaterialSubtypeId { get; set; }
        public MaterialSubType? MaterialSubType { get; set; }
    }
}
