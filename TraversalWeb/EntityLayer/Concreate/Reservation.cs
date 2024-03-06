using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concreate
{
    public class Reservation
    {

        [Key]
        public int ReservationID { get; set; }
        public int AppUserID { get; set; }
        public AppUser AppUser { get; set; }
        public string? PersonCount { get; set; }
        public int DestinationID { get; set; }
        public virtual Destination? Destination { get; set; }
        public DateTime ReservationDate { get; set; }
        public string? Description { get; set; }
        //public int StatusId { get; set; }
        // İlişki için

        public int ReservationStatusID { get; set; }
        public virtual ReservationStatus? Status { get; set; }

    }
}
