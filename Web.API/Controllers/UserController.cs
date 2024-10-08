using Application.UseCases.Users.Queries.UserGetAll;
using Web.API.Abstractions;

namespace Web.API.Controllers
{
    [Route("api/[controller]")]
    public class UserController(ISender mediator) : ControllerAbstraction
    {
        private readonly ISender _mediator = mediator;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new UserGetAllQuery());

            return response.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
