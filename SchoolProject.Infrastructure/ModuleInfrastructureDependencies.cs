using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Infrastructure.Data;
using SchoolProject.Infrastructure.Interfaces;
using SchoolProject.Infrastructure.Repositories;

namespace SchoolProject.Infrastructure
{
    public static class ModuleInfrastructureDependencies
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration config)
        {
            #region Register DbContext with SQL Server using connection string from appsettings.json 
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(
                config.GetConnectionString("DefaultConnection")));
            #endregion


            #region Register repositories
            services.AddScoped(typeof(IGenericRepositoryAsync<>), typeof(GenericRepositoryAsync<>));
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<ISubjectRepository, SubjectRepository>();
            services.AddScoped<IInstructorRepository, InstructorRepository>();
            #endregion

            return services;
        }
    }
}
