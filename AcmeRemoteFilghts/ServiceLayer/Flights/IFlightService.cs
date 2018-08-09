using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using System.Collections.Generic;

namespace AcmeRemoteFilghts.ServiceLayer.Flights
{
    public interface IFlightService
    {
       ICollection<Flight> GetAvailableFlightsByDate(FlightResourceParameters flightResourceParameters);

        int AddNewFlight(Flight flight);
        bool UpdateExistingFlight(Flight flight);
        bool DeleteExistingFlight(int Id);
    }
}
