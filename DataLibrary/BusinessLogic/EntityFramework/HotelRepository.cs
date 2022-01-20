using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class HotelRepository : IHotel
    {
        private List<HotelModel> hotels;
        MyDbContext ctx = new MyDbContext();
        public void Create(string name, string location, double rating, int roomsCount, byte[] previewImage)
        {

            HotelModel hotel = new HotelModel
            {
                Name = name,
                Location = location,
                Rating = rating,
                RoomsCount = roomsCount,
                PreviewImage = previewImage
            };

            ctx.Hotels.Add(hotel);
            ctx.SaveChangesAsync();

        }

        public List<HotelModel> Load()
        {
            if (hotels == null)
                hotels = ctx.Hotels.ToList();

            return hotels;
        }

        public HotelModel GetHotel(int _id)
        {
            return ctx.Hotels.Where(x => x.Id == _id).Single();
        }
    }
}
