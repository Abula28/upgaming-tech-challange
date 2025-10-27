using Microsoft.AspNetCore.Mvc;
using Upgaming_Tech_Challange.Dtos;

namespace Upgaming_Tech_Challange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetBooks([FromQuery] int? publicationYear, [FromQuery] string? sortBy)
        {
            var bookCatalog = new BookCatalog();
            var books = bookCatalog.GetBooks(publicationYear, sortBy);
            return Ok(books);
        }

        [HttpPost]
        public IActionResult PostBook(BookDto book)
        {
            var bookCatalog = new BookCatalog();
            try
            {
                var createdBook = bookCatalog.CreateBook(book);
                return CreatedAtAction(nameof(GetBooks), new { id = createdBook.ID }, createdBook);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }
    }
}
