using AutoMapper;
using ESourcing.Sourcing.Entities;
using EventBusRabbitMQ.Events;

namespace ESourcing.Sourcing.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            CreateMap<OrderCreateEvent, Bid>().ReverseMap();
        }
    }
}
