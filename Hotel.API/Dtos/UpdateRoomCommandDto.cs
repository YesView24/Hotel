namespace Hotel.API.Dtos
{
    public record UpdateRoomCommandDto( string Number, string Description, int Capacity );
}