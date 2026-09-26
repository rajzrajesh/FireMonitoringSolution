namespace DeviceService.Models;

public class Device
{
    public int Id { get; set; }

    public string DeviceName { get; set; } = string.Empty;

    public string DeviceType { get; set; } = string.Empty;

    public string Location { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}