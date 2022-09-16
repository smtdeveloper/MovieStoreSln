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
          new Director { Name = "Chad", LastName = "Stahelski", FilmsDirected = "John Wick", IsActive = true },
          new Director { Name = "Kyle", LastName = "Balda", FilmsDirected = "Minyonlar 2: Gru'nun Yükselişi", IsActive = true },
          new Director { Name = "Jonathan", LastName = "Del Val", FilmsDirected = "Minyonlar 2: Gru'nun Yükselişi", IsActive = true }
          );
                context.SaveChanges();

                context.Actors.AddRange(
                  new Actor { Name = "Keanu", LastName = "Reeves", PlayedMovies = "John Wick", IsAvtive = true },
                  new Actor { Name = "Chad", LastName = "Stahelski", PlayedMovies = "John Wick", IsAvtive = true },
                  new Actor { Name = "Bridget", LastName = "Moynahan", PlayedMovies = "John Wick", IsAvtive = true },
                  new Actor { Name = "lan", LastName = "McShane", PlayedMovies = "John Wick", IsAvtive = true },
                  new Actor { Name = "Steve", LastName = "Carell", PlayedMovies = "Minyonlar 2: Gru'nun Yükselişi", IsAvtive = true },
                  new Actor { Name = "Alan", LastName = "Arkin", PlayedMovies = "Minyonlar 2: Gru'nun Yükselişi", IsAvtive = true }
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
             IsActive = true

         },
         new Customer
         {
             Name = "Eslem",
             LastName = "AKCA",
             Email = "eslem@gmail.com",
             Password = "123456",
             IsActive = true

         },
         new Customer
         {
             Name = "Burak",
             LastName = "DemirKıran",
             Email = "burak@gmail.com",
             Password = "123456",
             IsActive = true

         });


                context.SaveChanges();

                context.Orders.AddRange(
                  new Order { CustomerId = 1 , MovieId = 1, purchasedTime = new DateTime(2022, 07, 06) , IsActive = true },
                  new Order { CustomerId = 2 , MovieId = 1, purchasedTime = new DateTime(2022, 12, 05) , IsActive = true },
                  new Order { CustomerId = 3 , MovieId = 2, purchasedTime = new DateTime(2022, 08, 25) , IsActive = true }
                  );

                context.SaveChanges();

            }
        }

    }
}
