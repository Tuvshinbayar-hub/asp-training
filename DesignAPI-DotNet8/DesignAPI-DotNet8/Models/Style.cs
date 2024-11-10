using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models
{
    public class Style
    {
        public int Id { get; set; }
        public required string Code { get; set; }
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Season { get; set; }
    }
}
