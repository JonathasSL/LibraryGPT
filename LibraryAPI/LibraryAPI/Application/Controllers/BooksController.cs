using LibraryAPI.Application.Models;
using LibraryAPI.Application.Services;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return HandleResponse(await _bookService.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookById([FromRoute] Guid id)
        {
            return HandleResponse(await _bookService.GetById(id));
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Book book)
        {
            return HandleResponse(await _bookService.Create(book));
        }


        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Book book)
        {
            return HandleResponse(_bookService.Update(book));
        }
        
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _bookService.Delete(id);
            if (result == null)
                return NotFound();
            else 
                return NoContent();
        }


        private IBookService _bookService;

        public BooksController(
            IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
