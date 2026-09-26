namespace AlarmService.Models;

public class Alarm
{
    public int Id { get; set; }

    public int DeviceId { get; set; }

    public string Status { get; set; } = "";

    public DateTime CreatedTime  { get; set; }
}
