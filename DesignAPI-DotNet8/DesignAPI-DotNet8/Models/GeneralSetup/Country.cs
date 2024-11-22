using DesignAPI_DotNet8.Models.BaseModels;

namespace DesignAPI_DotNet8.Models.GeneralSetup
{
    public class Country : BaseCreation
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public string Region { get; set; }
        public bool IsAcive { get; set; } = true;
 
        public List<int>? LanguageId { get; set; }
        public List<Language>? Language { get; set; }
    }
}