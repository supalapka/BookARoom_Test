using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class BookedRooms : IBookedRooms
    {
        MyDbContext ctx = new MyDbContext();
        public async Task CreateAsync(string hotelName, int roomNumber, string ownerEmail, DateTime startDate, DateTime endDate, int price)
        {
            ctx.BookedRooms.Add(new BookedRoomsModel
            {
                HotelName = hotelName,
                RoomNumber = roomNumber,
                OwnerEmail = ownerEmail,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            });
            await ctx.SaveChangesAsync();
        }

        public async Task<List<BookedRoomsModel>> LoadAsync()
        {
            return await ctx.BookedRooms.ToListAsync();
        }

        public async Task<int> TotalSumAsync()
        {
            return await ctx.BookedRooms.SumAsync(x => x.Price);
        }
    }
}
