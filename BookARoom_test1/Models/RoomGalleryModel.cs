using Microsoft.AspNetCore.Http;

namespace BookARoom_test1.Models
{
    public class RoomGalleryModel
    {
        public int Id { get; set; }
        public int HotelRoomId { get; set; }
        public string RoomName { get; set; }
        public byte[] PreviewImage { get; set; }
        public IFormFile PreviwImageFile { get; set; }
    }
}
