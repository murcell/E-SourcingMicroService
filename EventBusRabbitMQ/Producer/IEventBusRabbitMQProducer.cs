using EventBusRabbitMQ.Events.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBusRabbitMQ.Producer
{
    public interface IEventBusRabbitMQProducer
    {
        void Publish(string queueName, IEvent @event);
    }
}
