using QuizManagementAPI.DTOs.Request;
using QuizManagementAPI.DTOs.Response;
using QuizManagementAPI.Mapper;
using QuizManagementAPI.Services.Impl;

namespace QuizManagementAPI.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));

            services.AddScoped<RoleService>();
            services.AddScoped<IService<RoleResponse, RoleRequest>, RoleService>();
            services.AddScoped<UserService>();
            services.AddScoped<IService<UserResponse, UserRequest>, UserService>();

            return services;
        }
    }
}
