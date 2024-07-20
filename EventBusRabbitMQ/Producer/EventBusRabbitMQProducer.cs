using EventBusRabbitMQ.Events;
using EventBusRabbitMQ.Events.Interfaces;
using Microsoft.Extensions.Logging;
using Polly;
using Polly.Retry;
using RabbitMQ.Client;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace EventBusRabbitMQ.Producer
{
    public class EventBusRabbitMQProducer: IEventBusRabbitMQProducer
    {
        private readonly IRabbitMQPersistentConnection _rabbitMQPersistentConnection;
        private readonly ILogger<EventBusRabbitMQProducer> _logger;
        private readonly int _retryCount;

        public EventBusRabbitMQProducer(IRabbitMQPersistentConnection rabbitMQPersistentConnection, ILogger<EventBusRabbitMQProducer> logger, int retryCount)
        {
            _rabbitMQPersistentConnection = rabbitMQPersistentConnection;
            _logger = logger;
            _retryCount = retryCount;
        }


        public void Publish(string queueName, IEvent @event)
        {
            if (!_rabbitMQPersistentConnection.IsConnected)
            {
                _rabbitMQPersistentConnection.TryConnect();
            }

            var policy = RetryPolicy.Handle<BrokerUnreachableException>()
            .Or<SocketException>()
            .WaitAndRetry(_retryCount, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (ex, time) =>
            {
                _logger.LogWarning(ex, "Could not publish event: {EventId} after {Timeout}s ({ExceptionMessage})", @event.RequestId, $"{time.TotalSeconds:n1}", ex.Message);
            });

            using (var channel = _rabbitMQPersistentConnection.CreateModel())
            {
                channel.QueueDeclare(queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
                var message = JsonSerializer.Serialize((object)@event);
                var body = Encoding.UTF8.GetBytes(message);

                policy.Execute(() =>
                {
                    IBasicProperties properties = channel.CreateBasicProperties();
                    properties.Persistent = true;
                    properties.DeliveryMode = 2;

                    channel.ConfirmSelect();

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: queueName,
                        mandatory: true,
                        basicProperties: properties,
                        body: body);

                    channel.WaitForConfirmsOrDie();

                    channel.BasicAcks += (sender, eventArgs) =>
                    {
                        Console.WriteLine("Sent RabbitMQ");
                        // implement ack handle
                    };
                });
            }
        }
    }
}
