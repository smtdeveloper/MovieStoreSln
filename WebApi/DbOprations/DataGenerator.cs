using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.DbOprations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(

                    new Movie
                    {
                        // ID = 1,
                        Title = "Ayla",
                        Year = "2015",
                        Genre = "Kore",
                        Director = "Murat ekşi",
                        Players = "Ayla, Süleyman, Musto",
                        Price = 10,
                        IsActive = true
                        
                    },

                    new Movie
                    {
                        // ID = 2,
                        Title = "Thor 2",
                        Year = "2014",
                        Genre = "Marvel",
                        Director = "Mack",
                        Players = "Thor, Justin",
                        Price = 25,
                        IsActive = true

                    }

                    );

                context.SaveChanges();

            }
        }

    }
}
