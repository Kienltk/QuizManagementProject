using AutoMapper;
using QuizManagementAPI.Data;
using QuizManagementAPI.DTOs.Request;
using QuizManagementAPI.DTOs.Response;
using QuizManagementAPI.Models;

namespace QuizManagementAPI.Services.Impl
{
    public class RoleService : Repository<RoleResponse, RoleRequest, Role>
    {
        public RoleService(AppDbContext context, IMapper mapper) : base(context, mapper) { }
    }
}

