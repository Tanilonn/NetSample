using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetSample.Models;
using NetSample.SampleService.Services;

namespace NetSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _service;
        private readonly IMapper _mapper;

        public BookController(IBookService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<Book>> GetBook(string title)
        {
            var book = await _service.GetBookAsync(title);

            if (book == null)
            {
                return NotFound();
            }

            return _mapper.Map<Book>(book);
        }

        [HttpGet("description/{word}")]
        public async Task<ActionResult<Book>> GetBookWhereDescriptionContains(string word)
        {
            var book = await _service.MostFrequentMentionInDescriptionOf(word);

            if (book == null)
            {
                return NotFound();
            }

            return _mapper.Map<Book>(book);
        }

        [HttpGet("startsWith/{letter}")]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooksStartingWith(string letter)
        {
            var books = await _service.GetBookStartingWithAsync(letter);
            var responses = new List<Book>();
            foreach (var book in books)
            {
                responses.Add(_mapper.Map<Book>(book));
            }

            return responses;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _service.AddBookAsync(_mapper.Map<SampleService.Models.Book>(book));

            return CreatedAtAction("GetBook", new { title = book.Title }, book);
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteBook(string title)
        {
            var book = await _service.GetBookAsync(title);
            if (book == null)
            {
                return NotFound();
            }

            await _service.DeleteBookAsync(title);

            return NoContent();
        }
    }
}
