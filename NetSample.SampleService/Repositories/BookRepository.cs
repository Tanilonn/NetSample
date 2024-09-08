using Microsoft.EntityFrameworkCore;
using NetSample.Database;
using NetSample.SampleService.Acl;
using NetSample.SampleService.Models;

namespace NetSample.SampleService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly NetSampleContext _context;

        public BookRepository(NetSampleContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetBooksStartingWithLetter(string letter)
        {
            var books = new List<Book>();
            var dbBooks = await _context.Books.Where(b => b.Title.StartsWith(letter)).ToListAsync();
            foreach (var dbBook in dbBooks)
            {
                var book = BookAntiCorruptionLayer.MapBook(dbBook);
                books.Add(book);
            }
            return books;
        }

        public async Task<IEnumerable<Book>> GetBooksWhereDescriptionContains(string word)
        {
            var books = new List<Book>();
            var dbBooks = await _context.Books.Where(b => b.Description.Contains(word)).ToListAsync();
            foreach (var dbBook in dbBooks)
            {
                var book = BookAntiCorruptionLayer.MapBook(dbBook);
                books.Add(book);
            }
            return books;
        }

        public async Task<Book?> GetBookAsync(string title)
        {
            var dbBook = await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.Title.ToLower() == title.ToLower());
            if (dbBook == null) 
            {
                return null;

            }
            var book = BookAntiCorruptionLayer.MapBook(dbBook);
            return book;
        }

        public async Task<Book> AddBookAsync(Book book)
        {
            var dbBook = new Database.Models.Book();
            BookAntiCorruptionLayer.UpdateBook(dbBook, book);
            _context.Books.Add(dbBook);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task DeleteBook(string title)
        {
            var dbBook = await _context.Books.SingleAsync(b => b.Title.ToLower() == title.ToLower());

            _context.Books.Remove(dbBook);
            await _context.SaveChangesAsync();

            return;
        }

    }
}
