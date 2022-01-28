using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic.EntityFramework
{
    public class HotelRepository : IHotel
    {
        private List<HotelModel> hotels;
        MyDbContext ctx = new MyDbContext();
        public async Task CreateAsync(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed)
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

            await ctx.Hotels.AddAsync(hotel);
            await ctx.SaveChangesAsync();
        }

        public async Task<List<HotelModel>> LoadConfirmedAsync()
        {
            if (hotels == null)
                await ReloadAsync();

            return hotels;
        }

        public async Task<List<HotelModel>> LoadUnconfirmedAsync()
        {
            return await ctx.Hotels.Where(x => x.IsConfirmed == false).ToListAsync();
        }

        public async Task ReloadAsync() {  hotels = await ctx.Hotels.Where(x => x.IsConfirmed == true).ToListAsync(); }

        public async Task<HotelModel> GetHotel(int _id) { return await ctx.Hotels.Where(x => x.Id == _id).SingleAsync(); }

        public async Task DeleteAsync(int id)
        {
            if (hotels == null) await ReloadAsync();
            ctx.Hotels.Remove(hotels.Where(x => x.Id == id).Single());
            await ctx.SaveChangesAsync();
            await ReloadAsync();
        }

        public async Task ConfirmAsync(int id)
        {

            ctx.Hotels.Where(x => x.Id == id).Single().IsConfirmed = true;
            await ctx.SaveChangesAsync();
            await ReloadAsync();
        }
    }
}
