using LibraryAPI.Application.Models;
using LibraryAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _service.GetAllAsync();
            if (result.Any())
                return Ok(result);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var result = await _service.GetById(id);
            if (result is null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] User model)
        {
            var result = await _service.Create(model);
            if (result is null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] User model)
        {
            var result = await _service.Update(id, model);
            if (result is null)
                return Ok(result);
            else
                return NotFound();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var result = await _service.Delete(id);
            if (result == null)
                return NotFound();
            else 
                return NoContent();
        }
        
        private IUserService _service;

        public UsersController(IUserService userService)
        {
            _service = userService;
        }
    }
}
