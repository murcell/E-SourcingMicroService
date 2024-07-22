using ESourcing.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esourcing.Infastructure.Data
{
    public  class WebAppContextSeed
    {
        public static async Task SeedAsync(WebAppContext webAppContext)
        {
           // int retryForAvailability = retry.Value;

            try
            {
                webAppContext.Database.Migrate();
                if (!webAppContext.AppUsers.Any())
                {
                    webAppContext.AppUsers.AddRange(GetPreconfiguredOrders());
                    await webAppContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {
                //if (retryForAvailability < 50)
                //{
                //    retryForAvailability++;
                //    var log = loggerFactory.CreateLogger<WebAppContextSeed>();
                //    log.LogError(ex.Message);
                //    Thread.Sleep(2000);
                //    await SeedAsync(webAppContext, loggerFactory, retryForAvailability);
                //}
            }
        }

        private static IEnumerable<AppUser> GetPreconfiguredOrders()
        {
            return new List<AppUser>()
            {
                new AppUser
                {
                    FirstName ="Orhan",
                    LastName = "Veli",
                    IsSeller = true,
                    IsBuyer = false,
                    Email="orhan@veli.com"
                },
                new AppUser
                {
                    FirstName ="Özdemir",
                    LastName = "Arun",
                    IsSeller = false,
                    IsBuyer = true,
                    Email="asaf@ozdemir.com"
                }
            };
        }
    }
}
