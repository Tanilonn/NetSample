using NetSample.Database;
using NetSample.IntegrationTests.Builders;
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
            var mostMentionBook = new BookBuilder().WithDescription("This book talks about magic and more magic").Build();
            var secondMostMention = new BookBuilder().WithDescription("Another book that mentions magic once").Build();
            var noMentionBook = new BookBuilder().WithDescription("No mention").Build();
            await SeedBooksAsync([ mostMentionBook, secondMostMention, noMentionBook]);

            // Act
            var result = await _bookService.MostFrequentMentionInDescriptionOf(word);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(mostMentionBook.Title, result.Title);
        }

        private async Task SeedBooksAsync(List<Database.Models.Book> books)
        {
            _dbContext.Books.AddRange(books);
            await _dbContext.SaveChangesAsync();
        }
    }
}
