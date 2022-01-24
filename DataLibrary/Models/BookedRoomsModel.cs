using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class BookedRoomsModel
    {
        public int Id { get; set; }
        public string HotelName { get; set; }
        public int RoomNumber { get; set; }
        public string OwnerEmail { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Price { get; set; }
    }
}
