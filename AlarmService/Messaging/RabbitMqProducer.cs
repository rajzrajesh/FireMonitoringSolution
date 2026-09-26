using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using System.Text;

public class RabbitMqProducer
{
    private readonly IConnection _connection;
    private readonly IModel _channel;

    public RabbitMqProducer()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        _connection = factory.CreateConnection();
        _channel = _connection.CreateModel();

        _channel.QueueDeclare(queue: "alarmQueue",
                              durable: false,
                              exclusive: false,
                              autoDelete: false,
                              arguments: null);
    }

    public void Publish(string message)
    {
        var body = Encoding.UTF8.GetBytes(message);
        _channel.BasicPublish(exchange: "",
                              routingKey: "alarmQueue",
                              basicProperties: null,
                              body: body);
    }
}
