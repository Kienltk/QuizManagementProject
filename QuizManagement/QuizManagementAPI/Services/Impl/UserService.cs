using AutoMapper;
using QuizManagementAPI.Data;
using QuizManagementAPI.DTOs.Request;
using QuizManagementAPI.DTOs.Response;
using QuizManagementAPI.Models;

namespace QuizManagementAPI.Services.Impl
{
    public class UserService : Repository<UserResponse, UserRequest, User>
    {
        public UserService(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}
