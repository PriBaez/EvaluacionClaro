using FakeApi.Models;
using FakeApi.Repository;
using  FakeApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FakeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactosController : Controller
    {
        private IContactosService _service;

        public ContactosController(IContactosService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var Contactos = _service.GetAllContactos();
            
            if (Contactos != null)
            { return Ok(Contactos); }
            else
            { return NoContent(); }

        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int id)
        {
            
            var contacto = _service.GetContactoById(id);
            if (contacto != null)
            { return Ok(contacto); }
            else
            { return NoContent(); }
            
        }

        [HttpPost]
        public IActionResult Create(Contactos contacto)
        {
            if(contacto == null) return BadRequest();
            bool response =  _service.Insert(contacto);
            
            if(response)
            { 
                return Created("Created", true);
            } else
            {
                return BadRequest("Failed to create Contact. Please, contact the administrator.");
            }

        }

        [HttpPut("{id}")]
        public IActionResult Update(Contactos contacto, int id)
        {   
            if (id != contacto.id) return BadRequest("ID mismatch, please fix it and try again;");

            bool response = _service.Update(contacto);

            if(response)
            { return Created("Created", true); } 
            else 
            { return BadRequest("Something went wrong while updating the info. Try Again."); }
        }


        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            Contactos book = _service.GetContactoById(id);
            bool response = _service.Delete(book);
           if(response)
            {  return Ok(); } 
            else
            {  return BadRequest(); }
            
        }


    }
}

