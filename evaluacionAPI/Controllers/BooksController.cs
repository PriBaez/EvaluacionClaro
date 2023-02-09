using evaluacionAPI.Models;
using evaluacionAPI.Repository;
using  evaluacionAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace evaluacionAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private IBooksService _service;

        public BooksController(IBooksService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Books = _service.GetAllBooks();
            
            if (Books != null)
            { return Ok(Books); }
            else
            { return NoContent(); }

        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            
            var book = _service.GetBookById(id);
            if (book != null)
            { return Ok(book); }
            else
            { return NoContent(); }
            
        }

        [HttpPost]
        public IActionResult Create(Books book)
        {
            if(book == null) return BadRequest();
            bool response =  _service.Insert(book);
            
            if(response)
            { 
                return Created("Created", true);
            } else
            {
                return BadRequest("Failed to create Book. Please, contact the administrator.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(Books book, int id)
        {   
            if (id != book.id) return BadRequest("ID mismatch, please fix it and try again;");

            bool response = _service.Update(book);

            if(response)
            { return Created("Created", true); } 
            else 
            { return BadRequest("Something went wrong while updating the info. Try Again."); }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Books book = _service.GetBookById(id);
            bool response = _service.Delete(book);
           if(response)
            {  return Ok(); } 
            else
            {  return BadRequest(); }
            
        }


    }
}

