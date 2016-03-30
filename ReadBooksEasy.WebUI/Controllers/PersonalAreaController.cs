﻿using System;
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
            repo.SaveBook(1,book);
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

    }
}