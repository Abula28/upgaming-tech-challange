using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Upgaming_Tech_Challange.Models;

namespace Upgaming_Tech_Challange.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        [HttpGet("{id}/books")]
        public IActionResult GetBookByAuthorId(int id)
        {
            var bookCatalog = new BookCatalog();
            var books = bookCatalog.GetBooksByAuthorId(id);
            if (books.Count == 0)
            {
                return NotFound(new { message = "Author not found or has no books." });
            }
            return Ok(books);
        }
    }
}
