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
        Task CreateAsync(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed);
        Task<List<HotelModel>> LoadConfirmedAsync();
        Task<List<HotelModel>> LoadUnconfirmedAsync();
        Task ConfirmAsync(int id);
        Task DeleteAsync(int id);
        Task ReloadAsync(); // set new values from db into static list

    }
}
