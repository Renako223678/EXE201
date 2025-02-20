using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageServiceController : ControllerBase
    {
        private readonly IPackageServiceService _packageServiceService;

        public PackageServiceController(IPackageServiceService packageServiceService)
        {
            _packageServiceService = packageServiceService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageServiceById(long id)
        {
            var packageService = await _packageServiceService.GetPackageServiceByIdAsync(id);
            if (packageService == null) return NotFound();
            return Ok(packageService);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPackageServices()
        {
            var packageServices = await _packageServiceService.GetAllPackageServicesAsync();
            return Ok(packageServices);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackageService([FromBody] PackageService packageService)
        {
            await _packageServiceService.AddPackageServiceAsync(packageService);
            return CreatedAtAction(nameof(GetPackageServiceById), new { id = packageService.Id }, packageService);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackageService(long id, [FromBody] PackageService packageService)
        {
            if (id != packageService.Id) return BadRequest();
            await _packageServiceService.UpdatePackageServiceAsync(packageService);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackageService(long id)
        {
            await _packageServiceService.DeletePackageServiceAsync(id);
            return NoContent();
        }
    }
}

