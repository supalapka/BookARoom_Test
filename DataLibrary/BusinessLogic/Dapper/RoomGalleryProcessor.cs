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
        public static async Task CreateAsync(int hotelRoomId, string roomName, byte[] image)
        {

            RoomGalleryModel room = new RoomGalleryModel
            {
                HotelRoomId = hotelRoomId,
                RoomName = roomName,
                PreviewImage = image,
            };

            string sql = @"insert into dbo.RoomGallery (HotelRoomId, RoomName, PreviewImage) 
                values (@HotelRoomId, @RoomName, @PreviewImage);";

           await SqlDataAccess.SaveDataAsync(sql, room);
        }

        public static async Task<List<RoomGalleryModel>> LoadAsync()
        {
            string sql = @"select * from dbo.RoomGallery;";

            return await SqlDataAccess.LoadDataAsync<RoomGalleryModel>(sql);
        }


        public static async Task<List<RoomGalleryModel>> SelectGalleryAsync(int param)
        {
            return await SqlDataAccess.SelectOjbectsAsync<RoomGalleryModel>("RoomGallery", "HotelRoomId", param.ToString());
        }

        public static async Task<byte[]> GetImageAsync(string paramName, string paramValue)
        {
            RoomGalleryModel gallery= await SqlDataAccess.GetOjbectAsync<RoomGalleryModel>("RoomGallery", paramName, paramValue);
            if (gallery == null)
                gallery = new RoomGalleryModel();
            return gallery.PreviewImage;
        }
    }
}
