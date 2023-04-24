namespace Hotel.Application.Features.Rooms.Commands.Updating
{
    public record UpdateRoomCommand(string Number, string Description, int Capacity);
}