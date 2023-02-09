using FakeApi.Data;
using FakeApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FakeApi.Repository
{
    public class ContactosRepository : IContactosRepository
    {
        private readonly ContactosContext _context;

        public ContactosRepository(ContactosContext context)
        {
            _context = context;
        }

        public IEnumerable<Contactos> GetAllContactos()
        {
            return _context.Contactos.ToList();
        }

        public Contactos GetContactosById(int contactoId)
        {
            return _context.Contactos.Find(contactoId);     
        }

        public void Insert(Contactos contacto)
        {
            _context.Contactos.Add(contacto);
        }

        public void Update(Contactos contacto)
        {
            _context.Entry(contacto).State = EntityState.Modified;
        }

        public void Delete(Contactos contacto)
        { 
      
            _context.Contactos.Remove(contacto);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}