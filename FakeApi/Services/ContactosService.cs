using System.Web;
using FakeApi.Models;
using FakeApi.Repository;

namespace FakeApi.Services
{
    public class ContactosService : IContactosService
    {
        private IContactosRepository _repository;

        public ContactosService(IContactosRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Contactos> GetAllContactos()
        {
            return  _repository.GetAllContactos();   
        }

        public Contactos GetContactoById(int contactoId)
        {
            return  _repository.GetContactosById(contactoId);
        }

        public bool Insert(Contactos contacto)
        {
            if(contacto.Nombre != null && contacto.Telefono != null 
                && contacto.Correo != null)
            {
                _repository.Insert(contacto);
                _repository.Save();
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public bool Update(Contactos contacto)
        {
            if(contacto.Nombre != null && contacto.Telefono != null 
                && contacto.Correo != null)
            {
                _repository.Update(contacto);
                _repository.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Contactos contacto)
        {
            if(contacto.Nombre != null && contacto.Telefono != null 
                && contacto.Correo != null)
            {
                _repository.Delete(contacto);
                _repository.Save();
                return true;
            }
            else
            {
                return false;
            }

        }
    }

}