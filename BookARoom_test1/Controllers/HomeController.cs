using BookARoom_test1.Models;
using DataLibrary.BusinessLogic;
using Microsoft.AspNetCore.Mvc;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using DataLibrary;
using System.Web.Helpers;
using System.Drawing;
using System.Web;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Linq;
using System;

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

            int record = HotelProcessor.Create(hotel.Name,hotel.Location,hotel.Rating,hotel.RoomCount, MyFunctionsClass.FileToByteArrayAsync(hotel.PreviwImageFile));

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> SignUp(UserModel user)
        {
            int reccordsCreated = UserProcessor.Create(user.Login, user.Password);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
