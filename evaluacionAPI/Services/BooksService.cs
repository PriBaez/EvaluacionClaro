using evaluacionAPI.Models;
using evaluacionAPI.Repository;

namespace evaluacionAPI.Services
{
    public class BooksService : IBooksService
    {
        private IBooksRepository _repository;

        public BooksService(IBooksRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Books> GetAllBooks()
        {
            return  _repository.GetAllBooks();   
        }

        public Books GetBookById(int bookId)
        {
            return  _repository.GetBookById(bookId);
        }

        public bool Insert(Books book)
        {
            if(book.author != null && book.title != null 
                && book.release_date != null && book.genre != null)
            {
                _repository.Insert(book);
                _repository.Save();
                return true;
            }
            else
            {
                return false;
            }

           
        }

        public bool Update(Books book)
        {
            if(book.author != null && book.title != null 
                && book.release_date != null && book.genre != null)
            {
                _repository.Update(book);
                _repository.Save();
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Delete(Books book)
        {
            if(book.author != null && book.title != null 
                && book.release_date != null && book.genre != null)
            {
                _repository.Delete(book);
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