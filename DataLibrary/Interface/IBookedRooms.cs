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
        Task<List<BookedRoomsModel>> LoadAsync();
        Task CreateAsync(string hotelName, int roomNumber, string ownerEmail,DateTime startDate,DateTime endDate, int price);
        Task<int> TotalSumAsync();

    }
}
