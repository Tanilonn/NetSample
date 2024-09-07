using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NetSample.Models;
using NetSample.SampleService.Repositories;

namespace NetSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _repo;
        private readonly IMapper _mapper;

        public BookController(IBookRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet("{title}")]
        public async Task<ActionResult<Book>> GetBook(string title)
        {
            var book = await _repo.GetBookAsync(title);

            if (book == null)
            {
                return NotFound();
            }

            return _mapper.Map<Book>(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(Book book)
        {
            await _repo.AddBookAsync(_mapper.Map<Database.Models.Book>(book));

            return CreatedAtAction("GetBook", new { title = book.Title }, book);
        }

        [HttpDelete("{title}")]
        public async Task<IActionResult> DeleteBook(string title)
        {
            var book = await _repo.GetBookAsync(title);
            if (book == null)
            {
                return NotFound();
            }

            await _repo.DeleteBook(book);

            return NoContent();
        }
    }
}
