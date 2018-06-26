
using AcmeRemoteFilghts.DataLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AcmeRemoteFilghts.DataLayer.Repositories
{
    public interface IJourneyRepository 
    {
        ICollection<Flight> GetAvailableFlightsByDate(DateTime StartDate, DateTime EndDate, int NumPassangers);
    }
}
