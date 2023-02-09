using FakeApi.Models;

namespace FakeApi.Repository
{
    public interface IContactosRepository
    {
        IEnumerable<Contactos> GetAllContactos();
        Contactos GetContactosById(int contactoId);
        void Insert(Contactos contacto);
        void Update(Contactos contacto);
        void Delete(Contactos contacto);

        void Save();

    }
}