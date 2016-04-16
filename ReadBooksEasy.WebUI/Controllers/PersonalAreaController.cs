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
        /*private IUserBookRepository repoUserBook;
        public PersonalAreaController(IUserBookRepository userbookRepository)
        {
            this.repoUserBook = userbookRepository;
        }*/
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
                var sequence = repo.UserBook.Where(u => u.IdUsers == IdOfUser).Select(b => b.Book).ToList();
                sequence.ForEach(b => b.fileOfBook = null);
                //IList<Book> UsersBook = new List<Book>();
                //UsersBook.Add(repo.Books.FirstOrDefault());
                ViewBag.sequence = sequence;
                return View(sequence);
            }
            else
            {
                var sequence = repo.Books.ToList();
                sequence.ForEach(b => b.fileOfBook = null);
                ViewBag.sequence = sequence;
                return View(sequence);
            }
        }

        public JsonResult IndexJson(int? Own)
        {
            var IdOfUser = WebSecurity.GetUserId(User.Identity.Name);
            ViewBag.idU = IdOfUser;
            ViewBag.Name = User.Identity.Name;
            ViewBag.Message = "Authorize area.";
            Book book = new Book() { nameOfBook = "new" };
            //repo.SaveBook(1,book);
            if (Own == 1)
            {
                var sequence = repo.UserBook.Where(u => u.IdUsers == IdOfUser).Select(b => b.Book).ToList();
                sequence.ForEach(b => b.fileOfBook = null);
                //IList<Book> UsersBook = new List<Book>();
                //UsersBook.Add(repo.Books.FirstOrDefault());
                return Json(sequence, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var sequence= repo.Books.ToList();
                sequence.ForEach(b => b.fileOfBook = null);
                return Json(sequence, JsonRequestBehavior.AllowGet);
            }
        }

        public void AddBookToUserPlaylist(int idOfBook)
        {
            var IdOfUser = WebSecurity.GetUserId(User.Identity.Name);
            Book book = new Book() { nameOfBook = "new" };

            repo.AddBookToPlaylistUser(IdOfUser,idOfBook);
        }

        public void RemoveBookFromUserPlaylist(int idOfBook)
        {
            var IdOfUser = WebSecurity.GetUserId(User.Identity.Name);
            Book book = new Book() { nameOfBook = "new" };
            repo.RemoveBookFromPlaylistUser(IdOfUser, idOfBook);
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

        public ActionResult ShowPdf(string idOfBook) {
            int id = Int32.Parse(idOfBook);
            Book bookFromDb = repo.Books.FirstOrDefault(b => b.idBook==id);
            return File(bookFromDb.fileOfBook, "application/pdf");
        }

    }
}
