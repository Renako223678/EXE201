using System.Collections.Generic;
using System.Threading.Tasks;
using EXE201.Controllers.DTO;
using EXE201.DTO;
using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/itineraries")]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _itineraryService;

        public ItineraryController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itineraries = await _itineraryService.GetAllItinerariesAsync();
            return Ok(itineraries);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var itinerary = await _itineraryService.GetItineraryByIdAsync(id);
            if (itinerary == null) return NotFound("Itinerary not found.");
            return Ok(itinerary);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ItineraryDTO itineraryDto)
        {
            if (itineraryDto == null) return BadRequest("Invalid itinerary data.");

            var itinerary = new Itinerary
            {   Id = itineraryDto.Id,
                PackageId = itineraryDto.PackageId,
                Date = itineraryDto.Date,
                Description = itineraryDto.Description,
                IsActive = itineraryDto.IsActive
            };

            await _itineraryService.AddItineraryAsync(itinerary);
            return CreatedAtAction(nameof(GetById), new { id = itinerary.Id }, itineraryDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] ItineraryDTO itineraryDto)
        {
            if (itineraryDto == null || id != itineraryDto.Id) return BadRequest("Invalid itinerary data.");

            var existingItinerary = await _itineraryService.GetItineraryByIdAsync(id);
            if (existingItinerary == null) return NotFound("Itinerary not found.");

            var itinerary = new Itinerary
            {
                Id = itineraryDto.Id,
                PackageId = itineraryDto.PackageId,
                Date = itineraryDto.Date,
                Description = itineraryDto.Description,
                IsActive = itineraryDto.IsActive
            };

            await _itineraryService.UpdateItineraryAsync(itinerary);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingItinerary = await _itineraryService.GetItineraryByIdAsync(id);
            if (existingItinerary == null) return NotFound("Itinerary not found.");

            await _itineraryService.DeleteItineraryAsync(id);
            return NoContent();
        }
    }
}
