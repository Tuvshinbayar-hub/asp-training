using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;

namespace DesignAPI_DotNet8.Models.Suppliers
{
    public class Supplier: BaseCreation
    {
        public string Name { get; set; }
        public int SupplierId { get; set; }

        public bool IsAgent { get; set; } = false;
        public bool IsSupplier { get; set; } = false;
        public bool IsWarehose { get; set; } = false;
        
        public SupplierType SupplierType { get; set; }

        public int? Classification1Id { get; set; }
        public SupplierClassification1? Classification1 { get; set; }

        public int? Classification2Id { get; set; }
        public SupplierClassification2? Classification2 { get; set; }

        public string? Purpose { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public List<int>? ProvinceStateIds { get; set; }
        public List<ProvinceState>? ProvinceStates {  get; set; }

        public string? City { get; set; }
        public string? Address {  get; set; }
        public string? PostalCode { get; set; }
        
        public List<int>? ContactIds { get; set; }
        public List<Contacts>? Contacts { get; set; }

        public string? Currency { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Mobile { get; set; }

        public State State { get; set; } = State.Pending;
        
        // This needs to be used with filtration on datacontext
        public List<int>? AgentIds { get; set; }
        public List<Supplier>? Agents { get; set; }

        // Same here
        public List<int>? SupplierIds { get; set; }
        public List<Supplier>? Suppliers { get; set; }

        // Factory class is not implemented
        public List<int>? FactoryIds { get; set; }
        public List<Factory>? Factories { get; set; }

        public int? ShippingPortId { get; set; }
        public ShippingPort? ShippingPort { get; set; }

        public int InitialMoq { get; set; } = 0;
        public int ReorderMoq { get; set; } = 0;
        public float Commission { get; set; } = 0f;
        public string? PaymentTerm { get; set; }
        public string? LeadTime { get; set; }
        public string? BankInformation { get; set; }
        public string? CompanyLicenseNumber { get; set; }
    }
}
