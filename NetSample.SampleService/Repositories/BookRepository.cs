using Microsoft.EntityFrameworkCore;
using NetSample.Database;
using NetSample.Database.Models;

namespace NetSample.SampleService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly NetSampleContext _context;

        public BookRepository(NetSampleContext context)
        {
            _context = context;
        }

        public async Task<Book?> GetBookAsync(string title)
        {
            return await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task DeleteBook(Book book)
        {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return;
        }

    }
}
