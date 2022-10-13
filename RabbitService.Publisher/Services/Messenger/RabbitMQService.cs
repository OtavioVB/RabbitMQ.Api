using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace RabbitService.Publisher.Services.Messenger;

public class RabbitMQService
{
    public void PublishMessage(string fila)
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

                var consumer = new EventingBasicConsumer(channel);
                channel.BasicConsume(queue: fila, autoAck: true, consumer: consumer);
            }
        }
    }
}
