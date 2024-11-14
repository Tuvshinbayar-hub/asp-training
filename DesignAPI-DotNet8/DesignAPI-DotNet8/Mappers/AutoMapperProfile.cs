using AutoMapper;
using DesignAPI_DotNet8.DTO;
using DesignAPI_DotNet8.Models;

namespace DesignAPI_DotNet8.Mappers
{
    public class AutoMapperProfile: Profile
    {
        public AutoMapperProfile() {
            CreateMap<StyleDto, Style>();
            CreateMap<Style, StyleDto>();
        }
    }
}
