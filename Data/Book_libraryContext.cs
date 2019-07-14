using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Book_library.Models
{
    public class Book_libraryContext : DbContext
    {
        public Book_libraryContext (DbContextOptions<Book_libraryContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Book { get; set; }
    }
}
