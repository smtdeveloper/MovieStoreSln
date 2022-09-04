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
                        GenreID = 1,
                        Title = "John Wick",
                        Year = "2014",
                        Director = "Chad Stahelski",
                        Players = "Keanu Reeves, Chad Stahelski, Bridget Moynahan, lan McShane ",
                        Price = 50,
                        IsActive = true
                        
                    },

                    new Movie
                    {
                        // ID = 2,
                        GenreID = 3,
                        Title = "Minyonlar 2: Gru'nun Yükselişi",
                        Year = "2022",
                        Director = "Kyle Balda, Brad Ableson, Jonathan Del Val",
                        Players = " Steve Carell, Alan Arkin, Taraji P. Henson",
                        Price = 85,
                        IsActive = true

                    }
                    );

                context.Genres.AddRange(
                   new Genre
                   {
                       Name = "Aksiyon "
                   },
                   new Genre
                   {
                       Name = "Bilimkurgu "
                   },
                   new Genre
                   {
                       Name = "Animasyon"
                   }
               );

                context.SaveChanges();

            }
        }

    }
}
