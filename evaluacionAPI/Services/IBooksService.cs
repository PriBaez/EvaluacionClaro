using evaluacionAPI.Models;

namespace evaluacionAPI.Services
{
    public interface IBooksService
    {
        IEnumerable<Books> GetAllBooks();
        Books GetBookById(int BookId);
        bool Insert(Books book);
        bool Update(Books book);
        bool Delete(Books book);
    }
}