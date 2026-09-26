using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

public class RabbitMqConsumer
{
    public void Start()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "alarmQueue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"[DeviceService] Received: {message}");
        };

        channel.BasicConsume(queue: "alarmQueue",
                             autoAck: true,
                             consumer: consumer);

        Console.WriteLine("DeviceService is listening for alarms...");
        Console.ReadLine(); // Keep running
    }
}
