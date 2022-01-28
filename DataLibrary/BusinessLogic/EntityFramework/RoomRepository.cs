using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class RoomRepository : IRoom
    {
        private List<RoomModel> rooms;
        MyDbContext ctx = new MyDbContext();



        public async Task CreateAsync(int roomNumber, int numberOfRooms, string description, int price, string hotelName)
        {
            ctx.Rooms.Add(new RoomModel
            {
                RoomNUmber = roomNumber,
                NumberOfRooms = numberOfRooms,
                Description = description,
                Price = price,
                HotelName = hotelName
            });
            await ctx.SaveChangesAsync();
        }

        public async Task<List<RoomModel>> GetFreeRoomsAsync(string hotelName)
        {
            if (rooms == null)
                await ReloadAsync();
            return rooms.Where(x => x.IsBooked == false && x.HotelName == hotelName).ToList();
        }

        public async Task<RoomModel> GetRoomAsync(int rooomNumber)
        {
            if (rooms == null)
                await ReloadAsync();
            return rooms.Where(x => x.RoomNUmber == rooomNumber).FirstOrDefault();
        }

        public async Task<List<RoomModel>> LoadAsync()
        {
            if (rooms == null)
                await ReloadAsync();
            return rooms.ToList();
        }

        public async Task ReloadAsync()
        {
            rooms = await ctx.Rooms.ToListAsync();
        }

        public async Task BookRoomAsync(int roomNumber) //mark the room as already booked
        {
            ctx.Rooms.Where(x => x.RoomNUmber == roomNumber).Single().IsBooked = true;
            await ctx.SaveChangesAsync();

            await ReloadAsync(); // set new valuse into this list from db
        }
    }
}
