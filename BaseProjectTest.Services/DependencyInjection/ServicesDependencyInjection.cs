using BaseProjectTest.Models.Data;
using BaseProjectTest.Services.Contracts;
using BaseProjectTest.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BaseProjectTest.Services.DependencyInjection
{
    public static class ServicesDependencyInjection
    {

        public static IServiceCollection AddDependencyServices(this IServiceCollection services, IConfiguration configuration) 
        {
            services.AddScoped<ILivrosService, LivrosService>();

            services.AddDbContext<DataContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DB_BaseProjecTest"));
            });
            return services;
        }

    }
}
