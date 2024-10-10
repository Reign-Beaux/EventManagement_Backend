using Application.UseCases.Users.Commands.UserDelete;
using Application.UseCases.Users.Commands.UserInsert;
using Application.UseCases.Users.Commands.UserUpdate;
using Application.UseCases.Users.Queries.UserGetAll;
using Application.UseCases.Users.Queries.UserGetById;
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
            UserGetAllQuery query = new();
            var response = await _mediator.Send(query);

            return response.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            UserGetByIdQuery query = new(id);
            var response = await _mediator.Send(query);

            return response.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }

        [HttpPost]
        public async Task<IActionResult> Insert([FromBody] UserInsertCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                result => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UserUpdateCommand command)
        {
            var response = await _mediator.Send(command);

            return response.Match(
                result => NoContent(),
                errors => Problem(errors)
            );
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            UserDeleteCommand command = new(id);
            var response = await _mediator.Send(command);

            return response.Match(
                result => Ok(result),
                errors => Problem(errors)
            );
        }
    }
}
