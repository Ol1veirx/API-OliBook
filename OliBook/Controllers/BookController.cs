using Microsoft.AspNetCore.Mvc;
using OliBook.Models;
using OliBook.Services;

namespace OliBook.Controllers
{
    [ApiController]
    [Route("controller")]
    public class BookController : Controller
    {
        public BookController() { }

        [HttpGet]
        public ActionResult<List<Book>> GetAll() => BookServices.GetAll();
        [HttpGet("{id}")]
        public ActionResult<Book> Get(int id)
        {
            var book = BookServices.Get(id);
            if (book is null) return NotFound();
            return Ok(book);
        }
        [HttpPost]
        public ActionResult Post(Book book)
        {
            BookServices.Add(book);
            return CreatedAtAction(nameof(Get), new Book { Id = book.Id }, book);
        }
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (id != book.Id) return BadRequest();
            BookServices.Update(book);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = BookServices.Get(id);
            if (book is null) return BadRequest();
            BookServices.Delete(id);
            return NoContent();
        }
    }
}
