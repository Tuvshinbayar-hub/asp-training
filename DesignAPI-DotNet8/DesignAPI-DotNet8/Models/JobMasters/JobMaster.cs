using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Factories;

namespace DesignAPI_DotNet8.Models.JobMasters
{
    public class JobMaster: BaseWithModified
    {
        public string Name { get; set; } = "(Unnamed)";
        public string? JobId { get; set; }

        public int? FactoryId { get; set; }
        public Factory? Factory { get; set; }

        public int? SectionId { get; set; }
        public JobMasterSection Section { get; set; }

        public string? Description { get; set; }
        public string? Translation { get; set; }

        public string? Classification1 { get; set; }

        public int? Classification2Id { get; set; }
        public JobMasterClassification2? Classification2 { get; set; }
    
        public string? Classification3 { get; set; }
        public string? KnittingLoop { get; set; }
        public WorkerType? WorkerType { get; set; }
        public int Quantity { get; set; } = 0;

        // public int? MachineNameTypeId { get; set; }
        // public MachineNameType MachineNameType { get; set; }

        public int? ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
        public JobLevel? JobLevel { get; set; }
        public JobCondition? JobCondition { get; set; }
        public int HourlyRate { get; set; } = 0;
        public float Ratio { get; set; } = 0f;

        public float SmallSizeTimeProto { get; set; } = 0f;
        public float MediumSizeTimeProto { get; set; } = 0f;
        public float LargeSizeTimeProto { get; set; } = 0f;

        public float SmallSizeCostProto { get; set; } = 0f;
        public float MediumSizeCostProto { get; set; } = 0f;
        public float LargeSizeCostProto { get;set; } = 0f;

        public float SmallSizeTimeMass { get; set; } = 0f;
        public float MediumSizeTimeMass { get; set; } = 0f;
        public float LargestSizeTimeMass { get; set; } = 0f;

        public float Tight { get; set; } = 0f;
        public float Regular { get; set; } = 0f;
        public float Loose { get; set; } = 0f;

        public bool ColorPatternSensitive { get; set; } = false;
        public float SensitiveExtraPercent { get; set; } = 0f;
    }
}
