using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class RoomProcessor
    {
        public static void Create(int roomNumber, int numberOfRooms, string description,int price, int hotelId)
        {

            RoomModel room = new RoomModel
            {
                RoomNUmber = roomNumber,
                NumberOfRooms = numberOfRooms,
                Description = description,
                Price = price,
                HotelId = hotelId,
            };

            string sql = @"insert into dbo.Rooms (RoomNUmber, NumberOfRooms, Description, Price, HotelId) 
                values (@RoomNUmber, @NumberOfRooms, @Description, @Price, @HotelId);";

            SqlDataAccess.SaveData(sql, room);
        }

        public static List<RoomModel> Load()
        {
            string sql = @"select * from dbo.Rooms;";

            return SqlDataAccess.LoadData<RoomModel>(sql);
        }

        public static List<RoomModel> GetFreeRooms()
        {
            string sql = @"select * from dbo.Rooms where IsBooked = 0;";

            return SqlDataAccess.LoadData<RoomModel>(sql);
        }

    public static RoomModel GetRoom(int rooomNumber)
        {
            RoomModel hotel;

            hotel = SqlDataAccess.GetOjbect<RoomModel>("Rooms", "Id", rooomNumber.ToString());
            return hotel;
        }

        public static void BookRoom(int roomNumber)
        {
            string sql = $"update dbo.Rooms Set IsBooked = True where RoomNumber = {roomNumber}";
            SqlDataAccess.ExecuteSqlRequest(sql);
        }
    }
}
