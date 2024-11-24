using IrisTraining_Auth.Context;
using IrisTraining_Auth.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace IrisTraining_Auth.DependencyInjections.Extensions
{
    public static class ServiceCollectionsExtentions
    {
        public static IServiceCollection AddDBContextSQLServer(this IServiceCollection services,IConfiguration configuration) {
            services.AddDbContext<DatabaseContext>( options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AuthDb"));
            } );
            return services;
        }

        public static IServiceCollection AddServiceInjection( this IServiceCollection services )
        {
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
