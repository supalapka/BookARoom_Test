using BookARoom_test1.Models;
using DataLibrary;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

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

        public IActionResult CreateHotel() { return View(); }


        [Route("Hotels/")]
        public IActionResult List()
        {
            ViewBag.Message = "List";
            var data = hotelRepository.Load();
            List<HotelModel> hotels = new List<HotelModel>(); // output list


            data.ForEach(val => hotels.Add(new HotelModel  //convert  DataLibrary hotel to this.hotel
            {
                Id = val.Id,
                Name = val.Name,
                Location = val.Location,
                RoomCount = val.RoomsCount,
                Rating = val.Rating,
                PreviewImage = val.PreviewImage
            })); ;

            return View(hotels);
        }


        [HttpPost]
        public IActionResult CreateHotel(HotelModel hotel)
        {
            hotelRepository.Create(hotel.Name, hotel.Location, hotel.Rating, hotel.RoomCount, MyFunctionsClass.FileToByteArrayAsync(hotel.PreviwImageFile));
            return View();
        }

    }
}
