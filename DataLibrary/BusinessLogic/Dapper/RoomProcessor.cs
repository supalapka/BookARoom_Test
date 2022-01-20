using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.BusinessLogic
{
    public class RoomProcessor : IRoom
    {
        private List<RoomModel> rooms;

        public RoomProcessor()
        {
            Reload(); //load data into rooms
        }

        public void Create(int roomNumber, int numberOfRooms, string description, int price, int hotelId)
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

        public List<RoomModel> Load()
        {
            if (rooms == null)
                Reload();

            return rooms;
        }

        public void Reload()//load data into rooms
        {
                string sql = @"select * from dbo.Rooms;";
                rooms = SqlDataAccess.LoadData<RoomModel>(sql);
        }

        public List<RoomModel> GetFreeRooms()
        {
            string sql = @"select * from dbo.Rooms where IsBooked = 0;";

            return SqlDataAccess.LoadData<RoomModel>(sql);
        }

        public RoomModel GetRoom(int rooomNumber)
        {
            return rooms.Where(x => x.RoomNUmber == rooomNumber).FirstOrDefault();
        }

        public void BookRoom(int roomNumber) //mark the room as already booked
        {
            string sql = $"update dbo.Rooms Set IsBooked = True where RoomNumber = {roomNumber}";
            SqlDataAccess.ExecuteSqlRequest(sql);
        }
    }
}
