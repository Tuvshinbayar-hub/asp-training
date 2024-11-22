using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Supplier
{
    public class Supplier: BaseCreation
    {
        public string Name { get; set; }
        public int SupplierId { get; set; }
        
        public SupplierType SupplierType { get; set; }

        public int? Classification1Id { get; set; }
        public Classification1? Classification1 { get; set; }

        public int? Classification2Id { get; set; }
        public Classification2? Classification2 { get; set; }

        public string? Purpose { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public string? ProvinceOrState {  get; set; }
        public string? City { get; set; }
        public string? Address {  get; set; }
        public string? PostalCode { get; set; }
        
        public List<int>? ContactIds { get; set; }
        public List<Contacts> Contacts { get; set; }
        // contacts

    }
}
