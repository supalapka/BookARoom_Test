using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class BookedRoomsProcessor : IBookedRooms
    {

        public async Task CreateAsync(string hotelName, int roomNumber, string ownerEmail, DateTime start, DateTime end, int price)
        {

            BookedRoomsModel bookedRoom = new BookedRoomsModel
            {
                HotelName = hotelName,
                OwnerEmail = ownerEmail,
                RoomNumber = roomNumber,
                StartDate = start,
                EndDate = end,
                Price = price
            };

            string sql = @"insert into dbo.BookedRooms (HotelName, OwnerEmail, RoomNumber,StartDate, EndDate, Price) 
                values (@HotelName, @OwnerEmail, @RoomNumber, @StartDate, @EndDate, @Price);";

            await SqlDataAccess.SaveDataAsync(sql, bookedRoom);
        }

        public async Task<List<BookedRoomsModel>> LoadAsync()
        {
            string sql = @"select *  from dbo.BookedRooms;";

            return await SqlDataAccess.LoadDataAsync<BookedRoomsModel>(sql);
        }

        public async Task<int> TotalSumAsync()
        {
            string sql = @"select sum(Price) from dbo.BookedRooms;";
            return await SqlDataAccess.GetSumAsync(sql);
        }
    }
}
