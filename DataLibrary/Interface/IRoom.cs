using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Interface
{
    public interface IRoom
    {
        Task CreateAsync(int roomNumber, int numberOfRooms, string description, int price, string hotelName);
        Task<List<RoomModel>> LoadAsync();
        Task<List<RoomModel>> GetFreeRoomsAsync(string hotelName);
        Task<RoomModel> GetRoomAsync(int rooomNumber);
        Task BookRoomAsync(int roomNumber);
        Task ReloadAsync();
    }
}
