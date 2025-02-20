using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItineraryController : ControllerBase
    {
        private readonly IItineraryService _itineraryService;

        public ItineraryController(IItineraryService itineraryService)
        {
            _itineraryService = itineraryService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var itinerary = await _itineraryService.GetItineraryByIdAsync(id);
            if (itinerary == null) return NotFound();
            return Ok(itinerary);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var itineraries = await _itineraryService.GetAllItinerariesAsync();
            return Ok(itineraries);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Itinerary itinerary)
        {
            await _itineraryService.AddItineraryAsync(itinerary);
            return CreatedAtAction(nameof(GetById), new { id = itinerary.Id }, itinerary);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, Itinerary itinerary)
        {
            if (id != itinerary.Id) return BadRequest();
            await _itineraryService.UpdateItineraryAsync(itinerary);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _itineraryService.DeleteItineraryAsync(id);
            return NoContent();
        }
    }
}
