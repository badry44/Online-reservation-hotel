using Online_reservation_hotel.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Online_reservation_hotel.Context
{
    public class reservationContext : DbContext
    {
        public DbSet<RoomTransaction>roomTrans { get; set; }
        public DbSet<RoomType> roomType { get; set; }
        public DbSet<Room> room { get; set; }
    }
}