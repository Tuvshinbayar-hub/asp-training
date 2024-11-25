using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Suppliers
{
    public class ProvinceState: Base
    {
        public string Name { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
