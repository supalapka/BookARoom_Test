using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class HotelProcessor : IHotel
    {
        private List<HotelModel> hotels;

        public async Task CreateAsync(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed)
        {

            HotelModel hotel = new HotelModel
            {
                Name = name,
                Location = location,
                Rating = rating,
                RoomsCount = roomsCount,
                PreviewImage = previewImage,
                IsConfirmed = isConfirmed,
            };

            string sql = @"insert into dbo.Hotels (Name, OwnerEmail, Location, Rating, RoomsCount, PreviewImage, IsConfirmed) 
                values (@Name, @OwnerEmail, @Location, @Rating, @RoomsCount, @PreviewImage, @IsConfirmed);";

            await SqlDataAccess.SaveDataAsync(sql, hotel);
        }

        public async Task<List<HotelModel>> LoadConfirmedAsync()
        {
            if (hotels == null)
                await ReloadAsync();

            return hotels;
        }

        public async Task<List<HotelModel>> LoadUnconfirmedAsync()
        {
            string sql = @"select * from dbo.Hotels where IsConfirmed = 'false';";
            return await SqlDataAccess.LoadDataAsync<HotelModel>(sql);
        }

        public async Task ReloadAsync() //set new list into this.hotelList
        {
            string sql = @"select * from dbo.Hotels where IsConfirmed = 'true';";
            hotels = await SqlDataAccess.LoadDataAsync<HotelModel>(sql);
        }

        public HotelModel GetHotelAsync(int _id)
        {
            return hotels.Where(x => x.Id == _id).Single(); ;
        }

        public async Task DeleteAsync(int id)
        {
            string sql = $"DELETE from dbo.Hotels where Id = {id}";
            await SqlDataAccess.ExecuteSqlRequestAsync(sql);

            await ReloadAsync(); //set new list into this.hotelList
        }

        public async Task ConfirmAsync(int id)
        {
            string sql = $"update dbo.Hotels set IsConfirmed = 'true' where Id = '{id}' ";
            await SqlDataAccess.ExecuteSqlRequestAsync(sql);

            await ReloadAsync();

        }

    }
}
