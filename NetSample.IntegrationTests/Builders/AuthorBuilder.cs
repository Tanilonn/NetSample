using NetSample.Database.Models;

namespace NetSample.IntegrationTests.Builders
{
    internal class AuthorBuilder
    {
        private readonly Author _requestBody;

        public AuthorBuilder()
        {
            _requestBody = new Author
            {
                Name = "TestName"
            };
        }

        public Author Build()
        {
            return _requestBody;
        }

        public AuthorBuilder WithName(string name)
        {
            _requestBody.Name = name;

            return this;
        }
    }

}
