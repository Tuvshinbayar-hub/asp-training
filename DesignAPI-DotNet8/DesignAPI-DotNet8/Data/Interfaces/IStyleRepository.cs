using DesignAPI_DotNet8.Models;

namespace DesignAPI_DotNet8.Data.Interfaces
{
    public interface IStyleRepository
    {
        Task<List<Style>> GetStylesAsync();
        Task AddStyleAsync(Style style);
    }
}
