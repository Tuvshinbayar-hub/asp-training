using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.Sizes
{
    public class Increment: BaseCreation
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public List<int>? IncrementValueIds { get; set; }
        public List<IncrementValue>? IncrementValues { get; set; }
    }
}