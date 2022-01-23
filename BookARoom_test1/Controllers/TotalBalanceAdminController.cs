using BookARoom_test1.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookARoom_test1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class TotalBalanceAdminController : Controller
    {
        IBookedRooms bookedRooms = new BookedRoomsProcessor();
        public IActionResult Index()
        {
            List<BookedRoomsModel> outputBooked = new List<BookedRoomsModel>(); //output list

            var data = bookedRooms.Load();

            data.ForEach(r =>
            {
                outputBooked.Add(new BookedRoomsModel
                {
                    RoomNumber = r.RoomNumber,
                    OwnerEmail = r.OwnerEmail,
                    Price = r.Price,
                    StartDate = r.StartDate,
                    EndDate = r.EndDate
                });
            });


            return View(outputBooked);
        }


    }
}
