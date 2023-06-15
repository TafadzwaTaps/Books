using Books.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Books.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public static List<Book> GetBooks()
        {
            List<Book> books = new List<Book>();
            Book book1 = new Book(1, "The Great Escape", "F. Scott ", 150, new List<string> { "Fiction", "Classic" });
            Book book2 = new Book(2, "How To Kill A Hummingbird", "Harper Lee", 325, new List<string> { "Fiction", "Classic" });
            Book book3 = new Book(3, "Harry Potter and the deathly hallows", "J.K. Rowling", 336, new List<string> { "Fiction", "Fantasy" });

            books.Add(book1);
            books.Add(book2);
            books.Add(book3);

            return books;
        }

        public IActionResult Info(int id)
        {
            // Retrieve the book with the specified id from the list of books
            Book book = GetBooks().FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound(); // Return a 404 Not Found error if the book is not found
            }

            return View(book); // Return the book object to the Info view
        }

        public ActionResult List()
        {
            List<Book> books = GetBooks();
            return View(books);
        }


        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book); // Return the view with validation errors if the book data is not valid
            }

            // Add the book to the list of books
            List<Book> books = GetBooks();
            books.Add(book);

            return RedirectToAction("List"); // Redirect the user to the list of books
        }

        public IActionResult Delete(int id)
        {
            List<Book> books = GetBooks();
            Book book = books.FirstOrDefault(b => b.Id == id);

            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);

            return View(book);
        }

        [HttpPost]
        public IActionResult Update(Book book)
        {
            if (!ModelState.IsValid)
            {
                return View(book);
            }

            List<Book> books = GetBooks();
            Book existingBook = books.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook == null)
            {
                return NotFound();
            }

            existingBook.Title = book.Title;
            existingBook.Author = book.Author;
            existingBook.NumberOfPages = book.NumberOfPages;
            existingBook.Categories = book.Categories;

            return RedirectToAction("List");
        }

        [HttpPost]
        public IActionResult Save(EditBookViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", viewModel);
            }

            var book = GetBooks().FirstOrDefault(b => b.Id == viewModel.Id);

            if (book == null)
            {
                return NotFound();
            }

            book.Title = viewModel.Title;
            book.Author = viewModel.Author;
            book.NumberOfPages = viewModel.NumberOfPages;
            book.Categories = viewModel.Categories;

            return View(book);
        }
    }
}
