using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_reservation_hotel.Models
{
    public class Room
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int roomId { get; set; }
        [Display(Name = "Room Name")]
        public string roomName { get; set; }
        public string roomTypeName { get; set; }
        public virtual RoomType roomType { get; set; }


    }
}