using BookARoom_test1.Areas.Identity.Data;
using BookARoom_test1.Models;
using DataLibrary;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.DataAccess;
using DataLibrary.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookARoom_test1.Controllers
{
    public class HotelsController : Controller
    {
        //HotelRepository -> Entity
        //Hotelprocessor -> Dapper
        IHotel hotelRepository = new HotelRepository();
        //IHotel hotelRepository = new Hotelprocessor();

        public HotelsController(IHotel _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }

        public IActionResult Index() { return RedirectToAction("List", "Hotels"); }


        [Route("Hotels/Create")]
        public IActionResult CreateHotel() { return View(); }

        [Route("Hotels/Create")]
        [HttpPost]
        public async Task<IActionResult> CreateHotel(HotelModel hotel)
        {
            var user = SqlDataAccess.GetOjbect<AuthUser>("AspNetUsers", "Id", User.Identity.GetUserId());
            hotel.OwnerEmail = user.Email;
            hotel.IsConfirmed = false;
            hotelRepository.Create(hotel.Name, hotel.OwnerEmail, hotel.Location, hotel.Rating, hotel.RoomCount,
                MyFunctionsClass.FileToByteArrayAsync(hotel.PreviwImageFile), hotel.IsConfirmed);
            return View();
        }


        [Route("Hotels/")]
        public IActionResult List()
        {
            ViewBag.Message = "List";
            var data = hotelRepository.LoadConfirmed();
            List<HotelModel> hotels = new List<HotelModel>(); // output list


            data.ForEach(val => hotels.Add(new HotelModel  //convert  DataLibrary hotel to this.hotel
            {
                Id = val.Id,
                Name = val.Name,
                Location = val.Location,
                RoomCount = val.RoomsCount,
                Rating = val.Rating,
                PreviewImage = val.PreviewImage
            }));

            return View(hotels);
        }


        

    }
}
