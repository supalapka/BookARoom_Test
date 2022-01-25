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
        void Create(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed);

        Task<List<HotelModel>> LoadConfirmed();
        List<HotelModel> LoadUnconfirmed();
        void Confirm(int id);
        void Delete(int id);
        Task Reload(); // set new values from db into static list

    }
}
