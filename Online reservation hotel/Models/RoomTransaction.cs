using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Online_reservation_hotel.Models
{
    public class RoomTransaction
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int roomTransId { get; set; }
        [Display(Name = "Room Name")]
        [Required]
        public string roomName { get; set; }
        [Display(Name = "Room Type Name")]
        [Required]
        public string roomTypeName { get; set; }
        [Required]
        public DateTime from { get; set; }
        [Required]
        public DateTime to { get; set; }
        [Display(Name = "Number of days")]
        public  int numberOfDays { get; set; }
        public double price { get; set; }
        public virtual RoomType roomType { get; set; }
        public virtual Room room { get; set; }
    }
}