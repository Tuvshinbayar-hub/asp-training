using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Factory
{
    public class MachineName: Base
    {
        public string Name { get; set; }
        
        public int? MachineTypeId { get; set; }
        public MachineType? MachineType { get; set; }
    }
}
