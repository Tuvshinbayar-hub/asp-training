using DesignAPI_DotNet8.DTO;

namespace DesignAPI_DotNet8.Services.Interfaces
{
    public interface IStyleService
    {
        Task<List<StyleDto>> GetAllStylesAsync();
    }
}
