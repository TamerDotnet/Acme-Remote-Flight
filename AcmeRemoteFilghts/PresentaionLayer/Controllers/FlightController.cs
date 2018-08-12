using AcmeRemoteFilghts.CoreLayer.Extensions;
using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.PresentaionLayer.Extensions;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using AcmeRemoteFilghts.ServiceLayer.Flights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace AcmeRemoteFilghts.Controllers
{

    [Produces("application/json")]
    [Route("api/Flight")]
    public class FlightController : Controller
    {
        private readonly IFlightService _flightService;
        private ILogger<FlightController> _logger;
        public FlightController(IFlightService flightService, ILogger<FlightController> logger)
        {
            this._flightService = flightService;
            this._logger = logger;
        }
        [EnableCors("CORS")]
        [HttpGet(Name = "GetFlight")]
        public IActionResult GetFlight(FlightResourceParameters param)
        {
            if (param == null)
                return BadRequest();

            // throw new ApplicationException("Sorry did load by mistake");
            if (!ModelState.IsValid) // return 422
                return new AcmeRemoteFilghts.PresentaionLayer.Helpers.UnprocessableResult(ModelState);

            _logger.LogCritical("******************Start Loading******************************");

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

            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            try
            {
                flight.Id = _flightService.AddNewFlight(flight.ToEntity());
            }
            catch (Exception ex)
            {
                _logger.LogCritical("Could not add new flight details.", ex);
                return StatusCode(500, "A Problem happend with handling your request.");
            }
            return CreatedAtRoute("GetFlight", new { id = flight.Id });
        }

        [HttpPut("{Id}")]
        public IActionResult UpdateFlight(int Id , [FromBody] FlightViewModel flightModel)
        {
            if (flightModel == null)
                return BadRequest();

            // check if model state which include the flight business rules(FlightViewModelValidators) are all valid
            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

            var aFlight = _flightService.GetFlightById(Id);
            if (aFlight == null)
                return NotFound();

            aFlight = flightModel.ToEntity();
            aFlight.Id = Id;
            bool saved = _flightService.UpdateExistingFlight(aFlight);
            if (!saved)
            {
                _logger.LogCritical("Could not update flight details.");
                return StatusCode(500, $"Updating flight {Id} failed on save operation.");
            }
            return NoContent();
        }

        [HttpDelete("{FlightId}")]
        public IActionResult DeleteFlight(int FlightId)
        {
            if (!ModelState.IsValid)
                return new UnprocessableEntityObjectResult(ModelState);

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
                 _logger.LogCritical("Could not delete flight details.", ex);
                return StatusCode(500, "A Database Problem happend with delete a flight.");
            }
            if (!deleted)
                return StatusCode(500, "Could not delete flight.Please make sure there is no booking assosciate to flights");
            else
                return NoContent();
        }
    }
}