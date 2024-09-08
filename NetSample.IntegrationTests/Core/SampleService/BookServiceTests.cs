using NetSample.Database;
using NetSample.SampleService.Repositories;
using NetSample.SampleService.Services;

namespace NetSample.IntegrationTests.Core.SampleService
{
    public class BookServiceTests : IClassFixture<DatabaseTestFixture>
    {
        private readonly BookService _bookService;
        private readonly NetSampleContext _dbContext;

        public BookServiceTests(DatabaseTestFixture fixture)
        {
            _dbContext = fixture.DbContext;
            _bookService = new BookService(new BookRepository(_dbContext));
        }

        [Fact]
        public async Task MostFrequentMentionInDescriptionOf_ReturnsCorrectBook()
        {
            // Arrange
            var word = "magic";

            await SeedBooksAsync(
            [
                new Database.Models.Book { Title = "First", Description = "This book talks about magic and more magic" },
                new Database.Models.Book { Title = "Second", Description = "Another book that mentions magic once" },
                new Database.Models.Book { Title = "Third", Description = "This book has no mention of that word" }
            ]);

            // Act
            var result = await _bookService.MostFrequentMentionInDescriptionOf(word);

            // Assert
            Assert.NotNull(result);
            Assert.Equal("First", result.Title);
        }

        private async Task SeedBooksAsync(List<Database.Models.Book> books)
        {
            _dbContext.Books.AddRange(books);
            await _dbContext.SaveChangesAsync();
        }
    }
}
