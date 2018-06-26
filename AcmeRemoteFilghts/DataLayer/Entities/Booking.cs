using AcmeRemoteFilghts.CoreLayer.Data;
using System;

namespace AcmeRemoteFilghts.DataLayer.Entities
{
    public class Booking:BaseEntity
    {
        public int FlightId { get; set; }
        public virtual Flight flight { get; set; }
        public DateTime FlightDate { get; set; }
        public string Bookedby { get; set; }
        public int NoTickets { get; set; }

    }
}
