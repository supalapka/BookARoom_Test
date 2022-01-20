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
        void Create(int roomNumber, int numberOfRooms, string description, int price, int hotelId);
        List<RoomModel> Load();
        List<RoomModel> GetFreeRooms();
        RoomModel GetRoom(int rooomNumber);
        void BookRoom(int roomNumber);

        void Reload();
    }
}
