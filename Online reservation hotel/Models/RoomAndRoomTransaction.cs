using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Online_reservation_hotel.Models
{
    public class RoomAndRoomTransaction
    {
        public Room room { get; set; }
        public RoomTransaction roomTransaction { get; set; }
    }
}