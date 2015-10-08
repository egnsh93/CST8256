using System.Linq;
using System.Web.Mvc;
using Lab2.Models;
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

            // Remove already added books from the dropdown list
            foreach (var order in OrderRepository.RetrieveAllOrders())
            {
                bookRepository.Remove(bookRepository.Single(b => b.Id == order.Book.Id));
            }

            // Instantiate the viewmodel
            var bookViewModel = new BookViewModel
            {
                BookData = bookRepository
            };

            return View("Index", bookViewModel);
        }

        // POST: Store
        [HttpPost]
        public ActionResult Index(BookViewModel bookViewModel)
        {
            // Repopulate Book Collection on post
            bookViewModel.BookData = BookRepository.GetAllBookData();

            // Get book data from repo based on selected book in the view
            var book = BookRepository.GetBookById(bookViewModel.BookId);

            // Set the view model properties for the current book
            bookViewModel.Title = book.Title;
            bookViewModel.Description = book.Description;
            bookViewModel.Price = book.Price;

            // Store the bookViewModel in the session
            Session["BookData"] = bookViewModel;

            return View("Index", bookViewModel);
        }

        // GET: Cart
        public ActionResult Cart()
        {
            var cartViewModel = new CartViewModel
            {
                BookOrders = OrderRepository.RetrieveAllOrders()
            };

            return View("Cart", cartViewModel);
        }

        // POST: Add to Cart
        [HttpPost]
        public ActionResult Cart(CartViewModel cartViewModel)
        {
            // Get the book session data
            var bookViewModel = (BookViewModel) Session["BookData"];

            // Check for valid number of copies
            if (cartViewModel.NumCopies < 1)
                ModelState.AddModelError("NumCopies", "Quantity must be greater than zero");


            if (!ModelState.IsValid)
                return View("Index", bookViewModel);

            // Create a new book order with the selected book
            var order = new Order(BookRepository.GetBookById(bookViewModel.BookId), cartViewModel.NumCopies);

            // Save the order to the repository
            OrderRepository.SaveOrder(order);

            cartViewModel.BookOrders = OrderRepository.RetrieveAllOrders();

            return RedirectToAction("Cart", cartViewModel);
        }

        public ActionResult EmptyCart()
        {
            // Clear the session and order repo (cart)
            Session["BookData"] = null;
            OrderRepository.RemoveAllorders();

            return RedirectToAction("Cart");
        }
    }
}