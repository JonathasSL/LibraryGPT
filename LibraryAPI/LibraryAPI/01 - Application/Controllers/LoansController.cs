using LibraryAPI.Application.Models;
using LibraryAPI.Application.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LibraryAPI.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoansController : Controller
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _service.GetAllAsync().Result.ToList();
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            var result = _service.GetById(id).Result;
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpGet("user/{id}")]
        public IActionResult GetByUser([FromRoute] Guid id)
        {
            var result = _service.GetByUser(id);
            if (result != null)
                return Ok(result);
            else
                return NoContent();
        }

        [HttpPost]
        public IActionResult Register([FromBody] Loan model)
        {
            var result = _service.Create(model).Result;
            if (result != null)
                return Ok(result);
            else
                return BadRequest();
        }

        [HttpPost("{id}/return")]
        public IActionResult Return([FromRoute] Guid id)
        {
            var result = _service.ReturnCopy(id).Result;
            if (result != null)
                return Ok(result);
            else
                return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var result = _service.Delete(id).Result;
            if (result != null)
                return NotFound();
            else
                return NoContent();
        }

        private ILoanService _service;

        public LoansController(ILoanService service)
        {
            _service = service;
        }
    }
}
