namespace evaluacionClaro.Services
{
    public interface IBooksService
    {
        IEnumerable<Books> GetAllBooks();
        Books GetBookById(int BookId);
        bool Insert(Books book);
        bool Update(Books book, int id);
        bool Delete(int id);
    }
}