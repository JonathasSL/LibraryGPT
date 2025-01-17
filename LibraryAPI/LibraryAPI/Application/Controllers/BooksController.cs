using LibraryAPI.Application.Models;
using LibraryAPI.Application.Services;
using LibraryAPI.Infrasctructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetBooks()
        {
            return Ok(await _bookService.GetAllBooksAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Book book)
        {
            return Ok(_bookService.CreateCopy(book));
        }


        private IBookService _bookService;

        public BooksController(
            IBookService bookService)
        {
            _bookService = bookService;
        }
    }
}
