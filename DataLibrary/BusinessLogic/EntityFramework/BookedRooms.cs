using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class BookedRooms : IBookedRooms
    {
        MyDbContext ctx = new MyDbContext();
        public void Create(int roomNumber, string ownerEmail, DateTime startDate, DateTime endDate, int price)
        {
            ctx.BookedRooms.Add(new BookedRoomsModel
            {
                RoomNumber = roomNumber,
                OwnerEmail = ownerEmail,
                StartDate = startDate,
                EndDate = endDate,
                Price = price
            });
            ctx.SaveChangesAsync();
        }

        public List<BookedRoomsModel> Load()
        {
            return ctx.BookedRooms.ToList();
        }

        public int TotalSum()
        {
            return ctx.BookedRooms.Sum(x=>x.Price);
        }
    }
}
