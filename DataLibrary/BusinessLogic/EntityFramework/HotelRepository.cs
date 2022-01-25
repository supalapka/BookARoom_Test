using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class HotelRepository : IHotel
    {
        private List<HotelModel> hotels;
        MyDbContext ctx = new MyDbContext();
        public async void Create(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed)
        {
            HotelModel hotel = new HotelModel
            {
                Name = name,
                Location = location,
                Rating = rating,
                RoomsCount = roomsCount,
                PreviewImage = previewImage,
                OwnerEmail = ownerEmail,
                IsConfirmed = isConfirmed,
            };

            ctx.Hotels.Add(hotel);
            await ctx.SaveChangesAsync();
        }

        public List<HotelModel> LoadConfirmed()
        {
            if (hotels == null)
                Reload();

            return hotels;
        }

        public List<HotelModel> LoadUnconfirmed()
        {
            return ctx.Hotels.Where(x => x.IsConfirmed == false).ToList();
        }

        public void Reload() { hotels = ctx.Hotels.Where(x => x.IsConfirmed == true).ToList(); }

        public HotelModel GetHotel(int _id) { return ctx.Hotels.Where(x => x.Id == _id).Single(); }

        public async void Delete(int id)
        {
            if (hotels == null) Reload();
            ctx.Hotels.Remove(hotels.Where(x => x.Id == id).Single());
            await ctx.SaveChangesAsync();
            Reload();
        }

        public async void Confirm(int id)
        {

            ctx.Hotels.Where(x => x.Id == id).Single().IsConfirmed = true;
            await ctx.SaveChangesAsync();
            Reload();
        }
    }
}
