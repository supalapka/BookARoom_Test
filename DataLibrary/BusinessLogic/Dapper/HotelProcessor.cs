using DataLibrary.DataAccess;
using DataLibrary.Interface;
using DataLibrary.Models;
using System.Collections.Generic;

namespace DataLibrary.BusinessLogic
{
    public class HotelProcessor : IHotel
    {
        private List<HotelModel> hotels;
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
            {
                string sql = @"select * from dbo.Hotels;";
                hotels = SqlDataAccess.LoadData<HotelModel>(sql);
            }
            return hotels;
        }

        public HotelModel GetHotel(int _id)
        {
            HotelModel hotel;

            hotel = SqlDataAccess.GetOjbect<HotelModel>("Hotels", "Id", _id.ToString());
            return hotel;
        }

    }
}
