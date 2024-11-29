using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.Suppliers;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Factories
{
    public class Factory: BaseWithModified
    {
        public int? SupplierId { get; set; }
        public Supplier? Supplier { get; set; }

        public int? SectionId { get; set; }
        public FactorySection? Section { get; set; }

        public FactoryType FactoryType { get; set; } = FactoryType.Internal;

        public int? FactoryDistributionId { get; set; }
        public FactoryDistribution? FactoryDistribution { get; set; }

        public int MachineQuantity { get; set; } = 0;

        public int? MeasurementId { get; set; }
        public Measurement? Measurement { get; set; }

        // HourlyJobMachineAll = MachineQuantity * HourlyJobMachine
        // DailyJob = Hours * HourlyJobCapacity
        // DailyJobTime = DailyJob / Hours
        // MonthlyJob = Days * DailyJob
        // MonthlyJobTime = MonthJob / HourlyJobMachineAll
        public int Efficiency { get; set; } = 0;
        public float HourlyJobMachine { get; set; } = 0f;
        public float HourlyJobCapacity { get; set; } = 0f;
        public int Days { get; set; } = 30;
        public int Hours {  get; set; } = 0;
        public int Months { get; set; } = 0;
    }
}
