using AutoMapper;
using QuizManagementAPI.DTOs.Request;
using QuizManagementAPI.DTOs.Response;
using QuizManagementAPI.Models;

namespace QuizManagementAPI.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Role
            CreateMap<Role, RoleResponse>();
            CreateMap<RoleRequest, Role>();

            // User
            CreateMap<User, UserResponse>()
                .ForMember(dest => dest.RoleName, opt => opt.MapFrom(src => src.Role.RoleName));
            CreateMap<UserRequest, User>();
        }
    }
}
