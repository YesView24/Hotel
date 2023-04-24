namespace Hotel.Application.Features.Rooms.Commands.Creating
{
    public record AddRoomCommand( string Number, string Description, int Capacity );
}