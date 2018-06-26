using AcmeRemoteFilghts.CoreLayer.Data;
using AcmeRemoteFilghts.DataLayer.Entities;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AcmeRemoteFilghts.DataLayer.Repositories
{
    public static  class JourneyExtention
    {
        public static IQueryable<Flight> GetAvailableFlightsWithBookings(this IQueryable<Flight> query, int NumPassangers)
        {
            return query.Where(f=>f.Bookings.Sum(b => b.NoTickets) + NumPassangers <= f.MaxPassangers)
                        .Select(f => new Flight()
                        {
                            Id = f.Id,
                            ArriveTime = f.ArriveTime,
                            Bookings = f.Bookings,
                            CityFrom = f.CityFrom,
                            CityFromId = f.CityFromId,
                            CityTo = f.CityTo,
                            CityToId = f.CityToId,
                            DepartTime = f.DepartTime,
                            MaxPassangers = f.MaxPassangers,
                            AvailableSeats = f.MaxPassangers - f.Bookings.Sum(b => b.NoTickets)
                        });
        }

        public static IQueryable<Flight> GetFlightsWithNoBookings(this IQueryable<Flight> query)
        {
            return query.Where(f=> f.Bookings.Count == 0)
                        .Select(f => new Flight
                        {
                            Id = f.Id,
                            ArriveTime = f.ArriveTime,
                            Bookings = f.Bookings,
                            CityFrom = f.CityFrom,
                            CityFromId = f.CityFromId,
                            CityTo = f.CityTo,
                            CityToId = f.CityToId,
                            DepartTime = f.DepartTime,
                            MaxPassangers = f.MaxPassangers,
                            AvailableSeats = f.MaxPassangers
                        });
        }
        public static IQueryable<Flight> GetFlightsByDate(this IRepository<Flight> flightRepository  , DateTime StartDate, DateTime EndDate)
        {
            return flightRepository.Table.Include(x => x.Bookings)
                              .Include(x => x.CityFrom)
                              .Include(x => x.CityTo)
                              .Where(x => x.DepartTime.Date >= StartDate.Date
                                && x.DepartTime.Date <= EndDate.Date).AsQueryable();
        }
    }
}
