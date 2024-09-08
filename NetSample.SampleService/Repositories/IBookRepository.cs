using NetSample.SampleService.Models;

namespace NetSample.SampleService.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetBookAsync(string title);

        Task<Book> AddBookAsync(Book book);

        Task DeleteBook(string title);

        Task<IEnumerable<Book>> GetBooksStartingWithLetter(string letter);

        Task<IEnumerable<Book>> GetBooksWhereDescriptionContains(string word);
    }
}
