using BookARoom_test1.Models;
using DataLibrary;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BookARoom_test1.Controllers
{
    public class HomeController : Controller
    {

     
        public IActionResult Index()
        {
            ViewBag.Message = "Index";
            return View();
        }

        protected RedirectToActionResult ButtonSelect_Click(object sender, EventArgs e)
        {
            return RedirectToAction("SignUp");
        }


        public IActionResult SignUp()
        {
            ViewBag.Message = "User Sign Up";

            return View();

        }

        public IActionResult InputHotel()
        {
            ViewBag.Message = "Input Hotel";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> InputHotel(HotelModel hotel)
        {
            ViewBag.Message = "Input Hotel async";

           // int record = HotelProcessor.Create(hotel.Name, hotel.Location, hotel.Rating, hotel.RoomCount, MyFunctionsClass.FileToByteArrayAsync(hotel.PreviwImageFile));

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel user)
        {
            await UserProcessor.CreateAsync(user.Login, user.Password);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
