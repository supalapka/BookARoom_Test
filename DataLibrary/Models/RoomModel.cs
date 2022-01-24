namespace DataLibrary.Models
{
    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomNUmber { get; set; }
        public int NumberOfRooms { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public string HotelName { get; set; }
        public bool IsBooked { get; set; }
    }
}
