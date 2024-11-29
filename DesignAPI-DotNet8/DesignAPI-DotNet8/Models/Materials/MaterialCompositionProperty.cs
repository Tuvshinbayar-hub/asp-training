using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Materials
{
    public class MaterialCompositionProperty: Base
    {
        public string Name { get; set; }
        public bool IsOKForMaterial { get; set; } = true;
        public bool IsOkForStyle { get; set; } = true;
        public string? Mongolian { get; set; }
    }
}