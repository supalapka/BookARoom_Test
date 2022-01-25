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

            string sql = @"insert into dbo.Hotels (Name, Location, Rating, RoomsCount, PreviewImage) 
                values (@Name, @Location, @Rating, @RoomsCount, @PreviewImage);";

             SqlDataAccess.SaveData(sql, hotel);
        }

        public List<HotelModel> Load()
        {
            if (hotels == null)
                Reload();

            return hotels;
        }


        public void Reload()
        {
            string sql = @"select * from dbo.Hotels;";
            hotels = SqlDataAccess.LoadData<HotelModel>(sql);
        }

        public HotelModel GetHotel(int _id)
        {

           // hotel = SqlDataAccess.GetOjbect<HotelModel>("Hotels", "Id", _id.ToString());
            return hotels.Where(x => x.Id == _id).Single(); ;
        }

        public void Delete(int id)
        {
            string sql = $"DELETE from dbo.Hotels where Id = {id}";
            SqlDataAccess.ExecuteSqlRequest(sql);
            Reload();
        }
    }
}
