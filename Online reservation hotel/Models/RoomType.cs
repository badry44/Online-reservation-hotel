using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_reservation_hotel.Models
{
    public class RoomType
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int roomTypeId { get; set; }
        [Display(Name = "Room Type")]
        public string roomTypeName { get; set; }
        [Display(Name = "Price")]
        public double roomTypePrice { get; set; }
        public virtual List<RoomTransaction> rooms { get; set; }
    }
}