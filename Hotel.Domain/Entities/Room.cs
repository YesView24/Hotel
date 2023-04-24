namespace Hotel.Domain.Entities
{
    public class Room : CommonEntity
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}