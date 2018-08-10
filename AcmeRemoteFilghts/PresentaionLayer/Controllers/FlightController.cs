using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.DataLayer.Entities;
using AcmeRemoteFilghts.CoreLayer.Extensions;
using AcmeRemoteFilghts.PresentaionLayer.Extensions;
using AcmeRemoteFilghts.PresentaionLayer.Helpers;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using AcmeRemoteFilghts.ServiceLayer.Flights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

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
        [HttpGet(Name = "GetFlight")]
        public IActionResult GetFlight(FlightResourceParameters param)
        {
            if (param == null)
                return BadRequest();

            if (!ModelState.IsValid) // return 422
                return new AcmeRemoteFilghts.PresentaionLayer.Helpers.UnprocessableResult(ModelState);

            List<FlightViewModel> list = new List<FlightViewModel>();
            try
            {
                list = _flightService.GetAvailableFlightsByDate(param)
                                       .MapTo<FlightViewModel>();
            }
            catch (Exception ex)
            {

            }


            return Ok(list);
        }

        [HttpPost]
        public IActionResult AddNewFlight([FromBody] FlightViewModel flight)
        {
            if (flight == null)
                return BadRequest();

            try
            {
                flight.Id = _flightService.AddNewFlight(flight.ToEntity());
            }
            catch (Exception ex)
            {
                //add logger here
                return StatusCode(500, "A Problem happend with handling your request.");
            }
            return CreatedAtRoute("GetFlight", new { id = flight.Id });

        }

        [HttpDelete("{FlightId}")]
        public IActionResult DeleteFlight(int FlightId)
        {
            var aFlight = _flightService.GetFlightById(FlightId);
            if (aFlight == null)
                return NotFound();

            bool deleted = false;
            try
            {
                deleted = _flightService.DeleteExistingFlight(aFlight.Id);
            }
            catch (Exception ex)
            {
                // log the exception error
                return StatusCode(500, "A Database Problem happend with delete a flight.");
            }
            if (!deleted)
                return StatusCode(500, "Could not delete flight.Please make sure there is no booking assosciate to flights");
            else
                return NoContent();
        }
    }
}