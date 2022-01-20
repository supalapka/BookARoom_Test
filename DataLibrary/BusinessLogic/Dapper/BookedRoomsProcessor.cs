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

        public static void Create(int roomNumber, string ownerEmail)
        {

            BookedRoomsModel bookedRoom = new BookedRoomsModel { OwnerEmail = ownerEmail, RoomNumber = roomNumber };

            string sql = @"insert into dbo.BookedRooms (OwnerEmail, RoomNumber) 
                values (@OwnerEmail, @RoomNumber);";

            SqlDataAccess.SaveData(sql, bookedRoom);
        }

        public static List<BookedRoomsModel> Load()
        {
            string sql = @"select *  from dbo.BookedRooms;";

            return SqlDataAccess.LoadData<BookedRoomsModel>(sql);
        }


    }
}
