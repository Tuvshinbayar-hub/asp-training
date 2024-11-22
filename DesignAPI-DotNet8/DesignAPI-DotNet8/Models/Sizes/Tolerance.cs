using DesignAPI_DotNet8.Models.BaseModels;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class Tolerance: BaseCreation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public List<int>? ToleranceValueIds { get; set; }
        public List<ToleranceValue>? ToleranceValues { get; set; }
    }
}
