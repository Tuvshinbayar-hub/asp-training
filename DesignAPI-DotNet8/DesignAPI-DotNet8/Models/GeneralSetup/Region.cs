using DesignAPI_DotNet8.Models.BaseModels;
using NuGet.Protocol.Plugins;

namespace DesignAPI_DotNet8.Models.GeneralSetup
{
    public class Region: Base
    {
        public string Name { get; set; }
        public bool IsActive { get; set; } = true;

        public List<int>? SellingCountriesIds { get; set; }
        public List<Country>? SellingCountries { get; set; }

        // Secondary Sales Regions - Not used in 
    }
}
