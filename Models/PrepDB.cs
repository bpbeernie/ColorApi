using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace ColourAPI.Models
{
    public static class PrepDB
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<ColorContext>());
            }



        }

        public static void SeedData(ColorContext context)
        {
            System.Console.WriteLine("Applying Migrations...");

            context.Database.Migrate();
            if (!context.ColorItems.Any())
            {
                Console.WriteLine("Adding data = seeding...");
                context.ColorItems.AddRange(
                    new Color() { ColorName = "Red"},
                    new Color() { ColorName = "Orange" },
                    new Color() { ColorName = "Red" },
                    new Color() { ColorName = "Yellow" },
                    new Color() { ColorName = "Green" },
                    new Color() { ColorName = "Blue" }
                );
            } 
            else
            {
                Console.WriteLine("Already have data");
            }

        }
    }
}
