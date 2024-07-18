using Microsoft.EntityFrameworkCore;
using Ordering.Infastructure.Data;

namespace ESourcing.Order.Extensions
{
    public static class MigrationManager
    {
        public static IHost MigrateAndSeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var orderContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>();

                    if (orderContext.Database.ProviderName != "Microsoft.EntityFrameworkCore.InMemory")
                    {
                        orderContext.Database.Migrate();
                    }

                    OrderContextSeed.SeedAsync(orderContext).Wait();
                }
                catch (Exception)
                {

                    throw;
                }
            }

            return host;
        }
    }
}
