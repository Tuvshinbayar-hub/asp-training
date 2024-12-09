using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Grading
{
    public class ToleranceDetail: Base
    {
        public string Tolerance {  get; set; }
        
        public string DimensionName { get; set; }
        public Dimension Dimension { get; set; }

        public float ToleranceMinus { get; set; } = 0f;
        public float TolerancePlus { get; set; } = 0f;
    }
}