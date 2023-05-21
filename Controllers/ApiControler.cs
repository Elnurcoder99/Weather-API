using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Api.Models;
using Api.Services;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        

        private static IWeather _service;
        public ApiController(IWeather service){
            _service=service;
        }

        // GET: api/ApiController
        [HttpGet("{city}")] //defining parameters, city in this case
        public ActionResult<Weatherclass> GetCurrent(String city)
        {
            
            return Ok(_service.GetCurrent(city));
        }


         [HttpGet("api/{startingDate}/{endingDate}/{city}")] //defining parameters, city in this case
        public ActionResult<List<Weatherclass>> GetHistoricalData(String startingDate, String endingDate, String city)
        {
            
            return Ok(_service.GetHistoricalData(startingDate, endingDate, city));
        }

    }
}
