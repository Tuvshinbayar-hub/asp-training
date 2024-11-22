using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class SizeRange: BaseCreation
    {
        public string Name {  get; set; }
        
        public bool IsOkForStyle {  get; set; } = true;
        public bool IsOkForMaterial { get; set; } = true;
        public bool IsOkForSizeChar { get; set; } = true;

        public string? Description { get; set; }

        public int? BaseSizeId { get; set; }
        public Size? BaseSize { get; set; }

        public List<int>? SizeIds { get; set; }
        public List<Size>? Sizes { get; set; }
    }
}
