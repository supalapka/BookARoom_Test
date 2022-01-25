using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Interface
{
    public interface IHotel
    {
        void Create(string name, string location, double rating, int roomsCount, byte[] previewImage);

        List<HotelModel> Load();
        void Delete(int id);
    }
}
