using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class HotelRepository : IHotel
    {
        private List<HotelModel> hotels;
        MyDbContext ctx = new MyDbContext();
        public async void Create(string name, string location, double rating, int roomsCount, byte[] previewImage)
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
            await ctx.SaveChangesAsync();
        }

        public List<HotelModel> Load()
        {
            if (hotels == null)
                Reload();
            hotels = ctx.Hotels.ToList();

            return hotels;
        }
        public void Reload() { hotels = ctx.Hotels.ToList(); }

        public HotelModel GetHotel(int _id) { return ctx.Hotels.Where(x => x.Id == _id).Single(); }

        public async void Delete(int id)
        {
            if (hotels == null) Reload();
            ctx.Hotels.Remove(hotels.Where(x => x.Id == id).Single());
            await ctx.SaveChangesAsync();
            Reload();
        }
    }
}
