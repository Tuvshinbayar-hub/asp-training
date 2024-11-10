using DesignAPI_DotNet8.Data.Interfaces;
using DesignAPI_DotNet8.Data;
using DesignAPI_DotNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace DesignAPI_DotNet8.Data.Repositories
{
    public class StyleRepository : IStyleRepository
    {
        private readonly DataContext _dataContext;

        public StyleRepository(DataContext dataContext) { 
            _dataContext = dataContext;
        }

        public Task AddStyleAsync(Style style)
        {
            throw new NotImplementedException();
        }

        public Task<List<Style>> GetStylesAsync()
        {
            return _dataContext.Styles.ToListAsync();
        }
    }
}
