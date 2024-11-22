using DesignAPI_DotNet8.Models.BaseModels;
using System.Security.Cryptography.Pkcs;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class ToleranceValue: Base
    {
        public int DimensionId { get; set; }
        public Dimension Dimension { get; set; }

        public List<float> Values { get; set; } = new List<float>();

        public ToleranceValue()
        {
            Values = new List<float>(new float[2]);
        }
    }
}
