using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class IncrementValue: Base
    {
        public int DimensionId { get; set; }
        public Dimension Dimension { get; set; }

        public List<float?>? Values { get; set; }

        public IncrementValue(int length) {
            Values = new List<float?>(new float?[length]);
        }
    }
}