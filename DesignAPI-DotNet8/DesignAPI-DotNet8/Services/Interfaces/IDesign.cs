using DesignAPI_DotNet8.Models;

namespace DesignAPI_DotNet8.Services.Interfaces
{
    public interface IDesign
    {
        Task<List<Design>> GetAllDesignsAsync();
    }
}
