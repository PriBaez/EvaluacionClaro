using FakeApi.Models;

namespace FakeApi.Services
{
    public interface IContactosService
    {
        IEnumerable<Contactos> GetAllContactos();
        Contactos GetContactoById(int ContactoId);
        bool Insert(Contactos contacto);
        bool Update(Contactos contacto);
        bool Delete(Contactos contacto);
    }
}