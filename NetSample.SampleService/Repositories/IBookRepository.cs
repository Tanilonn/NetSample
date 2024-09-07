using NetSample.Database.Models;

namespace NetSample.SampleService.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetBookAsync(string title);

        Task<Book> AddBookAsync(Book book);

        Task DeleteBook(Book book);
    }
}
