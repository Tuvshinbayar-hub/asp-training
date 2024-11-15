using DesignAPI_DotNet8.Models.BaseModels;
using Org.BouncyCastle.Asn1.Mozilla;

namespace DesignAPI_DotNet8.Models
{
    public class GobiColor: BaseWithModified
    {
        public string GobiColorCode {  get; set; }
        public string FourDigitColorCode { get; set; }
        public bool MainFlag { get; set; }
        public ColorType ColorType { get; set; }
        public ColorGroup ColorGroup { get; set; }
        public PantoneColor PantoneColor { get; set; }
        public DyingMethod DyingMethod { get; set; }
    }
}
