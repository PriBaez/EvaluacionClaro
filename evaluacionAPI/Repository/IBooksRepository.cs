using evaluacionAPI.Models;

namespace evaluacionAPI.Repository
{
    public interface IBooksRepository
    {
        IEnumerable<Books> GetAllBooks();
        Books GetBookById(int BookId);
        void Insert(Books book);
        void Update(Books book);
        void Delete(Books book);

        void Save();

    }
}