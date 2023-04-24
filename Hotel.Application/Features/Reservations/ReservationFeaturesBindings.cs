using Hotel.Application.Features.Reservations.Commands.Creating;
using Hotel.Application.Features.Reservations.Commands.Deleting;
using Hotel.Application.Features.Reservations.Queries.GetAllReservations;
using Hotel.Application.Features.Reservations.Queries.GetAllRoomReservationsQueryHandler;
using Hotel.Application.Features.Reservations.Queries.GetReservationById;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application.Features.Reservations;

public static class ReservationFeaturesBindings
{
    public static IServiceCollection AddReservationFeatures( this IServiceCollection services )
    {
        services.AddScoped<IReservationCreator, ReservationCreator>();
        services.AddScoped<IReservationDeleter, ReservationDeleter>();

        services.AddScoped<IGetAllReservationsQueryHandler, GetAllReservationsQueryHandler>();
        services.AddScoped<IGetReservationByIdQueryHandler, GetReservationByIdQueryHandler>();
        services.AddScoped<IGetAllRoomReservationsQueryHandler, GetAllRoomReservationsQueryHandler>();
        
        return services;
    }
}