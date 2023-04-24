using Hotel.Application.Features.Rooms.Commands.Creating;
using Hotel.Application.Features.Rooms.Commands.Deleting;
using Hotel.Application.Features.Rooms.Commands.Updating;
using Hotel.Application.Features.Rooms.Queries.GetAllEmptyRooms;
using Hotel.Application.Features.Rooms.Queries.GetAllGuestsInRoom;
using Hotel.Application.Features.Rooms.Queries.GetAllRooms;
using Hotel.Application.Features.Rooms.Queries.GetRoomById;
using Microsoft.Extensions.DependencyInjection;

namespace Hotel.Application.Features.Rooms
{
    public static class RoomFeaturesBindings
    {
        public static IServiceCollection AddRoomFeatures( this IServiceCollection services )
        {
            services.AddScoped<IRoomCreator, RoomCreator>();
            services.AddScoped<IRoomUpdater, RoomUpdater>();
            services.AddScoped<IRoomDeleter, RoomDeleter>();

            services.AddScoped<IGetRoomByIdQueryHandler, GetRoomByIdQueryHandler>();
            services.AddScoped<IGetAllRoomsQueryHandler, GetAllRoomsQueryHandler>();
            services.AddScoped<IGetAllEmptyRoomsQueryHandler, GetAllEmptyRoomsQueryHandler>();
            services.AddScoped<IGetAllGuestsInRoomQueryHandler, GetAllGuestsInRoomQueryHandler>();

            return services;
        }
    }
}