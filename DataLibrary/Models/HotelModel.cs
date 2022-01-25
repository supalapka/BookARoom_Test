using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Models
{
    public class HotelModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string OwnerEmail { get; set; }
        public string Location { get; set; }
        public double Rating { get; set; }
        public int RoomsCount { get; set; }
        public byte[] PreviewImage { get; set; }
        public bool IsConfirmed { get; set; }

    }
}
