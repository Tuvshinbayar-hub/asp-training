using DesignAPI_DotNet8.Data.Interfaces;
using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.Services.Interfaces;

namespace DesignAPI_DotNet8.Services
{
    public class StyleService : IStyleService
    {
        private readonly IStyleRepository _styleRepository;

        public StyleService(IStyleRepository styleRepository) {
            _styleRepository = styleRepository;
        }

        public Task<List<Style>> GetAllStylesAsync()
        {
            return _styleRepository.GetStylesAsync();
        }
    }
}
