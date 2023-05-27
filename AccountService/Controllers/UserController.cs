using AccountService.Domain.Commands.User;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AccountService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController
    {


        [HttpPost("Add")]
        public async Task<IActionResult> Add(UserAddCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLoginCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
