using Microsoft.EntityFrameworkCore;
using NetSample.Database;

namespace NetSample.IntegrationTests
{
    public class DatabaseTestFixture : IDisposable
    {
        public NetSampleContext DbContext { get; private set; }

        public DatabaseTestFixture()
        {
            var options = new DbContextOptionsBuilder<NetSampleContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            DbContext = new NetSampleContext(options);
        }

        // Between tests if needed
        public void ResetDatabase()
        {
            DbContext.Database.EnsureDeleted();
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            DbContext.Dispose();
        }
    }
}
