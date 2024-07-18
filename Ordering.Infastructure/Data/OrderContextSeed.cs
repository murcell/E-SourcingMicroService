﻿using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Infastructure.Data
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderDbContext orderDbContext)
        {
            if (!orderDbContext.Orders.Any())
            {
                orderDbContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderDbContext.SaveChangesAsync();
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>()
            {
               new Order()
               {
                   AuctionId = Guid.NewGuid().ToString(),
                   ProductId = Guid.NewGuid().ToString(),
                   SellerUserName = "test@test.com",
                   UnitPrice = 10,
                   TotalPrice = 1000,
                   CreatedAt = DateTime.UtcNow
               },
               new Order()
               {
                   AuctionId = Guid.NewGuid().ToString(),
                   ProductId = Guid.NewGuid().ToString(),
                   SellerUserName = "test1@test.com",
                   UnitPrice = 10,
                   TotalPrice = 1000,
                   CreatedAt = DateTime.UtcNow
               },
               new Order()
               {
                   AuctionId = Guid.NewGuid().ToString(),
                   ProductId = Guid.NewGuid().ToString(),
                   SellerUserName = "test2@test.com",
                   UnitPrice = 10,
                   TotalPrice = 1000,
                   CreatedAt = DateTime.UtcNow
               }
            };
        }
    }
}
