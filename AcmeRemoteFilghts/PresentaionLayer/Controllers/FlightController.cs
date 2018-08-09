using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.PresentaionLayer.Extensions;
using AcmeRemoteFilghts.PresentaionLayer.Helpers;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using AcmeRemoteFilghts.ServiceLayer.Flights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AcmeRemoteFilghts.Controllers
{

    [Produces("application/json")]
    [Route("api/Flight")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        public FlightController(IFlightService flightService)
        {
            this._flightService = flightService;
        }
        [EnableCors("CORS")]
        [HttpGet( Name = "GetFlight")]
        public IActionResult GetFlight(FlightResourceParameters param)
        {
            if (param == null)
                return BadRequest();

            if (!ModelState.IsValid) // return 422
                return new AcmeRemoteFilghts.PresentaionLayer.Helpers.UnprocessableResult(ModelState);

            var list = _flightService.GetAvailableFlightsByDate(param)
                       .MapTo<FlightViewModel>(); 

            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddNewFlight([FromBody] FlightViewModel flight)
        {
            if (flight == null)
                return BadRequest();
           
            flight.Id = _flightService.AddNewFlight(flight.MapTo<Flight>());
            if (flight.Id == 0)
                return StatusCode(500, "A Problem happend with handling your request.");

            return CreatedAtRoute("GetFlight", new { id = flight.Id });
           
        }
    }
}