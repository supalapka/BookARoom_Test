using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public static class HotelProcessor
    {
        public static int Create(string name, string location,float rating, int roomsCount, byte[] previewImage)
        {

            HotelModel hotel = new HotelModel {Name = name, Location = location, Rating = rating,
                RoomsCount = roomsCount, PreviewImage = previewImage};

            string sql = @"insert into dbo.Hotels (Name, Location, Rating, RoomsCount, PreviewImage) 
                values (@Name, @Location, @Rating, @RoomsCount, @PreviewImage);";

            return SqlDataAccess.SaveData(sql, hotel);
        }

        public static List<HotelModel> Load()
        {
            string sql = @"select * from dbo.Hotels;";

            return SqlDataAccess.LoadData<HotelModel>(sql);
        }

        public static HotelModel GetHotel(int _id)
        {
            HotelModel hotel;

            hotel = SqlDataAccess.GetOjbect<HotelModel>("Hotels","Id",_id.ToString());
            return hotel; 
        }

    }
}
