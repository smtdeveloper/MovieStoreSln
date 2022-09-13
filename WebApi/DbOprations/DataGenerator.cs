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

                context.Directors.AddRange(
          new Director { Name = "Chad", LastName = "Stahelski", FilmsDirected = "John Wick" , IsActive = true },
          new Director { Name = "Kyle", LastName = "Balda", FilmsDirected = "Minyonlar 2: Gru'nun Yükselişi" , IsActive = true },
          new Director { Name = "Jonathan", LastName = "Del Val", FilmsDirected = "Minyonlar 2: Gru'nun Yükselişi" , IsActive = true }
          );
                context.SaveChanges();

                context.Actors.AddRange(
                  new Actor { Name = "Keanu", LastName = "Reeves" },
                  new Actor { Name = "Chad", LastName = "Stahelski" },
                  new Actor { Name = "Bridget", LastName = "Moynahan" },
                  new Actor { Name = "lan", LastName = "McShane" },
                  new Actor { Name = "Steve", LastName = "Carell" },
                  new Actor { Name = "Alan", LastName = "Arkin" }
                  );
                context.SaveChanges();

                context.Movies.AddRange(

                    new Movie
                    {
                        // ID = 1,
                        GenreID = 1,
                        Title = "John Wick",
                        Year = "2014",
                        Director = "Chad Stahelski",
                        Actors = "Keanu Reeves, Chad Stahelski, Bridget Moynahan, lan McShane ",
                        Price = 50,
                        IsActive = true
                        
                    },

                    new Movie
                    {
                        // ID = 2,
                        GenreID = 3,
                        Title = "Minyonlar 2: Gru'nun Yükselişi",
                        Year = "2022",
                        Director = "Kyle Balda, Jonathan Del Val",
                        Actors = " Steve Carell, Alan Arkin",
                        Price = 45,
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

                context.Customers.AddRange(
         new Customer
         {
             Name = "Samet",
             LastName = "AKCA",
             Email = "SMT@gmail.com",
             Password = "123456",
             
         },
         new Customer
         {
             Name = "Eslem",
             LastName = "AKCA",
             Email = "eslem@gmail.com",
             Password = "123456",
             
         },
         new Customer
         {
             Name = "Burak",
             LastName = "DemirKıran",
             Email = "burak@gmail.com",
             Password = "123456",
            
         });


                context.SaveChanges();

            }
        }

    }
}
