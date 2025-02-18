using RabbitMQ.Client;
using System.Text;

namespace POInterview.Infrastructure.MessageBrokers;

public sealed class EmailPublisher : IMessagePublisher
{
    private readonly RabbitMQSettings _rabbitMQSettings = new()
    {
        HostName = "localhost",
        QueueName = "email_queue"
    };


    public async Task PublishMessage(string body)
    {
        var factory = new ConnectionFactory { HostName = _rabbitMQSettings.HostName };

        using var connection = await factory.CreateConnectionAsync();
        using var channel = await connection.CreateChannelAsync();

        await channel.QueueDeclareAsync(queue: _rabbitMQSettings.QueueName, durable: false, exclusive: false, autoDelete: false,
    arguments: null);

        byte[] bodyBytes = Encoding.UTF8.GetBytes(body);

        await channel.BasicPublishAsync(exchange: string.Empty, routingKey: _rabbitMQSettings.QueueName, bodyBytes);
    }

}

public class RabbitMQSettings
{
    public string HostName { get; set; }
    public string QueueName { get; set; }
}