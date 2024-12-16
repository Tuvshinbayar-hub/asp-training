using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models;

namespace DesignAPI_DotNet8.Data.Interfaces
{
    public interface IStyleRepository
    {
        Task<List<StyleDto>> GetStylesAsync();
        Task AddStyleAsync(Style style);
    }
}