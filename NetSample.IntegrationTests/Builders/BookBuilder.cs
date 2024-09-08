using NetSample.Database.Models;

namespace NetSample.IntegrationTests.Builders
{
    internal class BookBuilder
    {
        private readonly Book _requestBody;

        public BookBuilder()
        {
            _requestBody = new Book()
            {
                Title = "Title" + Guid.NewGuid(),
                Description = "Description",
                Author = new Author
                {
                    Name = "testName"
                },
            };
        }

        public Book Build()
        {
            return _requestBody;
        }

        public BookBuilder WithTitle(string title)
        {
            _requestBody.Title = title;

            return this;
        }

        public BookBuilder WithDescription(string description)
        {
            _requestBody.Description = description;

            return this;
        }

        public BookBuilder WithAuthor(Action<AuthorBuilder> configure)
        {
            var builder = new AuthorBuilder();
            configure(builder);
            _requestBody.Author = builder.Build();
            return this;
        }
    }
}
