using Hotel.Application.Features.Guests.Commands.Creating;
using Hotel.Application.Features.Guests.Commands.Deleting;
using Hotel.Application.Features.Guests.Commands.Updating;
using Hotel.Application.Features.Guests.Queries.GetAllGuests;
using Hotel.Application.Features.Guests.Queries.GetGuestById;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application.Features.Guests;

public static class GuestFeaturesBindings
{
    public static IServiceCollection AddGuestFeatures( this IServiceCollection services )
    {
        services.AddScoped<IGuestCreator, GuestCreator>();
        services.AddScoped<IGuestUpdater, GuestUpdater>();
        services.AddScoped<IGuestDeleter, GuestDeleter>();

        services.AddScoped<IGetAllGuestsQueryHandler, GetAllGuestsQueryHandler>();
        services.AddScoped<IGetGuestByIdQueryHandler, GetGuestByIdQueryHandler>();

        return services;
    }
}