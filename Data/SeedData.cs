using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MoviesApp.Models;

namespace MoviesApp.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            Console.WriteLine("Seeding Database");
            using (var context = new MoviesContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MoviesContext>>()))
            {
                //movies.
                if (!context.Movies.Any())
                {
                    context.Movies.AddRange(
                        new Movie
                        {
                            Title = "When Harry Met Sally",
                            ReleaseDate = DateTime.Parse("1989-2-12"),
                            Genre = "Romantic Comedy",
                            Price = 7.99M
                        },


                        new Movie
                        {
                            Title = "Ghostbusters ",
                            ReleaseDate = DateTime.Parse("1984-3-13"),
                            Genre = "Comedy",
                            Price = 8.99M
                        },

                        new Movie
                        {
                            Title = "Ghostbusters 2",
                            ReleaseDate = DateTime.Parse("1986-2-23"),
                            Genre = "Comedy",
                            Price = 9.99M
                        },

                        new Movie
                        {
                            Title = "Rio Bravo",
                            ReleaseDate = DateTime.Parse("1959-4-15"),
                            Genre = "Western",
                            Price = 3.99M
                        }
                    );

                    context.SaveChanges();
                }

                //actors.
                if (!context.Actors.Any())
                {
                    context.Actors.AddRange(
                        new Actor
                        {
                            Name = "Robert",
                            Surname = "Downey Jr.",
                            DateOfBirth = new DateTime(1965, 4, 4)
                        },
                        new Actor
                        {
                            Name = "Chris",
                            Surname = "Evans",
                            DateOfBirth = new DateTime(1981, 6, 13)
                        },
                        new Actor
                        {
                            Name = "Scarlett",
                            Surname = "Johansson",
                            DateOfBirth = new DateTime(1984, 11, 22)
                        },
                        new Actor
                        {
                            Name = "Chris",
                            Surname = "Hemsworth",
                            DateOfBirth = new DateTime(1983, 8, 11)
                        },
                        new Actor
                        {
                            Name = "Mark",
                            Surname = "Ruffalo",
                            DateOfBirth = new DateTime(1967, 11, 22)
                        }
                    );

                    context.SaveChanges();
                }               
            }
        }
    }
}