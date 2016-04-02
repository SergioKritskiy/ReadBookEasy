using ReadBooksEasy.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadBooksEasy.Domain.Abstract
{
     public interface IUserBookRepository
    {
         IQueryable<UsersBook> UserBook { get; }
    }
}
