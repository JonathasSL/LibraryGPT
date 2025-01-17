using Microsoft.AspNetCore.Mvc;

namespace LibraryAPI.Application.Controllers
{
    public class Controller : ControllerBase
    {
        public IActionResult HandleResponse<T>(T result)
        {
            if (result == null)
                return NotFound(result);

            return Ok(result);
        }
    }
}
