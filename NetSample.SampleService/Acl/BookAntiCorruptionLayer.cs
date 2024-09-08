using NetSample.SampleService.Models;

namespace NetSample.SampleService.Acl
{
    internal class BookAntiCorruptionLayer
    {
        internal static Book MapBook(Database.Models.Book dbBook)
        {
            var book = CreateBook(dbBook);
            return book;
        }

        internal static void UpdateBook(Database.Models.Book dbBook, Book book)
        {
            dbBook.Title = book.Title;
            dbBook.Description = book.Description;
            dbBook.Author = new Database.Models.Author()
            {
                Name = book.Author.Name
            };
        }

        private static Book CreateBook(Database.Models.Book dbBook) 
        {
            var book = new Book();
            if (dbBook.Author != null)
            {
                book.Author = new Author()
                {
                    Name = dbBook.Author.Name
                };
            }
            book.Description = dbBook.Description;
            book.Title = dbBook.Title;

            return book;
        }
    }
}
