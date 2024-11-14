using DesignAPI_DotNet8.Data.Interfaces;
using DesignAPI_DotNet8.Models;
using DesignAPI_DotNet8.DTO;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace DesignAPI_DotNet8.Data.Repositories
{
    public class StyleRepository : IStyleRepository
    {
        private readonly DataContext _dataContext;
        private readonly IMapper _mapper;

        public StyleRepository(DataContext dataContext, IMapper mapper) { 
            _dataContext = dataContext;
            _mapper = mapper;
        }

        public Task AddStyleAsync(Style style)
        {
            throw new NotImplementedException();
        }

        public async Task<List<StyleDto>> GetStylesAsync()
        {
            var styles = await _dataContext.Styles.ToListAsync();
            return _mapper.Map<List<StyleDto>>(styles);
        }
    }
}
