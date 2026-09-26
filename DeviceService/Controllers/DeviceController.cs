using DeviceService.Data;
using DeviceService.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DeviceService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DeviceController : ControllerBase
{
    private readonly DeviceDbContext _context;

    public DeviceController(DeviceDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetDevices()
    {
        var devices =
            await _context.Devices.ToListAsync();

        return Ok(devices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDevice(int id)
    {
        var device =
            await _context.Devices.FindAsync(id);

        if (device == null)
            return NotFound();

        return Ok(device);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDevice(
        Device device)
    {
        device.CreatedDate = DateTime.Now;

        _context.Devices.Add(device);

        await _context.SaveChangesAsync();

        return Ok(device);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDevice(
        int id,
        Device updatedDevice)
    {
        var device =
            await _context.Devices.FindAsync(id);

        if (device == null)
            return NotFound();

        device.DeviceName = updatedDevice.DeviceName;
        device.DeviceType = updatedDevice.DeviceType;
        device.Location = updatedDevice.Location;
        device.Status = updatedDevice.Status;

        await _context.SaveChangesAsync();

        return Ok(device);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDevice(
        int id)
    {
        var device =
            await _context.Devices.FindAsync(id);

        if (device == null)
            return NotFound();

        _context.Devices.Remove(device);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}