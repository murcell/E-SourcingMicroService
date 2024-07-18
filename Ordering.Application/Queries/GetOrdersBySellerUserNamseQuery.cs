using MediatR;
using Ordering.Application.Responses;

namespace Ordering.Application.Queries
{
    public class GetOrdersBySellerUserNamseQuery :IRequest<IEnumerable<OrderResponse>>
    {
        public string UserName { get; set; }
        public GetOrdersBySellerUserNamseQuery(string userName)
        {
            UserName = userName;
        }



    }
}
