using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace WebApi.Data.BookStore.CRUD
{


    public class DataGenerator
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BookStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()))
            {
                // Look for any book.
                if (context.Books.Any()) { return;   /* Data was already seeded */                }

                context.Books.AddRange(
                                        new Book {/* Id=1, */ Title = "Lean Startup", GenreId = WebApi.eBookGenre.PersonalGrowth /* personal growth */, PageCount = 200, PublishDate = new DateTime(2001, 06, 12) },
                                        new Book {/* Id=2, */ Title = "Herland", GenreId = WebApi.eBookGenre.ScienceFiction /* science Fiction */, PageCount = 250, PublishDate = new DateTime(2010, 05, 23) },
                                        new Book {/* Id=3, */ Title = "Dune", GenreId = WebApi.eBookGenre.ScienceFiction /* science Fiction */, PageCount = 540, PublishDate = new DateTime(2001, 12, 21) }
                                        );

                context.SaveChanges();
            }
        }
    }



}