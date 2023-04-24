namespace Hotel.Domain.Entities
{
    public class Guest : CommonEntity
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public List<Reservation> Reservations { get; set; } = new List<Reservation>();

    }
}