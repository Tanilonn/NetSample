using NetSample.SampleService.Models;
using NetSample.SampleService.Repositories;
using System.Text.RegularExpressions;

namespace NetSample.SampleService.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<IEnumerable<Book>> GetBookStartingWithAsync(string letter)
        {
            return await bookRepository.GetBooksStartingWithLetter(letter);
        }

        public async Task<Book?> MostFrequentMentionInDescriptionOf(string word)
        {
            // get book whose description contains the word
            var books = await bookRepository.GetBooksWhereDescriptionContains(word);
            // now get the book that mentions it most often
            var book = books
                        .Select(b => new { WordCount = Regex.Matches(b.Description, word).Count, Book = b })
                        .OrderByDescending(b => b.WordCount)
                        .Select(b => b.Book)
                        .FirstOrDefault();
            return book;
        }

        public async Task<Book?> GetBookAsync(string title)
        {
            return await bookRepository.GetBookAsync(title);
        }

        public async Task<Book?> AddBookAsync(Book book)
        {
            return await bookRepository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(string title)
        {
            await bookRepository.DeleteBook(title);
            return;
        }
    }
}
