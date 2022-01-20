using BookARoom_test1.Areas.Identity.Data;
using BookARoom_test1.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.DataAccess;
using DataLibrary.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookARoom_test1.Controllers
{
    public class HotelsController : Controller
    {
        //HotelRepository -> Entiry
        //Hotelprocessor -> Dapper
        IHotel hotelRepository = new HotelRepository();
        //IHotel hotelRepository = new Hotelprocessor();

        public HotelsController(IHotel _hotelRepository)
        {
            hotelRepository = _hotelRepository;
        }

        public IActionResult Index()
        {
            return RedirectToAction("List", "Hotels");
        }

        public IActionResult CreateHotel()
        {

            return View();
        }

        [HttpPost]
        public IActionResult CreateHotel(HotelModel hotel)
        {
            hotelRepository.Create(hotel.Name, hotel.Location, hotel.Rating, hotel.RoomCount, MyFunctionsClass.FileToByteArrayAsync(hotel.PreviwImageFile));
            return View();
        }

        [Route("Hotels/")]
        public IActionResult List()
        {
            ViewBag.Message = "List";
            var data = hotelRepository.Load(); 
            List<HotelModel> hotels = new List<HotelModel>();


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

        [Authorize]
        [Route("Hotels/{id:int}")]
        public IActionResult RoomsList(int id)
        {
            ViewBag.Message = "RoomsList";
            var data = RoomProcessor.GetFreeRooms();  //load all rooms from all hotels, demo version for testing
            List<RoomModel> rooms = new List<RoomModel>();

            data.ForEach(val => rooms.Add(new RoomModel
            {
                Id = val.Id,
                HotelId = val.HotelId,
                NumberOfRooms = val.NumberOfRooms,
                Description = val.Description,
                Price = val.Price,
                RoomNUmber = val.RoomNUmber
            }));

            return View(rooms);
        }

        public IActionResult Room(int id)
        {
            ViewData["ID"] = id;
            var data = RoomProcessor.GetRoom(id); //get room from DataLibrary model

            RoomModel room = new RoomModel //convert DataLibrary.RoomModel to this.RoomModel
            {
                Description = data.Description,
                Id = data.Id,
                NumberOfRooms = data.NumberOfRooms,
                HotelId = data.HotelId,
                Price = data.Price,
                RoomNUmber = data.RoomNUmber
            };

            return View(room);
        }


        [HttpPost]
        public async Task<IActionResult> MakeOrder(int roomNumber)
        {
            SqlDataAccess.ExecuteSqlRequest($"update dbo.Rooms set IsBooked = 'true' where RoomNumber = {roomNumber}"); //mark the room as already booked
            var user = SqlDataAccess.GetOjbect<AuthUser>("AspNetUsers", "Id", User.Identity.GetUserId());
            BookedRoomsProcessor.Create(roomNumber, user.Email);
            return RedirectToAction("List", "Hotels");
        }

    }
}
