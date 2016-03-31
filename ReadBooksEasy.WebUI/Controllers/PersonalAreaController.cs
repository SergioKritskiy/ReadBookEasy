using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReadBooksEasy.Domain.Abstract;
using ReadBooksEasy.Domain.Entities;
using System.Web.Security;
using WebMatrix.WebData;
using ReadBooksEasy.WebUI.Filters;
namespace ReadBooksEasy.WebUI.Controllers
{
    [Authorize]
    [InitializeSimpleMembership]
    public class PersonalAreaController : Controller
    {
        //
        // GET: /PersonalArea/
        private IBookRepository repo;
        public PersonalAreaController(IBookRepository bookRepository) {
            this.repo = bookRepository;        
        }
        public ActionResult Index(int? Own)
        {
            var IdOfUser = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.idU = IdOfUser;
            ViewBag.Name = User.Identity.Name;
            ViewBag.Message = "Authorize area.";
            Book book = new Book(){nameOfBook="new"};
            //repo.SaveBook(1,book);
            if (Own == 1)
            {
                IList<Book> UsersBook = new List<Book>();
                UsersBook.Add(repo.Books.FirstOrDefault());
                return View(UsersBook);
            }
            else
            {
                return View(repo.Books);
            }
        }

        public ActionResult AddBook() {
            return View();
        }
        [HttpPost]
        public ActionResult AddBook(Book book, HttpPostedFileBase bookFile)
        {
            var IdOfUser = WebSecurity.GetUserId(User.Identity.Name);
            if (bookFile != null) {
                book.fileOfBook = new byte[bookFile.ContentLength];
                bookFile.InputStream.Read(book.fileOfBook,0,bookFile.ContentLength);
                repo.SaveBook(IdOfUser,book);
            }
            return RedirectToAction("Index");
        }

        public ActionResult ShowPdf(int idOfBook) {
            Book bookFromDb = repo.Books.FirstOrDefault(b => b.idBook==idOfBook);
            //bookFromDb.
            return File(bookFromDb.fileOfBook, "application/pdf");
        }

    }
}
