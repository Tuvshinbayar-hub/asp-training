using DesignAPI_DotNet8.Models.BaseModels;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models
{
    public class PantoneColor: BaseWithModified
    {
        public string Name { get; set; }
        public string Code { get; set; }

        public bool IsOkForStyle { get; set; } = true;
        public bool IsOkForMaterial { get; set; } = true;
        public bool IsActive { get; set; } = true;

        public ColorGroup? ColorGroup { get; set; }
        public string? RgbHex { get; set; }
        public string? RgbTriple { get; set; }
        // public required User CreatedBy {get; set;}
    }
}
