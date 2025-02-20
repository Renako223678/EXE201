using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDestinationById(long id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null) return NotFound();
            return Ok(destination);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDestinations()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return Ok(destinations);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDestination([FromBody] Destination destination)
        {
            await _destinationService.AddDestinationAsync(destination);
            return CreatedAtAction(nameof(GetDestinationById), new { id = destination.Id }, destination);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDestination(long id, [FromBody] Destination destination)
        {
            if (id != destination.Id) return BadRequest();
            await _destinationService.UpdateDestinationAsync(destination);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDestination(long id)
        {
            await _destinationService.DeleteDestinationAsync(id);
            return NoContent();
        }
    }
}

