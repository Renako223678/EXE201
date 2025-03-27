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
    [Route("api/packages")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null) return NotFound("Package not found.");
            return Ok(package);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackageDTO packageDto)
        {
            if (packageDto == null) return BadRequest("Invalid package data.");

            var package = new Package
            {
                AccountId = packageDto.AccountId,
                DestinationId = packageDto.DestinationId,
                Name = packageDto.Name,
                Description = packageDto.Description,
                Rating = packageDto.Rating,
                Price = packageDto.Price,
                IsActive = packageDto.IsActive
            };

            await _packageService.AddPackageAsync(package);
            return CreatedAtAction(nameof(GetById), new { id = package.Id }, packageDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PackageDTO packageDto)
        {
            if (packageDto == null || id != packageDto.Id) return BadRequest("Invalid package data.");

            var existingPackage = await _packageService.GetPackageByIdAsync(id);
            if (existingPackage == null) return NotFound("Package not found.");

            var package = new Package
            {
                Id = packageDto.Id,
                AccountId = packageDto.AccountId,
                DestinationId = packageDto.DestinationId,
                Name = packageDto.Name,
                Description = packageDto.Description,
                Rating = packageDto.Rating,
                Price = packageDto.Price,
                IsActive = packageDto.IsActive
            };

            await _packageService.UpdatePackageAsync(package);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingPackage = await _packageService.GetPackageByIdAsync(id);
            if (existingPackage == null) return NotFound("Package not found.");

            await _packageService.DeletePackageAsync(id);
            return NoContent();
        }
    }
}
