using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Grading
{
    public class ToleranceHeader: BaseCreation
    {
        public string Tolerance { get; set; }
        public ToleranceDetail ToleranceDetail { get; set; }

        public string? Description { get; set; }
        
        public List<string>? DimensionNames { get; set; }
        public List<Dimension>? Dimensions { get; set; }

        public List<string>? Increments { get; set; }
        public List<GradingHeader>? GradingHeaders { get; set; }

        public bool IsActive { get; set; }
    }
}