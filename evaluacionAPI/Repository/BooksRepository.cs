using evaluacionAPI.Data;
using evaluacionAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace evaluacionAPI.Repository
{
    public class BooksRepository : IBooksRepository
    {
        private readonly LibraryContext _context;

        public BooksRepository(LibraryContext context)
        {
            _context = context;
        }

        public IEnumerable<Books> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Books GetBookById(int BookId)
        {
            return _context.Books.Find(BookId);     
        }

        public void Insert(Books book)
        {
            _context.Books.Add(book);
        }

        public void Update(Books book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Delete(Books book)
        { 
      
            _context.Books.Remove(book);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}