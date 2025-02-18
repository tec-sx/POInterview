namespace POInterview.Infrastructure.MessageBrokers;

public interface IMessagePublisher
{
    Task PublishMessage(string body);
}
