namespace Hotel.Domain.Entities
{
    public class Reservation : CommonEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int GuestId { get; set; }
        public Guest Guest { get; set; }

        public int RoomId { get; set; }
        public Room Room { get; set; }
    }
}