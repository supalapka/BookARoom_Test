using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class BookedRoomsProcessor
    {

        public static void Create(int roomNumber, string ownerEmail,DateTime start,DateTime end,int price)
        {

            BookedRoomsModel bookedRoom = new BookedRoomsModel { OwnerEmail = ownerEmail, RoomNumber = roomNumber,
                StartDate = start, EndDate = end, Price = price};

            string sql = @"insert into dbo.BookedRooms (OwnerEmail, RoomNumber,StartDate, EndDate, Price) 
                values (@OwnerEmail, @RoomNumber, @StartDate, @EndDate, @Price);";

            SqlDataAccess.SaveData(sql, bookedRoom);
        }

        public static List<BookedRoomsModel> Load()
        {
            string sql = @"select *  from dbo.BookedRooms;";

            return SqlDataAccess.LoadData<BookedRoomsModel>(sql);
        }


    }
}
