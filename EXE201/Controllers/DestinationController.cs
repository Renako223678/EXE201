using System.Collections.Generic;
using System.Threading.Tasks;
using EXE201.Controllers.DTO;
using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/destinations")]
    public class DestinationController : ControllerBase
    {
        private readonly IDestinationService _destinationService;

        public DestinationController(IDestinationService destinationService)
        {
            _destinationService = destinationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var destinations = await _destinationService.GetAllDestinationsAsync();
            return Ok(destinations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var destination = await _destinationService.GetDestinationByIdAsync(id);
            if (destination == null) return NotFound("Destination not found.");
            return Ok(destination);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] DestinationDTO destinationDto)
        {
            if (destinationDto == null) return BadRequest("Invalid destination data.");

            var destination = new Destination
            {
                Name = destinationDto.Name,
                Description = destinationDto.Description,
                Location = destinationDto.Location,
                IsActive = destinationDto.IsActive
            };

            await _destinationService.AddDestinationAsync(destination);
            return CreatedAtAction(nameof(GetById), new { id = destination.Id }, destinationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] DestinationDTO destinationDto)
        {
            if (destinationDto == null || id != destinationDto.Id) return BadRequest("Invalid destination data.");

            var existingDestination = await _destinationService.GetDestinationByIdAsync(id);
            if (existingDestination == null) return NotFound("Destination not found.");

            var destination = new Destination
            {
                Id = destinationDto.Id,
                Name = destinationDto.Name,
                Description = destinationDto.Description,
                Location = destinationDto.Location,
                IsActive = destinationDto.IsActive
            };

            await _destinationService.UpdateDestinationAsync(destination);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingDestination = await _destinationService.GetDestinationByIdAsync(id);
            if (existingDestination == null) return NotFound("Destination not found.");

            await _destinationService.DeleteDestinationAsync(id);
            return NoContent();
        }
    }
}
