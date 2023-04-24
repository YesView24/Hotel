using Hotel.Application.Features.Guests;
using Hotel.Application.Features.Reservations;
using Hotel.Application.Features.Rooms;
using Hotel.Application.Services;
using Hotel.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application
{
    public static class ApplicationBindings
    {
        public static IServiceCollection AddApplication( this IServiceCollection services )
        {
            services.AddScoped<IGuestService, GuestService>();
            services.AddScoped<IRoomService, RoomService>();

            services.AddGuestFeatures();
            services.AddRoomFeatures();
            services.AddReservationFeatures();

            return services;
        }
    }
}