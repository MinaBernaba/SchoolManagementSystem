using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Service.Interfaces;
using SchoolProject.Service.Services;

namespace SchoolProject.Service
{
    public static class ModuleServiceDependencies
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            return services;
        }
    }
}
