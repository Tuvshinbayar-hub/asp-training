using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Customers
{
    public class Customer : BaseCreation
    {
        public string Name { get; set; }
        public string? CustomerId { get; set; }

        public int? RegionId { get; set; }
        public Region? Region { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public int? ShipToCountryId { get; set; }
        public Country? ShipToCountry { get; set; }

        public int? BillToCountryId { get; set; }
        public Country? BillToCountry { get; set; }

        public int? LabelId { get; set; }
        public Label? Label { get; set; }

        public SellerType? SellerType { get; set; } = null;
    }
}
