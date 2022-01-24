using System;

namespace BookARoom_test1.Models
{
    public class BookedRoomsModel
    {
        public string HotelName { get; set; }
        public int RoomNumber { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
    }
}
