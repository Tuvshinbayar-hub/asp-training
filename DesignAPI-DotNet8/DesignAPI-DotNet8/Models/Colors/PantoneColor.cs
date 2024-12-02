using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Colors
{
    public class PantoneColor : BaseWithModified
    {
        public string GobiColorCode { get; set; }
        public string PantoneColorName { get; set; }
        public string PantoneColorCode { get; set; }

        public bool IsOkForStyle { get; set; } = true;
        public bool IsOkForMaterial { get; set; } = true;
        public bool IsActive { get; set; } = true;

        public int? ColorGroupId {  get; set; } 
        public ColorGroup? ColorGroup { get; set; }

        public string? RgbHex { get; set; }
        public string? RgbTriple { get; set; }

        public int? ImageId { get; set; }
        public Image? Image { get; set; }
    }
}