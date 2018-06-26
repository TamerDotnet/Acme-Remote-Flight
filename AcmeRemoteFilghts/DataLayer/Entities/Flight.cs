using AcmeRemoteFilghts.CoreLayer.Data;
using System;
using System.Collections.Generic; 
using System.ComponentModel.DataAnnotations.Schema;

namespace AcmeRemoteFilghts.DataLayer.Entities
{
    public class Flight:BaseEntity
    {
        
        public int CityFromId { get; set; }
        public virtual City CityFrom { get; set; }
        public int CityToId  { get; set; }
        public virtual City CityTo { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArriveTime { get; set; }
        public int MaxPassangers { get; set; }
        public   ICollection<Booking> Bookings { get; set; }

        [NotMapped]
        public int AvailableSeats { get; set; }
    }
}
