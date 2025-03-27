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
    [Route("api/packageservices")]
    public class PackageServiceController : ControllerBase
    {
        private readonly IPackageServiceService _packageServiceService;

        public PackageServiceController(IPackageServiceService packageServiceService)
        {
            _packageServiceService = packageServiceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var packageServices = await _packageServiceService.GetAllPackageServicesAsync();
            return Ok(packageServices);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var packageService = await _packageServiceService.GetPackageServiceByIdAsync(id);
            if (packageService == null) return NotFound("Package service not found.");
            return Ok(packageService);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] PackageServiceDTO packageServiceDto)
        {
            if (packageServiceDto == null) return BadRequest("Invalid package service data.");

            var packageService = new PackageService
            {
                Id = packageServiceDto.Id,
                PackageId = packageServiceDto.PackageId,
                ServiceId = packageServiceDto.ServiceId,
                Price = packageServiceDto.Price,
                IsActive = packageServiceDto.IsActive
            };

            await _packageServiceService.AddPackageServiceAsync(packageService);
            return CreatedAtAction(nameof(GetById), new { id = packageService.Id }, packageServiceDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] PackageServiceDTO packageServiceDto)
        {
            if (packageServiceDto == null || id != packageServiceDto.Id) return BadRequest("Invalid package service data.");

            var existingPackageService = await _packageServiceService.GetPackageServiceByIdAsync(id);
            if (existingPackageService == null) return NotFound("Package service not found.");

            var packageService = new PackageService
            {
                Id = packageServiceDto.Id,
                PackageId = packageServiceDto.PackageId,
                ServiceId = packageServiceDto.ServiceId,
                Price = packageServiceDto.Price,
                IsActive = packageServiceDto.IsActive
            };

            await _packageServiceService.UpdatePackageServiceAsync(packageService);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingPackageService = await _packageServiceService.GetPackageServiceByIdAsync(id);
            if (existingPackageService == null) return NotFound("Package service not found.");

            await _packageServiceService.DeletePackageServiceAsync(id);
            return NoContent();
        }
    }
}
