using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace BookARoom_test1.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public float Rating { get; set; }
        [Required]
        public int RoomCount { get; set; }
        public byte[] PreviewImage { get; set; } //image that shows
        [Required]
        public IFormFile PreviwImageFile { get; set; } //image that uploads while creating hotel
    }
}
