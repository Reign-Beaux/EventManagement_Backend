using Microsoft.AspNetCore.Diagnostics;

namespace Web.API.Abstractions
{
    public class ErrorsController : ControllerBase
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        [Route("/error")]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerPathFeature>()?.Error;

            return Problem();
        }
    }
}
