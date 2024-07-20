using CityInfoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CitiesController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<CityDto>> GetCities()
        {
            return Ok(CitiesDataStore.current.Cities);
        }



        [HttpGet("{id}")]
        public ActionResult<CityDto> GetCities(int id)
        {
            var cityToReturn = CitiesDataStore.current.Cities.FirstOrDefault(x => x.Id == id);

            if (cityToReturn == null)
            {
                return NotFound();
            }

            return Ok(cityToReturn);
        }
    }
}
