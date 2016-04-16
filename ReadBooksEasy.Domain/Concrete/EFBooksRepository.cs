using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadBooksEasy.Domain.Abstract;
using ReadBooksEasy.Domain.Entities;

namespace ReadBooksEasy.Domain.Concrete
{
    public class EFBooksRepository:IBookRepository
    {
        private DefaultConnection context = new DefaultConnection();
        public IQueryable<Book> Books {
            get { return context.Books; }
        }
        public IQueryable<Bookmark> Bookmark
        {
            get { return context.Bookmark; }
        }
        protected void CloseConnection() {
            context.Dispose();
        }
        public IQueryable<UsersBook> UserBook
        {
            get { return context.UserBook; }
        }
        public void SaveBook(int UserId, Book book) {
            var NameOfBook = context.Books.FirstOrDefault(b=>b.nameOfBook.Equals(book.nameOfBook));
            UsersBook newRecord = new UsersBook();
            if (NameOfBook==null){
                context.Books.Add(book);
                context.SaveChanges();
                var BookInDb = context.Books.FirstOrDefault(b=>b.nameOfBook==book.nameOfBook);
                newRecord.idBooks = BookInDb.idBook;
                newRecord.Book = BookInDb;
                newRecord.IdUsers = UserId;
                newRecord.usingFieldRating = false;
                newRecord.ratingForBook = null;
                newRecord.userBooksBookFk = BookInDb.idBook;
                context.UserBook.Add(newRecord);
                context.SaveChanges();
            }
            
        }
        public void AddBookToPlaylistUser(int UserId, int BookId)
        {
       //     var NameOfBook = context.Books.FirstOrDefault(b => b.idBook==BookId);
            UsersBook newRecord = new UsersBook();
                var BookInDb = context.Books.FirstOrDefault(b => b.idBook == BookId);
                newRecord.idBooks = BookId;
                newRecord.Book = BookInDb;
                newRecord.IdUsers = UserId;
                newRecord.usingFieldRating = false;
                newRecord.ratingForBook = null;
                newRecord.userBooksBookFk = BookId;
                try
                {
                    context.UserBook.Add(newRecord);
                    context.SaveChanges();
                }
                catch (Exception e) {
                    Console.WriteLine("{0} Exception caught.", e);
                }
        }
        public void RemoveBookFromPlaylistUser(int UserId, int BookId)
        {
            var NameOfBook = context.Books.FirstOrDefault(b => b.idBook == BookId);
            //UsersBook recToRemove = new UsersBook();
            UsersBook recToRemove = context.UserBook.FirstOrDefault(ub => ub.idBooks == BookId && ub.IdUsers == UserId);
           /* recToRemove.idBooks = BookId;
            recToRemove.IdUsers = UserId;
            recToRemove.userBooksBookFk = BookId;
            recToRemove.Book = NameOfBook; */
            try
            {
                context.UserBook.Remove(recToRemove);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("{0} Exception caught.", e);
            }
        }

        public Book RemoveBook(int BookId) {
            return context.Books.FirstOrDefault();
        }
    }
}
