using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EXE201.Models;

[Route("api/[controller]")]
[ApiController]
public class NotificationController : ControllerBase
{
    private readonly INotificationService _notificationService;

    public NotificationController(INotificationService notificationService)
    {
        _notificationService = notificationService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Notification>>> GetAllNotifications()
    {
        var notifications = await _notificationService.GetAllNotifications();
        return Ok(notifications);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Notification>> GetNotificationById(int id)
    {
        var notification = await _notificationService.GetNotificationById(id);
        if (notification == null) return NotFound();
        return Ok(notification);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification([FromBody] Notification notification)
    {
        await _notificationService.AddNotification(notification);
        return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNotification(int id, [FromBody] Notification notification)
    {
        if (id != notification.Id) return BadRequest();
        await _notificationService.UpdateNotification(notification);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotification(int id)
    {
        await _notificationService.DeleteNotification(id);
        return NoContent();
    }
}
