using AlarmService.Data;
using AlarmService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AlarmService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AlarmController : ControllerBase
{
    private readonly AlarmDbContext _context;

    public AlarmController(AlarmDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlarms()
    {
        var alarms =
            await _context.Alarms.ToListAsync();

        return Ok(alarms);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAlarm(int id)
    {
        var alarm =
            await _context.Alarms.FindAsync(id);

        if (alarm == null)
            return NotFound();

        return Ok(alarm);
    }

    [HttpPost]
    public async Task<IActionResult> CreateAlarm(
        Alarm alarm)
    {
        alarm.CreatedTime = DateTime.Now;

        _context.Alarms.Add(alarm);

        await _context.SaveChangesAsync();

        return Ok(alarm);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAlarm(
        int id,
        Alarm updatedAlarm)
    {
        var alarm =
            await _context.Alarms.FindAsync(id);

        if (alarm == null)
            return NotFound();

        alarm.DeviceId = updatedAlarm.DeviceId;
        alarm.Status = updatedAlarm.Status;

        await _context.SaveChangesAsync();

        return Ok(alarm);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAlarm(
        int id)
    {
        var alarm =
            await _context.Alarms.FindAsync(id);

        if (alarm == null)
            return NotFound();

        _context.Alarms.Remove(alarm);

        await _context.SaveChangesAsync();

        return NoContent();
    }
    [HttpPost("trigger")]
    public IActionResult TriggerAlarm()
    {
        var producer = new RabbitMqProducer();
        producer.Publish("Alarm triggered at " + DateTime.Now);

        return Ok("Alarm published to RabbitMQ");
    }

}