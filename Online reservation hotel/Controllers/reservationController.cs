using Online_reservation_hotel.Context;
using Online_reservation_hotel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Online_reservation_hotel.Controllers
{
    public class reservationController : Controller
    {
        reservationContext db = new reservationContext();
        // GET: reservation
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddRoom()
        {
            List<RoomType> typesInRoomType = new List<RoomType>();
            typesInRoomType = db.roomType.ToList();
            List<SelectListItem> typesReturned = new List<SelectListItem>();
            foreach (var type in typesInRoomType)
            {
                typesReturned.Add(new SelectListItem
                {
                    Text = type.roomTypeName,
                    Value = type.roomTypeName
                });
            }
            
            ViewBag.RoomTypes = typesReturned;
            ViewBag.Rooms = db.roomTrans.ToList();

            return View();
        }
        [HttpPost]
        public ActionResult AddRoom(RoomTransaction room)
        {
            List<RoomType> typesInRoomType = new List<RoomType>();
            typesInRoomType = db.roomType.ToList();
            List<SelectListItem> typesReturned = new List<SelectListItem>();
            foreach (var type in typesInRoomType)
            {
                typesReturned.Add(new SelectListItem
                {
                    Text = type.roomTypeName,
                    Value = type.roomTypeName
                });
            }

            ViewBag.RoomTypes = typesReturned;
            ViewBag.Rooms = db.roomTrans.ToList();
            if (ModelState.IsValid)
            {
                DateTime dateFrom = Convert.ToDateTime(room.from);
                DateTime dateTo = Convert.ToDateTime(room.to);
                string sql = "select * from [dbo].[RoomTransactions] where roomName = '" + room.roomName + "' and datediff(day,[from] , '" + dateFrom.Year+"-"+dateFrom.Month+"-"+dateFrom.Day + " ')>=0 and datediff(day,[to] , '" + dateTo.Year+"-"+dateTo.Month+"-"+dateTo.Day + "' )<=0";
                    List<RoomTransaction> checkDateExists =  db.roomTrans.SqlQuery(sql).ToList();
                if (checkDateExists.Count ==0)
                { 
                int numberOfdays = room.to.Subtract(room.from).Days;
                double price = db.roomType.SqlQuery("select * from RoomTypes where roomTypeName = '" + room.roomTypeName+"'").ToList()[0].roomTypePrice;
                room.numberOfDays = numberOfdays;
                room.price = price* numberOfdays;
                db.roomTrans.Add(room);
                db.SaveChanges();
                    ViewBag.Rooms = db.roomTrans.ToList();

                    //return RedirectToAction("showRooms");
                    return View();
                }
                else
                {
                    string x = "zz";
                    ViewBag.ErrorMessageForReservedDate = "Sorry this date for this room has been taken";
                    return View(room);
                }
            }
            
            return View(room);
        }
        public ActionResult showRooms ()
        {
            return View(db.roomTrans.ToList());
            
        }
        public ActionResult Cancel (int id)
        {
            RoomTransaction room = new RoomTransaction() { roomTransId = id };
            db.roomTrans.Attach(room);
            db.roomTrans.Remove(room);
            db.SaveChanges();
            return RedirectToAction("AddRoom", "reservation");
        }
        public JsonResult getRoomList(string roomTypeName)
        {
            try 
                { 
            db.Configuration.ProxyCreationEnabled = false;
                List<Room> RoomList = db.room.SqlQuery("select * from Rooms where roomTypeName = '"+ roomTypeName + "'").ToList<Room>(); ;
                
            return Json(RoomList, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                List<Room> RoomList = new List<Room>();
                return Json(RoomList, JsonRequestBehavior.AllowGet);
            }


        }


    }
}