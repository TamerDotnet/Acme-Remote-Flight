
using AcmeRemoteFilghts.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeRemoteFilghts.DataLayer.Repositories
{
    public interface IJourneyRepository 
    {
        ICollection<Flight> GetAvailableFlightsByDate(DateTime StartDate, DateTime EndDate, int NumPassangers);
        ICollection<Flight> GetAllFlightsByDate(DateTime StartDate, DateTime EndDate);

        Flight GetExistingFlight(int FlightId);
        Flight InsertFlight(Flight flight);
        Flight UpdateFlight(Flight flight);
        bool DeleteFlight(int Id);
    }
}
