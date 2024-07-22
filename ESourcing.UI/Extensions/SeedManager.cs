using Esourcing.Infastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ESourcing.UI.Extensions
{
    public static class SeedManager
    {
        public static IHost MigrateAndSeedDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var webAppContext = scope.ServiceProvider.GetRequiredService<WebAppContext>();
                    
                    webAppContext.Database.Migrate();

                    WebAppContextSeed.SeedAsync(webAppContext).Wait();
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
