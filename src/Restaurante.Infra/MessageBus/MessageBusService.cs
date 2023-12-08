using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Restaurant.Core.Services;
using System.Text;

namespace Restaurant.Infra.MessageBus
{
    public class MessageBusService : IMessageBusService
    {
        private readonly ConnectionFactory _factory;
        public MessageBusService(IConfiguration configuration)
        {
            _factory = new ConnectionFactory
            {
                HostName = configuration["MessageBus:HostName"]
            };
        }
        public void Publish(string queue, object message)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var payload = JsonConvert.SerializeObject(message);
                    var body = Encoding.UTF8.GetBytes(payload);
                    channel.QueueDeclare(queue: queue, durable: true, exclusive: false, autoDelete: false, arguments: null);
                    channel.BasicPublish(exchange: "", routingKey: queue, basicProperties: null, body: body);
                }
            }
        }
    }
}
