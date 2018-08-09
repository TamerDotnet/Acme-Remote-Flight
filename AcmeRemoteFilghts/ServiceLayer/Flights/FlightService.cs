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
        /// <summary>
        /// Add New flight
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public int AddNewFlight(Flight flight)
        {
            int newFlightId;
            flight = this._journeyRepository.InsertFlight(flight);
            if (flight != null)
                newFlightId = flight.Id;
            else
                newFlightId = 0;

            return newFlightId; 
        }

        /// <summary>
        /// Update Existing Flight 
        /// </summary>
        /// <param name="flight"></param>
        /// <returns></returns>
        public bool UpdateExistingFlight(Flight flight)
        {
            bool updated = false;
            flight = this._journeyRepository.UpdateFlight(flight);
            if(flight != null)
                updated = true;
            return updated;
        }

        /// <summary>
        /// Delete Existing flight based on Flight Id
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public bool DeleteExistingFlight(int Id)
        {
            bool deleted = false;
            deleted = this._journeyRepository.DeleteFlight(Id);
            return deleted;
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
