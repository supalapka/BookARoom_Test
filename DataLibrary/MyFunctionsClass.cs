using Microsoft.AspNetCore.Http;
using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;

namespace DataLibrary
{
    public static class MyFunctionsClass
    {
        public static byte[] ImageToByteArray(Image image)
        {
            using (var ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        public static Image ByteArrayToImage(byte[] data)
        {
            MemoryStream ms = new MemoryStream(data);
            Image image = Image.FromStream(ms);
            return image;
        }

        public static byte[] FileToByteArrayAsync(IFormFile file)
        {
            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())  //convert imageFile to byte[] for storing in db
            {
                file.CopyToAsync(memoryStream);
                using (var img = Image.FromStream(memoryStream))
                {
                    imageBytes = ImageToByteArray(img);
                }
                return imageBytes;
            }
        }

        public static string ByteToStringSource(byte[] imgBytes)
        {
            var base64 = Convert.ToBase64String(imgBytes);
            return string.Format("data:image/gif;base64,{0}", base64);

        }
    }
}
