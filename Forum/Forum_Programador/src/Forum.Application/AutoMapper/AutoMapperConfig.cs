using AutoMapper;
using Forum.Application.Commands.Section;
using Forum.Domain.Entities;

namespace Forum.Application.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Section, UpdateSectionCommand>().ReverseMap();
        }
    }
}
