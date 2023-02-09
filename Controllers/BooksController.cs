using evaluacionClaro.Services;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;

namespace evaluacionClaro.Controllers
{
    public class BooksController : Controller
    {
        private IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        
        public IActionResult Index()
        {
            var books = _service.GetAllBooks();
            return View(books);
        }

        
        public IActionResult About(int bookid)
        {
            var bookDetails = _service.GetBookById(bookid);
            return View(bookDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        public async Task<IActionResult> Create(Books book)
        {
            _service.Insert(book);
           return RedirectToAction("Index", "Books");
        }

        public IActionResult Update(int bookid)
        {
            var book = _service.GetBookById(bookid);
            return View(book);
        }

        public IActionResult UpdateBook(Books book)
        {
            if(_service.Update(book, book.id)){
                return RedirectToAction("Index", "Books");
            }
            else{
                return BadRequest();
            }
            
        }

        public IActionResult Delete(int bookid)
        {
            var book = _service.GetBookById(bookid);
            return View(book);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Books book)
        {
            if(book.id == id)
            {
                _service.Delete(id);
                return RedirectToAction("Index", "Books");
            }
            else
            {
                return BadRequest();
            }
            
        }


    }
}

