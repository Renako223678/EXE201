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
    [Route("api/notifications")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notifications = await _notificationService.GetAllNotifications();
            return Ok(notifications);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var notification = await _notificationService.GetNotificationById(id);
            if (notification == null) return NotFound("Notification not found.");
            return Ok(notification);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NotificationDTO notificationDto)
        {
            if (notificationDto == null) return BadRequest("Invalid notification data.");

            var notification = new Notification
            {   Id = notificationDto.Id,
                AccountId = notificationDto.AccountId,
                Title = notificationDto.Title,
                Description = notificationDto.Description,
                IsActive = notificationDto.IsActive
            };

            await _notificationService.AddNotification(notification);
            return CreatedAtAction(nameof(GetById), new { id = notification.Id }, notificationDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] NotificationDTO notificationDto)
        {
            if (notificationDto == null || id != notificationDto.Id) return BadRequest("Invalid notification data.");

            var existingNotification = await _notificationService.GetNotificationById(id);
            if (existingNotification == null) return NotFound("Notification not found.");

            var notification = new Notification
            {
                Id = notificationDto.Id,
                AccountId = notificationDto.AccountId,
                Title = notificationDto.Title,
                Description = notificationDto.Description,
                IsActive = notificationDto.IsActive
            };

            await _notificationService.UpdateNotification(notification);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var existingNotification = await _notificationService.GetNotificationById(id);
            if (existingNotification == null) return NotFound("Notification not found.");

            await _notificationService.DeleteNotification(id);
            return NoContent();
        }
    }
}
