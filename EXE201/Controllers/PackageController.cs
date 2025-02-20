using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EXE201.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PackageController : ControllerBase
    {
        private readonly IPackageService _packageService;

        public PackageController(IPackageService packageService)
        {
            _packageService = packageService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPackageById(long id)
        {
            var package = await _packageService.GetPackageByIdAsync(id);
            if (package == null) return NotFound();
            return Ok(package);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllPackages()
        {
            var packages = await _packageService.GetAllPackagesAsync();
            return Ok(packages);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePackage([FromBody] Package package)
        {
            await _packageService.AddPackageAsync(package);
            return CreatedAtAction(nameof(GetPackageById), new { id = package.Id }, package);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePackage(long id, [FromBody] Package package)
        {
            if (id != package.Id) return BadRequest();
            await _packageService.UpdatePackageAsync(package);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(long id)
        {
            await _packageService.DeletePackageAsync(id);
            return NoContent();
        }
    }
}
