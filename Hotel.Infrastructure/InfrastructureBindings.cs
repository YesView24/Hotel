using Hotel.Application;
using Hotel.Domain.Repositories;
using Hotel.Infrastructure.Data.Repositories;
using Hotel.Infrastructure.Foundation;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Infrastructure
{
    public static class InfrastructureBindings
    {
        public static IServiceCollection AddInfrastructure( this IServiceCollection services )
        {
            services.AddScoped<IGuestRepository, GuestRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}