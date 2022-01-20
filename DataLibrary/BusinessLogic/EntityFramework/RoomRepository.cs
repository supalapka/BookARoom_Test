using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class RoomRepository : IRoom
    {
        private List<RoomModel> rooms;
        MyDbContext ctx = new MyDbContext();

       public RoomRepository()
        {
            Reload();
        }

        public void BookRoom(int roomNumber) //mark the room as already booked
        {
            rooms.Where(x => x.RoomNUmber == roomNumber).Single().IsBooked = true; 
            ctx.SaveChangesAsync();
        }

        public void Create(int roomNumber, int numberOfRooms, string description, int price, int hotelId)
        {
            ctx.Rooms.Add(new RoomModel
            {
                RoomNUmber = roomNumber,
                NumberOfRooms = numberOfRooms,
                Description = description,
                Price = price,
                HotelId = hotelId
            });
            ctx.SaveChangesAsync();
        }

        public List<RoomModel> GetFreeRooms()
        {
            return rooms.Where(x => x.IsBooked == false).ToList();
        }

        public RoomModel GetRoom(int rooomNumber)
        {
            return rooms.Where(x => x.RoomNUmber == rooomNumber).FirstOrDefault();
        }

        public List<RoomModel> Load()
        {
            return rooms.ToList();
        }

        public void Reload()
        {
            rooms = ctx.Rooms.ToList();
        }
    }
}
