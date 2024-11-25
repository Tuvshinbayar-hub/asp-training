using DesignAPI_DotNet8.Enums;
using DesignAPI_DotNet8.Models.BaseModels;
using DesignAPI_DotNet8.Models.GeneralSetup;
using System.Security.Cryptography.Pkcs;

namespace DesignAPI_DotNet8.Models.Suppliers
{
    public class ShippingPort: BaseCreation
    {
        public string Name { get; set; }
        public State State { get; set; } = State.Pending;
        
        public int? ShippingPortId { get; set; }
        public string? Purpose { get; set; }
        public string? Website { get; set; }
        public string? Email { get; set; }

        public int? CountryId { get; set; }
        public Country? Country { get; set; }

        public List<int>? ContactIds { get; set; }
        public List<Contacts>? Contacts { get; set; }
    }
}
