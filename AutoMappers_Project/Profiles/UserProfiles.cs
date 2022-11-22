using AutoMapper;
using AutoMappers_Project.Dtos;
using AutoMappers_Project.Entities;
using AutoMappers_Project.HelperFunctions;

namespace AutoMappers_Project.Profiles
{
    public class UserProfiles:Profile
    {
        public UserProfiles()
        {
            //source->destination
            CreateMap<User, UserReadDto>()
                .ForMember(dest => dest.FullName,
                opt=>opt.MapFrom(src => $"{src.FirstName } {src.LastName}"))
                .ForMember(
                dest => dest.Age,
                opt=>opt.MapFrom(src =>src.DateOfBirth.GetCurrentAge())
                );
            CreateMap<UserCreateDto, User>();
        }
    }
}
