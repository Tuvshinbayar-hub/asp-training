using DesignAPI_DotNet8.Models.BaseModels;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models
{
    public class User: Base
    {
        public required string Name { get; set; }
        public int Role { get; set; }
    }
}
