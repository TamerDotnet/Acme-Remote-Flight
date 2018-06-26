using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.DataLayer.Repositories;
using System.Collections.Generic;

namespace AcmeRemoteFilghts.ServiceLayer.Flights
{

    public class FlightService : IFlightService
    { 
        private readonly IJourneyRepository _journeyRepository;
        
        public FlightService(IJourneyRepository journeyRepository )
        { 
            this._journeyRepository = journeyRepository;
        }
        public ICollection<Flight> GetAvailableFlightsByDate(FlightResourceParameters flightResourceParameters)
        {
            // Get list of flights within that Date range and requested number of tickets
            ICollection<Flight> dbFlights = this._journeyRepository.GetAvailableFlightsByDate (flightResourceParameters.StartDate, 
                flightResourceParameters.EndDate, flightResourceParameters.numberOfTicketsRequested);

            return dbFlights;
        }  
        
        
    }
}
