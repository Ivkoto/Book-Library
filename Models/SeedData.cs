using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Book_library.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new Book_libraryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<Book_libraryContext>>()))
            {
                if (context.Book.Any())
                {
                    return;
                }

                context.Book.AddRange(
                    new Book
                    {
                        Title = "test title",
                        Author = "Test Author",
                        Genre = "test genre",
                        SharedWith = "non",
                        Pages = 150
                    },
                    new Book
                    {
                        Title = "test2 title",
                        Author = "Test2 Author",
                        Genre = "test2 genre",
                        SharedWith = "someone",
                        Pages = 200
                    }
                );

                context.SaveChanges();
            }
        }
    }
}
