using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class RoomProcessor : IRoom
    {
        private List<RoomModel> rooms;

        public async Task CreateAsync(int roomNumber, int numberOfRooms, string description, int price, string hotenName)
        {

            RoomModel room = new RoomModel
            {
                RoomNUmber = roomNumber,
                NumberOfRooms = numberOfRooms,
                Description = description,
                Price = price,
                HotelName = hotenName,
            };

            string sql = @"insert into dbo.Rooms (RoomNUmber, NumberOfRooms, Description, Price, HotelName) 
                values (@RoomNUmber, @NumberOfRooms, @Description, @Price, @HotelName);";

            await SqlDataAccess.SaveDataAsync(sql, room);
        }

        public async Task<List<RoomModel>> LoadAsync()
        {
            if (rooms == null)
                await ReloadAsync();

            return rooms;
        }

        public async Task ReloadAsync()//load data into rooms
        {
            string sql = @"select * from dbo.Rooms;";
            rooms = await SqlDataAccess.LoadDataAsync<RoomModel>(sql);
        }

        public async Task<List<RoomModel>> GetFreeRoomsAsync(string hotelName)
        {
            string sql = $"select * from dbo.Rooms where IsBooked = 0 && HotelName = '{hotelName}';";

            return await SqlDataAccess.LoadDataAsync<RoomModel>(sql);
        }

        public async Task<RoomModel> GetRoomAsync(int rooomNumber)
        {
            if (rooms == null)
                await ReloadAsync();
            return rooms.Where(x => x.RoomNUmber == rooomNumber).FirstOrDefault();
        }

        public async Task BookRoomAsync(int roomNumber) //mark the room as already booked
        {
            string sql = $"update dbo.Rooms Set IsBooked = True where RoomNumber = {roomNumber}";
            await SqlDataAccess.ExecuteSqlRequestAsync(sql);

            await ReloadAsync(); // set new valuse into this list from db
        }
    }
}
