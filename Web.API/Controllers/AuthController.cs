using Application.UseCases.Auth.Commands.Login;
using Web.API.Abstractions;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class AuthController(ISender mediator) : ControllerAbstraction
    {
        private readonly ISender _mediator = mediator ?? throw new ArgumentException(null, nameof(mediator));


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            var result = await _mediator.Send(command);
            return result.Match(
                value => Ok(value),
                errors => Problem(errors)
            );
        }
    }
}
