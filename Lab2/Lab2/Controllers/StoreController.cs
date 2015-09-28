using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lab2.Repositories;
using Lab2.ViewModels;

namespace Lab2.Controllers
{
    public class StoreController : Controller
    {
        // GET: Store
        public ActionResult Index()
        {
            // Get book data from repo
            var bookRepository = BookRepository.GetAllBookData();

            // Instantiate the viewmodel
            var bookViewModel = new BookViewModel
            {
                BookData = bookRepository
            };

            // Send viewmodel into the view
            return View("Index", bookViewModel);
        }

        // POST: Store
        [HttpPost]
        public ActionResult Index(BookViewModel bookViewModel)
        {
            // Get book data from repo based on selected book in the view
            var book = BookRepository.GetBookById(bookViewModel.Id);

            // TODO: Get selected ID from view and display book info

            // Send viewmodel into the view
            return View(bookViewModel);
        }

        // GET: Cart
        public ActionResult Cart()
        {
            return View();
        }
    }
}