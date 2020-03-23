using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Zola.Web.Models;

namespace Zola.Web.Controllers
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new PharmaDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<PharmaDbContext>>()))
            {
                // Look for any board games.
                if (context.Medicines.Any())
                {
                    return;   // Data was already seeded
                }

                context.Medicines.AddRange(
                    new Medicines
                    {
                        Id = 1,
                        Name = "Candy Land",
                        ManufacturingDate =DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                       
                    },
                    new Medicines
                    {
                        Id = 2,
                        Name = "Candy Land",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                    },
                    new Medicines
                    {
                        Id = 3,
                        Name = "Candy Land",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                    },
                    new Medicines
                    {
                        Id = 4,
                        Name = "Candy Land",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                    },
                    new Medicines
                    {
                        Id = 5,
                        Name = "Candy Land",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                    },
                    new Medicines
                    {
                        Id = 6,
                        Name = "Candy Land",
                        ManufacturingDate = DateTime.Now,
                        ExpiryDate = DateTime.Now.AddYears(1)
                    });

                context.SaveChanges();
            }
        }
    }
}