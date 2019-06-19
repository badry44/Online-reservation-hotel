using Online_reservation_hotel.Context;
using Online_reservation_hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_reservation_hotel.Controllers
{
    public class testController : Controller
    {
        reservationContext db = new reservationContext();
        // GET: test
        public ActionResult Index()
        {
            return View(db.roomType.ToList());
        }
        [HttpGet]
        public ActionResult CreateRoomType()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRoomType(RoomType roomType)
        {
            if (ModelState.IsValid)
            {
                db.roomType.Add(roomType);
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(roomType);
        }

    }
}