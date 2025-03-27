using EXE201.Controllers.DTO;
using EXE201.DTO;
using EXE201.Models;
using EXE201.Service.Interface;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EXE201.Controllers
{
    //Đã check api
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        // Lấy Service theo ID
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceDTO>> GetById(long id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            if (service == null) return NotFound();

            return Ok(new ServiceDTO
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Price = service.Price,
                IsActive = service.IsActive
            });
        }

        // Lấy tất cả Services
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceDTO>>> GetAll()
        {
            var services = await _serviceService.GetAllAsync();
            var result = new List<ServiceDTO>();

            foreach (var service in services)
            {
                result.Add(new ServiceDTO
                {
                    Id = service.Id,
                    Name = service.Name,
                    Description = service.Description,
                    Price = service.Price,
                    IsActive = service.IsActive
                });
            }

            return Ok(result);
        }

        // Thêm mới Service
        [HttpPost]
        public async Task<ActionResult> Add(ServiceDTO serviceDTO)
        {
            var service = new Models.Service
            {
                Name = serviceDTO.Name,
                Description = serviceDTO.Description,
                Price = serviceDTO.Price,
                IsActive = serviceDTO.IsActive
            };

            await _serviceService.AddAsync(service);
            return CreatedAtAction(nameof(GetById), new { id = service.Id }, serviceDTO);
        }

        // Cập nhật Service
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(long id, ServiceDTO serviceDTO)
        {
            var existingService = await _serviceService.GetByIdAsync(id);
            if (existingService == null) return NotFound();

            existingService.Name = serviceDTO.Name;
            existingService.Description = serviceDTO.Description;
            existingService.Price = serviceDTO.Price;
            existingService.IsActive = serviceDTO.IsActive;

            await _serviceService.UpdateAsync(existingService);
            return NoContent();
        }

        // Xóa Service
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(long id)
        {
            var existingService = await _serviceService.GetByIdAsync(id);
            if (existingService == null) return NotFound();

            await _serviceService.DeleteAsync(id);
            return NoContent();
        }
    }
}
