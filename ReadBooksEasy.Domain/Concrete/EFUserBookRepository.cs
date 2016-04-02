using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReadBooksEasy.Domain.Abstract;
using ReadBooksEasy.Domain.Entities;
namespace ReadBooksEasy.Domain.Concrete
{
    public class EFUserBookRepository:IUserBookRepository
    {
        private DefaultConnection context = new DefaultConnection();
        public IQueryable<UsersBook> UserBook
        {
            get { return context.UserBook; }
        }

    }
}
