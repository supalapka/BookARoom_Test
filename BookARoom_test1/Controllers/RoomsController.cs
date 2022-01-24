using BookARoom_test1.Areas.Identity.Data;
using BookARoom_test1.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.DataAccess;
using DataLibrary.Interface;
using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookARoom_test1.Controllers
{
    [Authorize]
    public class RoomsController : Controller
    {
        IRoom roomRepository = new RoomRepository(); //Entity
                                                     // IRoom roomRepository = new RoomProcessor(); //Dapper
        public IActionResult Index()
        {
            return View();
        }


        [Route("Hotels/{hotelName}")]
        public IActionResult RoomsList(string hotelName)
        {
            ViewBag.Message = "RoomsList";
            ViewData["hotelName"] = hotelName;
            var data = roomRepository.GetFreeRooms(hotelName.Replace('_', ' '));  //load all rooms from all hotels, demo version for testing

            List<RoomModel> rooms = new List<RoomModel>(); //output list

            data.ForEach(val => rooms.Add(new RoomModel  //convert DataLibrary model to this model
            {
                Id = val.Id,
                HotelName = val.HotelName,
                NumberOfRooms = val.NumberOfRooms,
                Description = val.Description,
                Price = val.Price,
                RoomNUmber = val.RoomNUmber
            }));

            return View(rooms);
        }

        [Route("Hotels/{hotelName}/{roomNUmber:int}")]
        public IActionResult Room(string hotelName, int roomNUmber)
        {
            ViewData["ID"] = roomNUmber;
            ViewData["HotelName"] = hotelName;
            var data = roomRepository.GetRoom(roomNUmber); //get room from DataLibrary model

            RoomModel room = new RoomModel //convert DataLibrary.RoomModel to this.RoomModel
            {
                Description = data.Description,
                Id = data.Id,
                NumberOfRooms = data.NumberOfRooms,
                HotelName = data.HotelName,
                Price = data.Price,
                RoomNUmber = data.RoomNUmber
            };
            return View(room);
        }


        [HttpPost]
        public async Task<IActionResult> MakeOrder(string hotelName, int roomNumber, int days, int price)
        {
            roomRepository.BookRoom(roomNumber); //mark room as booked
            var user = SqlDataAccess.GetOjbect<AuthUser>("AspNetUsers", "Id", User.Identity.GetUserId());
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(days);
            IBookedRooms booked = new BookedRoomsProcessor();
            booked.Create(hotelName.Replace('_', ' '), roomNumber, user.Email, startDate, endDate, price);
            return RedirectToAction("Index", "Hotels");
        }
    }
}
