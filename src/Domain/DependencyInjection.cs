using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Domain
{
    public static class DependencyInjection
    {

        public static IServiceCollection AddDomain(this IServiceCollection services, IConfiguration config) 
        {
            services.AddDbContext<ApplicationDataContext>(optons =>
            {
                optons.UseSqlite(config.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Domain"));
            });
            
            return services;
        }
    }
}