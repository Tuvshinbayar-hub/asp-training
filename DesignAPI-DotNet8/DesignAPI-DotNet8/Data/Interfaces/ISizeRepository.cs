using DesignAPI_DotNet8.Models.Sizes;

namespace DesignAPI_DotNet8.Data.Interfaces
{
    public interface ISizeRepository
    {
        Task<IEnumerable<Size>> GetAllSizeAsync();
        Task<Size> GetSizeByIdAsync(int id);
        Task AddSizeAsync (Size size);
    }
}
