using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Factories
{
    public class MachineType: Base
    {
        public string Name { get; set; }

        public int? MachineVersionId { get; set; }
        public MachineVersion? MachineVersion { get; set; }
    }
}
