using AccountService.Domain.Commands.User;
using AccountService.Domain.Quieries.User;
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

        [HttpPost("UserAddress")]
        public async Task<IActionResult> AddUserAddress(UserAddressAddCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

        [HttpGet("UserAddress")]
        public async Task<IActionResult> AddUserAddress([FromQuery] UserAddressQuery query)
        {
            var result = await Mediator.Send(query);

            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }

    }
}
