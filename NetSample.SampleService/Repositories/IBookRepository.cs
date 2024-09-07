using NetSample.Database.Models;

namespace NetSample.SampleService.Repositories
{
    public interface IBookRepository
    {
        Task<Book?> GetBookAsync(int id);
    }
}
