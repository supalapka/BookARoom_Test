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
    public class RoomsController : Controller
    {
        IRoom roomRepository = new RoomRepository(); //Entity
                                                     // IRoom roomRepository = new RoomProcessor(); //Dapper
        public IActionResult Index()
        {
            return View();
        }


        [Authorize]
        [Route("Hotels/{id:int}")]
        public IActionResult RoomsList(int id)
        {
            ViewBag.Message = "RoomsList";
            var data = roomRepository.GetFreeRooms();  //load all rooms from all hotels, demo version for testing

            List<RoomModel> rooms = new List<RoomModel>(); //output list

            data.ForEach(val => rooms.Add(new RoomModel  //convert DataLibrary model to this model
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

        public IActionResult Room(int roomNUmber)
        {
            ViewData["ID"] = roomNUmber;
            var data = roomRepository.GetRoom(roomNUmber); //get room from DataLibrary model

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
        public async Task<IActionResult> MakeOrder(int roomNumber, int days,int price)
        {
            roomRepository.BookRoom(roomNumber); //mark room as booked
            var user = SqlDataAccess.GetOjbect<AuthUser>("AspNetUsers", "Id", User.Identity.GetUserId());
            DateTime startDate = DateTime.Today;
            DateTime endDate = DateTime.Today.AddDays(days);
            IBookedRooms booked = new BookedRoomsProcessor();
            booked.Create(roomNumber, user.Email, startDate, endDate,price);
            return RedirectToAction("Index", "Hotels");
        }
    }
}
