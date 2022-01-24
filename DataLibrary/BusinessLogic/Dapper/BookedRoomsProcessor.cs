using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public class BookedRoomsProcessor : IBookedRooms
    {

        public void Create(int hotelId, int roomNumber, string ownerEmail, DateTime start, DateTime end, int price)
        {

            BookedRoomsModel bookedRoom = new BookedRoomsModel
            {
                HotelId = hotelId,
                OwnerEmail = ownerEmail,
                RoomNumber = roomNumber,
                StartDate = start,
                EndDate = end,
                Price = price
            };

            string sql = @"insert into dbo.BookedRooms (HotelId, OwnerEmail, RoomNumber,StartDate, EndDate, Price) 
                values (@HotelId, @OwnerEmail, @RoomNumber, @StartDate, @EndDate, @Price);";

            SqlDataAccess.SaveData(sql, bookedRoom);
        }

        public List<BookedRoomsModel> Load()
        {
            string sql = @"select *  from dbo.BookedRooms;";

            return SqlDataAccess.LoadData<BookedRoomsModel>(sql);
        }

        public int TotalSum()
        {
            string sql = @"select sum(Price) from dbo.BookedRooms;";
            return SqlDataAccess.GetSum(sql);
        }
    }
}
