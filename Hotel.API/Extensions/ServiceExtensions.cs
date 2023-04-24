using Hotel.Infrastructure.Foundation;
using Microsoft.EntityFrameworkCore;

namespace Hotel.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSqlContext( this IServiceCollection services, IConfiguration configuration )
        {
            var connectionString = configuration.GetConnectionString( "SqlConnection" );
            var assemblyName = configuration.GetSection( "MigrationAssemblies" )[ "HotelMigrations" ];

            services.AddDbContext<HotelDbContext>( opts =>
                opts.UseSqlServer( connectionString, s => s.MigrationsAssembly( assemblyName ) ) );
        }
    }
}