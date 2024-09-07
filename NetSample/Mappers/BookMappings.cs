using AutoMapper;

namespace NetSample.Mappers
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<Models.Book, Database.Models.Book>();
            CreateMap<Database.Models.Book, Models.Book>();
            CreateMap<Models.Author, Database.Models.Author>();
            CreateMap<Database.Models.Author, Models.Author>();
        }
    }
}
