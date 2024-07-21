using System.Net.WebSockets;
using CityInfoAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CityInfoAPI.Controllers
{
    [Route("api/cities/{cityId}/pointsofinterest")]
    [ApiController]
    public class PointsOfInterestController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<PointOfInterestDto>> GetPointsOfInterest(int cityId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            return Ok(city.PointOfInterests);
        }



        [HttpGet("{pointsOfInterestId}", Name = "GetPointsOfInterest")]
        public ActionResult<PointOfInterestDto> GetPointsOfInterest(int cityId, int pointsOfInterestId)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);

            if (city == null)
            {
                return NotFound();
            }

            var point = city.PointOfInterests.FirstOrDefault(p => p.Id == pointsOfInterestId);
            if (point == null)
            {
                return NotFound();
            }

            return Ok(point);
        }



        [HttpPost]
        public ActionResult<PointOfInterestDto> CreatePointOfInterest(int cityId, PointOfInterestForCreationDto pointOfInterest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var maxpointOfInterestId = CitiesDataStore.current.Cities.SelectMany(c => c.PointOfInterests).Max(p => p.Id);

            var createPoint = new PointOfInterestDto()
            {
                Id = ++maxpointOfInterestId,
                Name = pointOfInterest.Name,
                Description = pointOfInterest.Description
            };

            city.PointOfInterests.Add(createPoint);

            return CreatedAtAction("GetPointsOfInterest", new
            {
                cityId = cityId,
                pointOfInterest = createPoint.Id
            }, createPoint);
        }



        [HttpPut("{pointOfInterestId}")]
        public ActionResult UpdatePointOfInterest(int cityId, int pointOfInterestId, PointOfInterestForUpdateDto pointOfInterest)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }

            var point = city.PointOfInterests.FirstOrDefault(p => p.Id == pointOfInterestId);
            if (point == null)
            {
                return NotFound();
            }

            point.Name = pointOfInterest.Name;
            point.Description = pointOfInterest.Description;

            return NoContent();
        }



        [HttpPatch("{pointOfInterestId}")]
        public ActionResult PartiallyUpdatePointOfInterest(int cityId, int pointOfInterestid, JsonPatchDocument<PointOfInterestForUpdateDto> patchDocument)
        {
            var city = CitiesDataStore.current.Cities.FirstOrDefault(c => c.Id == cityId);
            if (city == null)
            {
                return NotFound();
            }


            var pointOfInterestFromStore = city.PointOfInterests.FirstOrDefault(p => p.Id == pointOfInterestid);
            if (pointOfInterestFromStore == null)
            {
                return NotFound();
            }


            var pointOfInterestToPatch = new PointOfInterestForUpdateDto()
            {
                Name = pointOfInterestFromStore.Name,
                Description = pointOfInterestFromStore.Description
            };

            patchDocument.ApplyTo(pointOfInterestToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            if (!TryValidateModel(pointOfInterestToPatch))
            {
                return BadRequest(modelState:ModelState);
            }

            pointOfInterestFromStore.Name = pointOfInterestToPatch.Name;
            pointOfInterestFromStore.Description = pointOfInterestToPatch.Description;

            return NoContent();
        }
    }
}



