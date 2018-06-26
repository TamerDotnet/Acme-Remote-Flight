using AcmeRemoteFilghts.CoreLayer.Data;
using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace AcmeRemoteFilghts.DataLayer.Repositories
{
    public class JourneyRepository : IJourneyRepository

    {
        private readonly IRepository<Flight> _flightRepository; 

        public JourneyRepository(IRepository<Flight> flightRepository)
        {
            this._flightRepository = flightRepository; 
        }

        /// <summary>
        /// Get flights based on date range and requested number of tickets
        /// </summary>
        /// <param name="StartDate"></param>
        /// <param name="EndDate"></param>
        /// <param name="NumPassangers"></param>
        /// <returns>Collection of Database Flights</returns>
        public ICollection<Flight> GetAvailableFlightsByDate(DateTime StartDate,
         DateTime EndDate, int NumPassangers)
        {
            //1- Get flights based on date range 
            IQueryable<Flight> query = this._flightRepository.GetFlightsByDate(StartDate, EndDate);

            return query.GetAvailableFlightsWithBookings(NumPassangers)  // Flights that have bookings and still have available seats
                  .Union(query.GetFlightsWithNoBookings())       // union with Flights have no bookings at all
                  .Distinct()
                  .OrderBy(x => x.Id)
                  .ToList();   // Execute the Query
         }
    }
}
