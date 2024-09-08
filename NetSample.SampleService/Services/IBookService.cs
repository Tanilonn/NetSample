using NetSample.SampleService.Models;

namespace NetSample.SampleService.Services
{
    public interface IBookService
    {
        Task<Book?> GetBookAsync(string title);

        Task<Book?> AddBookAsync(Book book);

        Task DeleteBookAsync(string title);

        Task<Book?> MostFrequentMentionInDescriptionOf(string word);

        Task<IEnumerable<Book>> GetBookStartingWithAsync(string letter);

    }
}
