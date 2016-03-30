using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using ReadBooksEasy.Domain.Entities;

namespace ReadBooksEasy.Domain.Concrete
{
    public class DefaultConnection:DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<UsersBook> UserBook { get; set; }
        public DbSet<Bookmark> Bookmark { get; set; }
    }
}
