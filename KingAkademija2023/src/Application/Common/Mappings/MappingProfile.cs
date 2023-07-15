using Application.Common.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Common.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Test, TestDto>()
                .ReverseMap()
                ;

            CreateMap<Role, RoleDto>()
                .ReverseMap()
                ;

            CreateMap<User, UserDto>()
                .ReverseMap()
                ;
        }
    }
}
