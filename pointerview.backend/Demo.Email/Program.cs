using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

RabbitMQSettings RabbitMQSettings = new()
{
    HostName = "localhost",
    QueueName = "email_queue"
};

var factory = new ConnectionFactory { HostName = RabbitMQSettings.HostName };
using var connection = await factory.CreateConnectionAsync();
using var channel = await connection.CreateChannelAsync();

await channel.QueueDeclareAsync(queue: RabbitMQSettings.QueueName, durable: false, exclusive: false, autoDelete: false,
    arguments: null);

Console.WriteLine(" [*] Waiting for messages.");

var consumer = new AsyncEventingBasicConsumer(channel);
consumer.ReceivedAsync += (model, ea) =>
{
    var body = ea.Body.ToArray();
    var message = Encoding.UTF8.GetString(body);
    Console.WriteLine(message);
    return Task.CompletedTask;
};

await channel.BasicConsumeAsync(RabbitMQSettings.QueueName, autoAck: true, consumer: consumer);

Console.WriteLine(" Press [enter] to exit.");
Console.ReadLine();

public class RabbitMQSettings
{
    public string HostName { get; set; }
    public string QueueName { get; set; }
}