using Microsoft.EntityFrameworkCore;
using NetSample.Database.Models;

namespace NetSample.Data
{
    public class NetSampleContext : DbContext
    {
        public NetSampleContext (DbContextOptions<NetSampleContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; } = default!;

        public DbSet<Author> Authors { get; set; }
    }
}
