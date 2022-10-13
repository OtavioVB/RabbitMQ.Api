using RabbitMQ.Client;
namespace RabbitService.Consumer.Services.Messenger;

public class RabbitMQService
{
    public void ConsumeMessage(string fila)
    {
        var connectionFactory = new ConnectionFactory();

        using (var connection = connectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(
                    queue: fila,
                    durable: true,
                    exclusive: false,
                    autoDelete: true,
                    arguments: null);

            }
        }
    }
}
