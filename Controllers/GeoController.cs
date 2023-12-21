using Microsoft.AspNetCore.Mvc;
using Data.Entities;
using System.Net;

namespace GeoLocator.Controllers
{
    [Route("[controller]")]
    public class GeoController : ControllerBase
    {
        private readonly IGeoLocator _geoLocator;

        public GeoController(IGeoLocator geoLocator)
        {
            _geoLocator = geoLocator ?? throw new ArgumentNullException(nameof(geoLocator));
        }        

        [HttpGet("ip/location")]        
        public IActionResult Ip([FromQuery] string ip)
        {
            if (!IPAddress.TryParse(ip, out IPAddress parsedIp))
                return new BadRequestObjectResult(new { Message = "Ip address is not correct." });

            var intIp = (ulong)IPAddress.NetworkToHostOrder((int)parsedIp.Address);

            return Ok(_geoLocator.GetLocationsByIp(intIp));
        }

        [HttpGet("city/locations")]        
        public IActionResult City(string city)
        {
            if (string.IsNullOrWhiteSpace(city)) return new BadRequestObjectResult(new { Message = "NotFound" });

            return Ok( _geoLocator.GetLocationsByCity(city));
        }        
    }
}