using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadBooksEasy.Domain.Entities;
namespace ReadBooksEasy.Domain.Abstract
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
        void SaveBook(int UserId,Book book);
        Book RemoveBook(int BookId);
    }
}
