using DataLibrary.DataAccess;
using DataLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLibrary.BusinessLogic
{
    public class RoomGalleryProcessor
    {
        public static void Create(int hotelRoomId, string roomName, byte[] image)
        {

            RoomGalleryModel room = new RoomGalleryModel
            {
                HotelRoomId = hotelRoomId,
                RoomName = roomName,
                PreviewImage = image,
            };

            string sql = @"insert into dbo.RoomGallery (HotelRoomId, RoomName, PreviewImage) 
                values (@HotelRoomId, @RoomName, @PreviewImage);";

            SqlDataAccess.SaveData(sql, room);
        }

        public static List<RoomGalleryModel> Load()
        {
            string sql = @"select * from dbo.RoomGallery;";

            return SqlDataAccess.LoadData<RoomGalleryModel>(sql);
        }


        public static List<RoomGalleryModel> SelectGallery(int param)
        {
            return SqlDataAccess.SelectOjbects<RoomGalleryModel>("RoomGallery", "HotelRoomId", param.ToString());
        }

        public static byte[] GetImage(string paramName, string paramValue)
        {
            RoomGalleryModel gallery= SqlDataAccess.GetOjbect<RoomGalleryModel>("RoomGallery", paramName, paramValue);
            if (gallery == null)
                gallery = new RoomGalleryModel();
            return gallery.PreviewImage;
        }
    }
}
