using AcmeRemoteFilghts.CoreLayer.Data;
using System;

namespace AcmeRemoteFilghts.PresentaionLayer.Models
{
    public class BookingViewModel: BaseEntity
    {
        public int FlightId { get; set; }
        public virtual FlightViewModel flight { get; set; }
        public DateTime FlightDate { get; set; }
        public string Bookedby { get; set; }
        public int NoTickets { get; set; }

    }
}
