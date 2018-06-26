using AcmeRemoteFilghts.CoreLayer.Data;
using System;
using System.Collections.Generic;

namespace AcmeRemoteFilghts.PresentaionLayer.Models
{
    public class FlightViewModel:BaseEntity
    {
        public CityViewModel CityFrom { get; set; }
        public CityViewModel CityTo { get; set; }
        public DateTime DepartTime { get; set; }
        public DateTime ArriveTime { get; set; }
        public int MaxPassangers { get; set; }
        public int AvailableSeats { get; set; }


    }
}
