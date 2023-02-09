using evaluacionClaro.Services;
using System.Net.Http;

using Microsoft.AspNetCore.Mvc;
using evaluacionClaro.Models;

namespace evaluacionClaro.Controllers
{
    public class ContactosController : Controller
    {
        private IContactosService _service;

        public ContactosController(IContactosService service)
        {
            _service = service;
        }

        
        public IActionResult Index()
        {
            var Contactos = _service.GetAllContactos();
            return View(Contactos);
        }

        
        public IActionResult About(int id)
        {
            var bookDetails = _service.GetContactosById(id);
            return View(bookDetails);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        public async Task<IActionResult> Create(Contactos contacto)
        {
            _service.Insert(contacto);
           return RedirectToAction("Index", "Contactos");
        }

        public IActionResult Update(int id)
        {
            var book = _service.GetContactosById(id);
            return View(book);
        }

        public IActionResult UpdateContacto(Contactos contacto)
        {
            if(_service.Update(contacto, contacto.id)){
                return RedirectToAction("Index", "Contactos");
            }
            else{
                return BadRequest();
            }
            
        }

        public IActionResult Delete(int id)
        {
            var contacto = _service.GetContactosById(id);
            return View(contacto);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id, Contactos contacto)
        {
            if(contacto.id == id)
            {
                _service.Delete(id);
                return RedirectToAction("Index", "Contactos");
            }
            else
            {
                return BadRequest();
            }
            
        }


    }
}

