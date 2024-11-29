using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.JobMasters
{
    public class JobMasterSection: Base
    {
        public string Name { get; set; }

        public int? SectionId { get; set; }
        public JobMasterSection? Section { get; set; }
    }
}
