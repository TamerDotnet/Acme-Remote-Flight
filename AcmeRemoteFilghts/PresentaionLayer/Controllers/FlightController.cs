using AcmeRemoteFilghts.CoreLayer.Parameters;
using AcmeRemoteFilghts.PresentaionLayer.Extensions;
using AcmeRemoteFilghts.PresentaionLayer.Helpers;
using AcmeRemoteFilghts.PresentaionLayer.Models;
using AcmeRemoteFilghts.ServiceLayer.Flights;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

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
    }
}