﻿using BookARoom_test1.Models;
using DataLibrary.BusinessLogic;
using DataLibrary.BusinessLogic.EntityFramework;
using DataLibrary.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookARoom_test1.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        IHotel repo = new HotelProcessor();
        IBookedRooms bookedRooms = new BookedRoomsProcessor();
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

        public IActionResult EditList()
        {
           
            var data = repo.LoadConfirmed();
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
            repo.Delete(id);
            repo.Reload();// set new values from db into static list
            return RedirectToAction("EditList");
        }

        public IActionResult UnconfirmedList()
        {
            var data = repo.LoadUnconfirmed();
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
            repo.Confirm(id);
            repo.Reload(); // set new values from db into static list
            return RedirectToAction("UnconfirmedList");
        }

    }
}
