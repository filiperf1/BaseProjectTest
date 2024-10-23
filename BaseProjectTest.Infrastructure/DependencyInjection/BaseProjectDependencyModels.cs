using BaseProjectTest.Models.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProjectTest.Models.DependencyInjection
{

    public static class BaseProjectDependencyModels
    {
        
        public static IServiceCollection AddBaseProjectModels(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DB_BaseProjecTest"));
            });

            return services;
        }
    }
}
