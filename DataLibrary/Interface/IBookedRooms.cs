using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.Interface
{
    public interface IBookedRooms
    {
        List<BookedRoomsModel> Load();
        void Create(int roomNumber, string ownerEmail,DateTime startDate,DateTime endDate, int price);
        int TotalSum();

    }
}
