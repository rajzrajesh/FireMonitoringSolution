namespace NotificationService.Models;

public class Notification
{
    public int Id { get; set; }

    public int AlarmId { get; set; }

    public string Recipient { get; set; } = string.Empty;

    public string Channel { get; set; } = string.Empty;

    public string Message { get; set; } = string.Empty;

    public string Status { get; set; } = string.Empty;

    public DateTime SentTime { get; set; }
}