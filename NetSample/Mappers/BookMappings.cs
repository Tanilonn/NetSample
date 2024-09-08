using AutoMapper;

namespace NetSample.Mappers
{
    public class BookMappings : Profile
    {
        public BookMappings()
        {
            CreateMap<Models.Book, SampleService.Models.Book>();
            CreateMap<SampleService.Models.Book, Models.Book>();
            CreateMap<Models.Author, SampleService.Models.Author>();
            CreateMap<SampleService.Models.Author, Models.Author>();
        }
    }
}
