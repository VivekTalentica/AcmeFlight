using AcmeRemote.BusinessEntity;
using AcmeRemote.DataService;
using AcmeRemoteFlight.Models;
using DependencyInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Unity;

namespace AcmeRemoteFlight.Controllers
{
    public class FlightController : ApiController
    {
        private IService _service;
        public FlightController()
        {
            _service = Container.DependencyResolver.Resolve<IService>() ;
        }


        /// <summary>
        /// Get the available flights
        /// </summary>
        /// <param name="flightRequest"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/v1/getAvailableFlights")]
        public IHttpActionResult GetAvailableFlights(FlightRequest flightRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Inavlid request");
            }
            try
            {
                var flights = _service.GetFlights(flightRequest.StartDate, flightRequest.EndDate);
                var helicopters = _service.GetAllHelicopter().ToDictionary(x => x.Id, x => x);
                var cities = _service.GetAllCities().ToDictionary(x => x.Id, x => x);
                var response = new List<FlightResponse>();
                flights.ForEach(f =>
                {
                    var temp = new FlightResponse
                    {
                        BookedSeats = f.BookedSeats,
                        Capacity = helicopters[f.HelicopterId].Capacity,
                        Destination = cities[f.DestinationId],
                        Source = cities[f.SourceId],
                        FlightNumber = f.FlightNumber
                    };
                    if (temp.Available >= flightRequest.Pax)
                        response.Add(temp);
                });
                return Ok(response);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }
        
    }
}
