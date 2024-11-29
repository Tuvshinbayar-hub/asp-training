using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.JobMasters;

namespace DesignAPI_DotNet8.Models.Factories
{
    public class FactorySection: Base
    {
        public string Name { get; set; }

        public int? LineId { get; set; }
    }
}
