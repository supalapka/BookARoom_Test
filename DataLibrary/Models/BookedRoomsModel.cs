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
        public int RoomNumber { get; set; }
        public string OwnerEmail { get; set; }
    }
}
