using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Data.Helpers;

namespace SchoolProject.Data
{
    public static class ModuleDataDependencies
    {
        public static IServiceCollection AddDataDependencies(this IServiceCollection services, IConfiguration configuration)
        {

            services.Configure<JWTOptions>(configuration.GetSection("JWT"));

            return services;
        }
    }
}
