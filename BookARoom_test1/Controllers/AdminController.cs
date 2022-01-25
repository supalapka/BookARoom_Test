using BookARoom_test1.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.DataAccess;
using DataLibrary.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookARoom_test1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IHotel hotelRepository = new HotelRepository();
        IBookedRooms bookedRooms = new BookedRoomsProcessor();
        private readonly MyDbContext ctx;

        public AdminController(IHotel _hotelRepository,MyDbContext _ctx)
        {
            hotelRepository = _hotelRepository;
            ctx = _ctx;
        }
        public IActionResult Index()
        {

            return RedirectToAction("UnconfirmedList");
        }

        public IActionResult TotalProfit()
        {
            List<BookedRoomsModel> outputBooked = new List<BookedRoomsModel>(); //output list

            var data = bookedRooms.Load();

            data.ForEach(r =>
            {
                outputBooked.Add(new BookedRoomsModel
                {
                    HotelName = r.HotelName,
                    RoomNumber = r.RoomNumber,
                    OwnerEmail = r.OwnerEmail,
                    Price = r.Price,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                });
            });

            return View(outputBooked);
        }

        public async Task<IActionResult> EditList()
        {
           
            var data = await hotelRepository.LoadConfirmed();
            List<HotelModel> outputHotels = new List<HotelModel>();

            data.ForEach(hotel =>
           outputHotels.Add(new HotelModel
           {
               Name = hotel.Name,
               OwnerEmail = hotel.OwnerEmail,
               Location = hotel.Location,
               Id = hotel.Id,
               PreviewImage = hotel.PreviewImage,
               Rating = hotel.Rating,
               RoomCount = hotel.RoomsCount
           }));

            return View(outputHotels);
        }

        public IActionResult Delete(int id)
        {
            hotelRepository.Delete(id);
            hotelRepository.Reload();// set new values from db into static list
            return RedirectToAction("EditList");
        }

        public IActionResult UnconfirmedList()
        {
            var data = hotelRepository.LoadUnconfirmed();
            List<HotelModel> outputHotels = new List<HotelModel>();

            data.ForEach(hotel =>
           outputHotels.Add(new HotelModel
           {
               Name = hotel.Name,
               OwnerEmail = hotel.OwnerEmail,
               Location = hotel.Location,
               Id = hotel.Id,
               PreviewImage = hotel.PreviewImage,
               Rating = hotel.Rating,
               RoomCount = hotel.RoomsCount
           }));

            return View(outputHotels);
        }

        public IActionResult Confirm(int id)
        {
            hotelRepository.Confirm(id);
            hotelRepository.Reload(); // set new values from db into static list
            return RedirectToAction("UnconfirmedList");
        }

    }
}
