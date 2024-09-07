using Microsoft.EntityFrameworkCore;
using NetSample.Data;
using NetSample.Database.Models;

namespace NetSample.SampleService
{
    public class BookRepository
    {
        private NetSampleContext context;

        public BookRepository(NetSampleContext context)
        {
            this.context = context;
        }
        
        public async Task<Book> GetBookAsync(int id)
        {
            return await context.Books.SingleAsync(b => b.Id == id);
        }
    }
}
