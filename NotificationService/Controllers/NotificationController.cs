using NotificationService.Data;
using NotificationService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NotificationService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class NotificationController : ControllerBase
{
    private readonly NotificationDbContext _context;
    private readonly NotificationManager _manager;

    public NotificationController(NotificationDbContext context, NotificationManager manager)
    {
        _context = context;
        _manager = manager;
    }

    [HttpGet]
    public async Task<IActionResult> GetNotifications()
    {
        var Notifications =
            await _context.Notifications.ToListAsync();

        return Ok(Notifications);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetNotification(int id)
    {
        var Notification =
            await _context.Notifications.FindAsync(id);

        if (Notification == null)
            return NotFound();

        return Ok(Notification);
    }

    [HttpPost]
    public async Task<IActionResult> CreateNotification(Notification notification)
    {
        notification.SentTime = DateTime.Now;

        _context.Notifications.Add(notification);

        await _context.SaveChangesAsync();
        await _manager.SendNotificationAsync(notification);

        return Ok(notification);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateNotification(
        int id,
        Notification updatedNotification)
    {
        var notification =
            await _context.Notifications.FindAsync(id);

        if (notification == null)
            return NotFound();

        notification.AlarmId = updatedNotification.AlarmId;
        notification.Recipient = updatedNotification.Recipient;
        notification.Channel = updatedNotification.Channel;
        notification.Message = updatedNotification.Message;
        notification.Status = updatedNotification.Status;

        await _context.SaveChangesAsync();

        return Ok(notification);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNotification(
        int id)
    {
        var Notification =
            await _context.Notifications.FindAsync(id);

        if (Notification == null)
            return NotFound();

        _context.Notifications.Remove(Notification);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}