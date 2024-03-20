using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using iceOne_Cloud.Data;
using System;
using System.Linq;

namespace iceOne_Cloud.Models
{
    public class seedData
    {
        public static void Initialize(IServiceProvider serviceProvider) 
        {
            using (var context = new iceOne_CloudContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<iceOne_CloudContext>>())) 
            {
                if (context.bnbDB.Any())
                {
                    return;   // DB has been seeded
                }
                context.bnbDB.AddRange(
                    new bnbDB
                    {
                       
                        Name = "The Swallows",
                        Address="25 pickUr lane",
                        contactEmail="pickUr@gmail.com",
                        Price=500.99,
                    }

                    ); 
                context.SaveChanges();
            }
        }     
    }
}
