using Microsoft.EntityFrameworkCore;
using NetSample.Database;
using NetSample.Database.Models;

namespace NetSample.SampleService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private NetSampleContext context;

        public BookRepository(NetSampleContext context)
        {
            this.context = context;
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            return await context.Books.SingleOrDefaultAsync(b => b.Id == id);
        }
    }
}
