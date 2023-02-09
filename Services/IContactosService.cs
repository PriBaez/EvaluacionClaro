using evaluacionClaro.Models;

namespace evaluacionClaro.Services
{
    public interface IContactosService
    {
        IEnumerable<Contactos> GetAllContactos();
        Contactos GetContactosById(int contactoId);
        bool Insert(Contactos contacto);
        bool Update(Contactos contacto, int id);
        bool Delete(int id);

    }
}