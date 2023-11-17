using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcProduct.Data;
using System;
using System.Linq;

namespace MVCProduct.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcProductContext(serviceProvider.GetRequiredService<DbContextOptions<MvcProductContext>>()))
        {
            // Look for any products.
            if (context.Product.Any())
            {
                return;   // DB has been seeded
            }
            context.Product.AddRange(
                new Product
                {
                    Title = "FlavorBurst",
                    Price = 6.99M,
                    Rating = "Very Good"
                },
                new Product
                {
                    Title = "FreshBite",
                    Price = 14.99M,
                    Rating = "Good"
                },
                new Product
                {
                    Title = "SpiceMaster",
                    Price = 12.99M,
                    Rating = "Normal"
                },
                new Product
                {
                    Title = "CrunchDelight",
                    Price = 4.99M,
                    Rating = "Bad"
                },
                new Product
                {
                    Title = "When Harry Met Sally",
                    Price = 7.99M,
                    Rating = "Normal"
                },
                new Product
                {
                    Title = "BrewMasters",
                    Price = 15.99M,
                    Rating = "Good"
                }
            );
            context.SaveChanges();
        }
    }
}