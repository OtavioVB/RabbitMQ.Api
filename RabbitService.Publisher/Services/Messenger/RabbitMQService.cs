using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitService.Publisher.Services.Messenger;

public class RabbitMQService
{
    public void PublishMessage(string fila, string message)
    {
        var connectionFactory = new ConnectionFactory()
        {
            VirtualHost = Environment.GetEnvironmentVariable("RABBITMQ_VIRTUALHOST"),
            UserName = Environment.GetEnvironmentVariable("RABBITMQ_USER"),
            Password = Environment.GetEnvironmentVariable("RABBITMQ_PASSWORD"),
            HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST"),
            Port = 5672
        };

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
                channel.BasicPublish(exchange: "", routingKey: fila, basicProperties: null, body: Encoding.UTF8.GetBytes(message));
            }
        }
    }
}
