using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Book_library.Models;

namespace Book_library.Models
{
    public class Book_libraryContext : DbContext
    {
        public Book_libraryContext (DbContextOptions<Book_libraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }

        public DbSet<Book_library.Models.User> User { get; set; }

        public DbSet<Book_library.Models.UserLogin> UserLogin { get; set; }
    }
}
