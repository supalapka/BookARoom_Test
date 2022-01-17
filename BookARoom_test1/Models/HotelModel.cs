using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BookARoom_test1.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public float Rating { get; set; }
        public int RoomCount { get; set; }
        public byte[] PreviewImage { get; set; }
        public IFormFile PreviwImageFile { get; set; }
    }
}
