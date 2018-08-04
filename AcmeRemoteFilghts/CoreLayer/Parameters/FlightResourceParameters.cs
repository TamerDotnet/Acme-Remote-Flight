using AcmeRemoteFilghts.CoreLayer.SourceValidators;
using FluentValidation.Attributes;
using System;

namespace AcmeRemoteFilghts.CoreLayer.Parameters
{
    [Validator(typeof(FlightResourceValidators))]
    public class FlightResourceParameters
    {
        public int FlightId { get; set; }
        public CityResourceParameters CityFrom { get; set; }
        public CityResourceParameters CityTo { get; set; }
        public int MaxPassangers { get; set; }
        public int AvailableSeats { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int numberOfTicketsRequested { get; set; }
        public FlightResourceParameters()
        {
            CityFrom = new CityResourceParameters();
            CityTo = new CityResourceParameters();
        }
    }
}
