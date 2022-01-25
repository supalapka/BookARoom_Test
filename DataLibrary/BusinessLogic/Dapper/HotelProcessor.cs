using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;
using System.Linq;

namespace DataLibrary.BusinessLogic
{
    public class HotelProcessor : IHotel
    {
        private List<HotelModel> hotels;

        public HotelProcessor()
        {
            Reload();
        }
        public void Create(string name, string ownerEmail, string location, double rating, int roomsCount, byte[] previewImage, bool isConfirmed)
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

             SqlDataAccess.SaveData(sql, hotel);
        }

        public List<HotelModel> LoadConfirmed()
        {
            if (hotels == null)
                Reload();

            return hotels;
        }

        public List<HotelModel> LoadUnconfirmed()
        {
            string sql = @"select * from dbo.Hotels where IsConfirmed = 'false';";
            return SqlDataAccess.LoadData<HotelModel>(sql);
        }

        public void Reload()
        {
            string sql = @"select * from dbo.Hotels where IsConfirmed = 'true';";
            hotels = SqlDataAccess.LoadData<HotelModel>(sql);
        }

        public HotelModel GetHotel(int _id)
        {
            return hotels.Where(x => x.Id == _id).Single(); ;
        }

        public void Delete(int id)
        {
            string sql = $"DELETE from dbo.Hotels where Id = {id}";
            SqlDataAccess.ExecuteSqlRequest(sql);
            Reload();
        }

        public void Confirm(int id)
        {
            string sql = $"update dbo.Hotels set IsConfirmed = 'true' where Id = '{id}' ";
            SqlDataAccess.ExecuteSqlRequest(sql);
        }
    }
}
