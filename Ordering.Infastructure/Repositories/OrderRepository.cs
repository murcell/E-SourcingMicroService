using Microsoft.EntityFrameworkCore;
using Ordering.Domain.Entities;
using Ordering.Domain.Repositories;
using Ordering.Infastructure.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Repositories
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext):base(dbContext)
        {
            
        }
        public async Task<IEnumerable<Order>> GetOrdersBySellerUserName(string userName)
        {
            var orderList = await _dbContext.Orders
                      .Where(o => o.SellerUserName == userName)
                      .ToListAsync();

            return orderList;
        }
    }
}
