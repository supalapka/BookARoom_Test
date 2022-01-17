using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class RoomGalleryModel
    {
        public int Id { get; set; }
        public int HotelRoomId { get; set; }
        public string RoomName { get; set; }
        public byte[] PreviewImage { get; set; }
    }
}
