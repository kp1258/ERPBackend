using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ERPBackend.Entities;

namespace ERPBackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        // private readonly ILogger<WeatherForecastController> _logger;

        // public WeatherForecastController(ILogger<WeatherForecastController> logger)
        // {
        //     _logger = logger;
        // }

        private readonly ERPContext _context;

        public WeatherForecastController(ERPContext context)
        {
            _context = context;
        }


        // [HttpGet]
        // public IActionResult Get()
        // {

        // }
    }
}
